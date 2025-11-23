using NWO_Abstractions;

namespace DataBuilder.Effects
{ 
    public class TargetRecoveryPowerIncreaseEffect : IncreaseEffectBase
    {
        public override LeverageType Type => LeverageType.PositiveEffectApplying;
        public override EffectCarrier Carrier => EffectCarrier.Target;

        public TargetRecoveryPowerIncreaseEffect(int duration, ILeverage leverage, double cooldown, int percentage) :
            base(duration, leverage, cooldown, percentage)
        {

        }
    }
}
