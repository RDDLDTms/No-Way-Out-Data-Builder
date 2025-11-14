using DataBuilder.BuilderObjects;
using DataBuilder.Effects;
using DataBuilder.Effects.DecreaseEffects.EffectsOnTarget;
using DataBuilder.Effects.IncreaseEffects.EffectsOnTarget;
using DataBuilder.Effects.PeriodicEffects.EffectsOnTarget;
using NWO_Abstractions;

namespace DataBuilder.TargetSystem
{
    public class TargetBase : ITarget
    {
        private IBattleModelling? _battle;

        public event NewIntValue OnTargetDamaged;
        public event NewIntValue OnTargetRecovered;
        public event NewIntValue OnHealthChanged;
        public event EffectDelegate OnPositiveEffectApplied;
        public event EffectDelegate OnNegativeEffectApplied;
        public event EffectDelegate OnPositiveEffectRemoved;
        public event EffectDelegate OnNegativeEffectRemoved;
        public event NewUnitLogMessage OnEffectTickMessage;
        public event NewUnitLogMessage OnEffectEndMessage;

        public IPercentageValues IncomingPercentageValues { get; set; }

        public string UniversalName { get; protected set; }

        public string RussianDisplayName { get; protected set; }

        public IDescription Description => throw new NotImplementedException();

        public Guid Id { get; }

        public int TeamNumber { get; set; }

        public int Health { get; private set; }

        public int MaxHealth { get; private set; }

        public List<IImmune> Immunes { get; private set; }

        public List<IDefence> Defences { get; private set; }

        public List<IEffect> PositiveEffects { get; private set; } = new List<IEffect>();

        public List<IEffect> NegativeEffects { get; private set; } = new List<IEffect>();
        public bool IsOrganic { get; set; } = true;
        public bool IsAlive { get; set; } = true;
        public bool IsMech { get; set; } = false;

        public TargetBase(List<IImmune> immunes, List<IDefence> defences, int startHealth, int maxHealth, IPercentageValues incomingPercentageValues)
        {
            Immunes = immunes;
            Defences = defences;
            Health = startHealth;
            MaxHealth = maxHealth;
            IncomingPercentageValues = incomingPercentageValues;
            Id = Guid.NewGuid();
        }

        public TargetBase(List<IImmune> immunes, List<IDefence> defences, int maxHealth)
        {
            Immunes = immunes;
            Defences = defences;
            MaxHealth = maxHealth;
            Health = MaxHealth;
        }

        public virtual void JoinBattle(IBattleModelling battle, int teamNumber, int globalCooldown, List<IEffect>? negativeEffects, List<IEffect>? positiveEffects)
        {
            _battle = battle;
            TeamNumber = teamNumber;

            negativeEffects?.ForEach(x => ApplyNegativeEffect(x, percentage : 0));
            positiveEffects?.ForEach(x => ApplyPositiveEffect(x, percentage : 0));

            battle.Targets.Add(this);
        }

        public virtual void LeaveBattle()
        {
            if (_battle is not null)
            {
                _battle.Targets.Remove(this);
                _battle = null;
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
            PositiveEffects.Add(effect);
            StartEffect(effect, percentage);
            OnPositiveEffectApplied?.Invoke(effect);
        }

        public void ApplyNegativeEffect(IEffect effect, int percentage = 0)
        {
            NegativeEffects.Add(effect);
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
            if (NegativeEffects.Contains(sender))
                RemoveNegativeEffect(sender);
            else if (PositiveEffects.Contains(sender))
                RemovePositiveEffect(sender);
            if (string.IsNullOrWhiteSpace(logMessage) is false)
                OnEffectEndMessage?.Invoke(logMessage);
        }

        public void RemovePositiveEffect(IEffect effect)
        {
            if (effect is TargetPeriodicRecoveryEffect leverageEffect)
            {
                leverageEffect.OnEffectTick -= LeverageEffect_OnEffectTick;
                leverageEffect.OnEffectEnd -= Effect_OnEffectEnd;
                NegativeEffects.Remove(effect);
            }
            OnPositiveEffectRemoved?.Invoke(effect);
        }

        public void RemoveNegativeEffect(IEffect effect)
        {
            if (effect is TargetPeriodicDamageEffect leverageEffect)
            {
                leverageEffect.OnEffectTick -= LeverageEffect_OnEffectTick;
                leverageEffect.OnEffectEnd -= Effect_OnEffectEnd;
                NegativeEffects.Remove(effect);
            }
            OnNegativeEffectRemoved?.Invoke(effect);
        }

        private void LeverageEffect_OnEffectTick(IEffect sender, int newTime, string logMessage)
        {
            if (string.IsNullOrWhiteSpace(logMessage) is false)
                OnEffectTickMessage?.Invoke(logMessage);
        }

        private int GetTargetDamagePercentage()
        {
            int summaryPercentage = 0;
            foreach (TargetDefenceIncreaseEffect defInc in PositiveEffects.Where(x => x is TargetDefenceIncreaseEffect).Cast<TargetDefenceIncreaseEffect>())
            {
                summaryPercentage += defInc.Percentage;
            }

            foreach (TargetDefenceDecreaseEffect defDec in NegativeEffects.Where(x => x is TargetDefenceDecreaseEffect).Cast<TargetDefenceDecreaseEffect>())
            {
                summaryPercentage -= defDec.Percentage;
            }
            return summaryPercentage;
        }

        private int GetTargetRecoveryPercentage()
        {
            int summaryPercentage = 0;
            foreach (TargetRecoveryPowerIncreaseEffect recPowInc in PositiveEffects.Where(x => x is TargetRecoveryPowerIncreaseEffect).Cast<TargetRecoveryPowerIncreaseEffect>())
            {
                summaryPercentage += recPowInc.Percentage;
            }

            foreach (TargetRecoveryPowerDecreaseEffect recPowDec in NegativeEffects.Where(x => x is TargetRecoveryPowerDecreaseEffect).Cast<TargetRecoveryPowerDecreaseEffect>())
            {
                summaryPercentage -= recPowDec.Percentage;
            }
            return summaryPercentage;
        }
    }
}
