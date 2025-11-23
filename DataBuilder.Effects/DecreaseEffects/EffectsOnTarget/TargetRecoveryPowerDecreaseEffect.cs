using NWO_Abstractions;

namespace DataBuilder.Effects
{
    public class TargetRecoveryPowerDecreaseEffect : DecreaseEffectBase
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override EffectCarrier Carrier => EffectCarrier.Target;

        public TargetRecoveryPowerDecreaseEffect(int duration, ILeverage leverage, double cooldown, int percentage) :
            base(duration, leverage, cooldown, percentage)
        {

        }
    }
}
