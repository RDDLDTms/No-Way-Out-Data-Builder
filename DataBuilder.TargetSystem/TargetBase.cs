using DataBuilder.Effects;
using NWO_Abstractions;
using NWO_Abstractions.Battles;

namespace DataBuilder.TargetSystem
{
    public class TargetBase : ITarget
    {
        private IBattleModelling? _battle;

        public event NewIntValue? OnTargetDamaged;
        public event NewIntValue? OnTargetRecovered;
        public event NewDoubleValue? OnHealthChanged;
        public event EffectDelegate? OnPositiveEffectApplied;
        public event EffectDelegate? OnNegativeEffectApplied;
        public event EffectDelegate? OnPositiveEffectRemoved;
        public event EffectDelegate? OnNegativeEffectRemoved;
        public event NewUnitLogMessage? OnEffectTickMessage;
        public event NewUnitLogMessage? OnEffectEndMessage;

        public IPercentageValues StartPercentageValues { get; set; }

        public IEffectsLists Effects { get; }

        public IEffectsLists StartEffects { get; }

        public List<IDefence> Defences { get; }

        public List<IImmune> Immunes { get; }

        public double Health { get; set; }

        public double MaxHealth { get; }

        public bool IsAlive { get; }

        public bool IsOrganic { get; }

        public bool IsMech { get; }

        public int TeamNumber { get; set; } = 0;

        public TargetBase(IPercentageValues startPercentageValues, double maxHealth, IEffectsLists startEffects, List<IDefence> defences, List<IImmune> immunes, 
            bool isAlive, bool isOrganic, bool isMech)
        {
            StartPercentageValues = startPercentageValues;
            MaxHealth = maxHealth;
            Effects = EffectsLists.Default();
            Effects.PositiveEffects = new();
            Effects.NegativeEffects = new();
            StartEffects = startEffects;
            Defences = new(defences);
            Immunes = new(immunes);
            IsAlive = isAlive;
            IsOrganic = isOrganic;
            IsMech = isMech;
        }

        public virtual void JoinBattle(IBattleModelling battle, int teamNumber, int globalCooldown)
        {
            _battle = battle;
            StartEffects.NegativeEffects?.ForEach(x => ApplyNegativeEffect(x, percentage: 0));
            StartEffects.PositiveEffects?.ForEach(x => ApplyPositiveEffect(x, percentage: 0));
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

        public int DamageTarget(int value)
        {
            value -= GetTargetDamagePercentage() * value / 100;
            Health -= value;
            if (Health < 0)
                Health = 0;

            OnHealthChanged?.Invoke(Health);
            OnTargetDamaged?.Invoke(value);
            return value;
        }

        public int RecoverTarget(int value)
        {
            value -= GetTargetRecoveryPercentage() * value / 100;
            Health += value;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
            OnHealthChanged?.Invoke(Health);
            OnTargetRecovered?.Invoke(value);
            return value;
        }

        public void ApplyPositiveEffect(IEffect effect, int percentage = 0)
        {
            Effects.PositiveEffects.Add(effect);
            StartEffect(effect, percentage);
            OnPositiveEffectApplied?.Invoke(effect);
        }

        public void ApplyNegativeEffect(IEffect effect, int percentage = 0)
        {
            Effects.NegativeEffects.Add(effect);
            StartEffect(effect, percentage);
            OnNegativeEffectApplied?.Invoke(effect);
        }

        private void StartEffect(IEffect effect, int percentage)
        {
            effect.OnEffectTick += LeverageEffect_OnEffectTick;
            effect.OnEffectEnd += Effect_OnEffectEnd;

            if (effect is EffectWithValuesBase effectWithValues)
            {
                effectWithValues.Start(this, _battle!.BattleSpeed, percentage, effectDelay: 1);
            }
            else
            {
                effect.Start(this, _battle!.BattleSpeed);
            }
        }

        private void Effect_OnEffectEnd(IEffect sender, string logMessage)
        {
            if (Effects.NegativeEffects.Contains(sender))
                RemoveNegativeEffect(sender);
            else if (Effects.PositiveEffects.Contains(sender))
                RemovePositiveEffect(sender);
            if (string.IsNullOrWhiteSpace(logMessage) is false)
                OnEffectEndMessage?.Invoke(logMessage);
        }

        public void RemovePositiveEffect(IEffect effect)
        {
            if (effect is EffectBase effectBase)
            {
                effectBase.OnEffectTick -= LeverageEffect_OnEffectTick;
                effectBase.OnEffectEnd -= Effect_OnEffectEnd;
                Effects.PositiveEffects.Remove(effect);
                OnPositiveEffectRemoved?.Invoke(effect);
            }
        }

        public void RemoveNegativeEffect(IEffect effect)
        {
            if (effect is EffectBase leverageEffect)
            {
                leverageEffect.OnEffectTick -= LeverageEffect_OnEffectTick;
                leverageEffect.OnEffectEnd -= Effect_OnEffectEnd;
                Effects.NegativeEffects.Remove(effect);
                OnNegativeEffectRemoved?.Invoke(effect);
            }
        }

        private void LeverageEffect_OnEffectTick(IEffect sender, int newTime, string logMessage)
        {
            if (string.IsNullOrWhiteSpace(logMessage) is false)
                OnEffectTickMessage?.Invoke(logMessage);
        }

        private int GetTargetDamagePercentage()
        {
            int summaryPercentage = 0;
            foreach (TargetDefenceIncreaseEffect defInc in Effects.PositiveEffects.Where(x => x is TargetDefenceIncreaseEffect).Cast<TargetDefenceIncreaseEffect>())
            {
                summaryPercentage += defInc.Percentage;
            }

            foreach (TargetDefenceDecreaseEffect defDec in Effects.NegativeEffects.Where(x => x is TargetDefenceDecreaseEffect).Cast<TargetDefenceDecreaseEffect>())
            {
                summaryPercentage -= defDec.Percentage;
            }
            return summaryPercentage;
        }

        private int GetTargetRecoveryPercentage()
        {
            int summaryPercentage = 0;
            foreach (TargetRecoveryPowerIncreaseEffect recPowInc in Effects.PositiveEffects.Where(x => x is TargetRecoveryPowerIncreaseEffect).Cast<TargetRecoveryPowerIncreaseEffect>())
            {
                summaryPercentage += recPowInc.Percentage;
            }

            foreach (TargetRecoveryPowerDecreaseEffect recPowDec in Effects.NegativeEffects.Where(x => x is TargetRecoveryPowerDecreaseEffect).Cast<TargetRecoveryPowerDecreaseEffect>())
            {
                summaryPercentage -= recPowDec.Percentage;
            }
            return summaryPercentage;
        }
    }
}
