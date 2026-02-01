using DataBuilder.BuilderObjects;
using DataBuilder.Effects;
using DataBuilder.StartData;
using NWO_Abstractions;
using NWO_Abstractions.Battles;
using NWO_Abstractions.Data.Effects;
using NWO_Abstractions.Effects;
using NWO_Abstractions.Skills;

namespace DataBuilder.TargetSystem
{
    public class TargetBase : ITarget
    {
        private IBattleModelling? _battle;

        public event NewDoubleValue? OnTargetDamaged;
        public event NewDoubleValue? OnTargetRecovered;
        public event NewDoubleValue? OnHealthChanged;
        public event EffectApplyingHandler OnPositiveEffectApplied;
        public event EffectApplyingHandler OnNegativeEffectApplied;
        public event EffectApplyingHandler OnOtherEffectApplied;
        public event EffectFinishedHandler OnPositiveEffectRemoved;
        public event EffectFinishedHandler OnNegativeEffectRemoved;
        public event EffectFinishedHandler OnOtherEffectRemoved;
        public event EffectPeriodicTick OnPeriodicEffectTick;
        public event EffectWithDurationDelegateFinished OnEffectWithDurationFinished;

        public Guid TargetId { get; }

        public IPercentageValues StartPercentageValues { get; set; }

        public IEffectsSet Effects { get; }

        public IEffectsSet StartEffects { get; }

        public List<IDefence> Defences { get; }

        public List<IImmune> Immunes { get; }

        public double Health { get; set; }

        public double MaxHealth { get; }

        public bool IsAlive { get; }

        public bool IsOrganic { get; }

        public bool IsMech { get; }

        public int TeamNumber { get; set; } = 0;

        public TargetBase(IPercentageValues startPercentageValues, double maxHealth, IEffectsSet startEffects, List<IDefence> defences, List<IImmune> immunes, 
            bool isAlive, bool isOrganic, bool isMech)
        {
            StartPercentageValues = startPercentageValues;
            MaxHealth = maxHealth;
            Effects = EffectsSetBase.Default();
            Effects.PositiveEffects = new();
            Effects.NegativeEffects = new();
            StartEffects = startEffects;
            Defences = new(defences);
            Immunes = new(immunes);
            IsAlive = isAlive;
            IsOrganic = isOrganic;
            IsMech = isMech;
            TargetId = Guid.NewGuid();
        }

        public virtual void JoinBattle(IBattleModelling battle, int teamNumber, int globalCooldown)
        {
            _battle = battle;
            StartEffects.NegativeEffects?.ForEach(x => ApplyEffect(x, StartEffects.EffectsData[x.Id]));
            StartEffects.PositiveEffects?.ForEach(x => ApplyEffect(x, StartEffects.EffectsData[x.Id]));
            TeamNumber = teamNumber;
            battle.Targets.Add(this);
        }

        public virtual void LeaveBattle()
        {
            if (_battle is not null)
            {
                _battle.Targets.Remove(this);
                _battle = null;
                TeamNumber = 0;
            }
        }

        public double DamageTarget(double value)
        {
            value -= CollectTargetDamagePercentage() * value / 100;
            Health -= value;
            if (Health < 0)
                Health = 0;

            OnHealthChanged?.Invoke(Health);
            OnTargetDamaged?.Invoke(value);
            return value;
        }

        public double RecoverTarget(double value)
        {
            value -= CollectTargetRecoveryPercentage() * value / 100;
            Health += value;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
            OnHealthChanged?.Invoke(Health);
            OnTargetRecovered?.Invoke(value);
            return value;
        }

        public void ApplyEffect(IEffect effect, IEffectData data)
        {
            if (effect is PercentageEffectBase peb)
            {
                peb.SetPercentageSuffix(((IPercentageEffectData)data).Percentage);
            }

            if (Effects.Contains(effect, data.SenderId) is false)
            {
                Effects.AddAndSpreadEffects(effect);
                Effects.AddEffectsData(data);
                if (effect is IEffectWithDuration effectWithDuration)
                {
                    StartEffect(effectWithDuration, data);
                }
                switch (effect.Type)
                {
                    case EffectType.Positive:
                        OnPositiveEffectApplied?.Invoke(effect, this);
                        break;
                    case EffectType.Negative:
                        OnNegativeEffectApplied?.Invoke(effect, this);
                        break;
                    case EffectType.None:
                    default:
                        OnOtherEffectApplied?.Invoke(effect, this);
                        break;
                }
            }
            else
            {
                Effects.RefreshEffect(effect, data);
            }
        }

        public void RemoveEffects(List<IEffect> effects) => Effects.RemoveEffects(effects);

        public void ApplyEffect(ISkillEffectResultPart effectResultPart) => ApplyEffect(effectResultPart.Effect, effectResultPart.EffectData);

        private void StartEffect(IEffectWithDuration effect, IEffectData effectData)
        {
            if (effectData is IObjectWithDuration effectDataWithDuration)
            {
                effect.OnEffectFinishedByTime += OnEffectFinishedByTime;
                if (effectData is IPeriodicEffectCompleteData)
                    effect.OnEffectTick += OnEffectTick;
                effect.Start(_battle!.BattleSettings.BattleSpeed, effectDataWithDuration.Duration);
            }
        }

        private void OnEffectTick(IEffectWithDuration effect)
        {
            var data = Effects.EffectsData[effect.Id];
            if (data is IPeriodicEffectCompleteData periodicData)
            {
                var value = periodicData.GetValue();
                value += value *periodicData.StoredIncomingAdditionalPercentage /100;
                if (effect.Type is EffectType.Negative)
                    DamageTarget(value);
                else if (effect.Type is EffectType.Positive)
                    RecoverTarget(value);
                OnPeriodicEffectTick?.Invoke(effect, value);
            }
        }

        private void OnEffectFinishedByTime(IEffectWithDuration effect)
        {
            effect.OnEffectFinishedByTime -= OnEffectFinishedByTime;
            effect.OnEffectTick -= OnEffectTick;
            OnEffectWithDurationFinished?.Invoke(effect, EffectFinishReason.FinishedByTime);
            Effects.RemoveEffect(effect.Id);
        }

        private double CollectTargetDamagePercentage()
        {
            //TODO Добавить не только стартовый процент по урону, но и динамический во время боя
            return CollectStartTargetDamagePercentage();
        }

        private double CollectTargetRecoveryPercentage()
        {
            //TODO Добавить не только стартовый процент по восстановлению, но и динамический во время боя
            return CollectStartTargetRecoveryPercentage();
        }

        private double CollectStartTargetDamagePercentage()
        {
            double summaryRecoveryPercentage = 0;
            foreach (var effect in Effects.PositiveEffects.Where(x => x is TargetStartDefence).Cast<TargetStartDefence>())
            {
                summaryRecoveryPercentage += Effects.TryGetPercentage(effect);
            }

            foreach (var effect in Effects.NegativeEffects.Where(x => x is TargetStartBreak).Cast<TargetStartBreak>())
            {
                summaryRecoveryPercentage -= Effects.TryGetPercentage(effect);
            }
            return summaryRecoveryPercentage;
        }

        private double CollectStartTargetRecoveryPercentage()
        {
            double summaryRecoveryPercentage = 0;
            foreach (var effect in Effects.PositiveEffects.Where(x => x is TargetStartShine).Cast<TargetStartShine>())
            {
                summaryRecoveryPercentage += Effects.TryGetPercentage(effect);
            }

            foreach (var effect in Effects.NegativeEffects.Where(x => x is TargetStartWounds).Cast<TargetStartWounds>())
            {
                summaryRecoveryPercentage -= Effects.TryGetPercentage(effect);
            }
            return summaryRecoveryPercentage;
        }
    }
}
