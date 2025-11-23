using NWO_Abstractions;

namespace DataBuilder.Effects
{
    public class EffectWithValuesBase : EffectBase, ILeverageValues
    {
        public int MinValue { get; }

        public int MaxValue { get; }

        public int SourcePercentage { get; private set; }

        public EffectWithValuesBase(int duration, ILeverage leverage, double cooldown, int minValue, int maxValue) 
            : base(duration, leverage, cooldown)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public void Start(ITarget target, double battleSpeed, int sourcePercentage, int effectDelay)
        {
            SourcePercentage = sourcePercentage;
            Start(target, battleSpeed, effectDelay);
        }

        public virtual int GetValue() => 0;

        protected int GetTargetDamagePercentage() => GetDamageBasicPercentage() + GetClassPercentage();

        protected int GetTargetRecoveryPercentage() => GetRecoveringBasicPercentage() + GetClassPercentage();

        private int GetRecoveringBasicPercentage()
        {
            int recoveringIncreasePercent = 0;
            foreach (var nextRecoveringIncreaseEffect in TargetForEffect!.Effects.PositiveEffects.Where(x => x is TargetRecoveryPowerIncreaseEffect).Cast<IncreaseEffectBase>())
            {
                recoveringIncreasePercent += nextRecoveringIncreaseEffect.Percentage;
            }
            foreach (var nextRecoveringDecreaseEffect in TargetForEffect!.Effects.NegativeEffects.Where(x => x is TargetRecoveryPowerDecreaseEffect).Cast<DecreaseEffectBase>())
            {
                recoveringIncreasePercent -= nextRecoveringDecreaseEffect.Percentage;
            }
            return recoveringIncreasePercent;
        }

        private int GetDamageBasicPercentage()
        {
            int damageIncreasePercent = 0;
            foreach (var nextDamageDecreaseEffect in TargetForEffect!.Effects.PositiveEffects.Where(x => x is TargetDefenceIncreaseEffect).Cast<TargetDefenceIncreaseEffect>())
            {
                damageIncreasePercent -= nextDamageDecreaseEffect.Percentage;
            }
            foreach (var nextDamageIncreaseEffect in TargetForEffect!.Effects.NegativeEffects.Where(x => x is TargetDefenceDecreaseEffect).Cast<TargetDefenceDecreaseEffect>())
            {
                damageIncreasePercent += nextDamageIncreaseEffect.Percentage;
            }
            return damageIncreasePercent;
        }

        private int GetClassPercentage() 
        {
            // TODO
            return 0;
        }
    }
}
