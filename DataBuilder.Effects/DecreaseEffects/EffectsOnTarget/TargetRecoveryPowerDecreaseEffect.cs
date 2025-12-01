using NWO_Abstractions;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Effects
{
    public class TargetRecoveryPowerDecreaseEffect : DecreaseEffectBase
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override EffectCarrier Carrier => EffectCarrier.Target;

        public TargetRecoveryPowerDecreaseEffect(ILeverage leverage, int duration, double cooldown, int percentage) :
            base(leverage, duration, cooldown, percentage)
        {

        }
    }
}
