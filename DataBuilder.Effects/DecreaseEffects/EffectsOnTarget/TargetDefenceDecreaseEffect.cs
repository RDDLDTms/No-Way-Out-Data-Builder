using NWO_Abstractions;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Effects
{
    public sealed class TargetDefenceDecreaseEffect : DecreaseEffectBase
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override EffectCarrier Carrier => EffectCarrier.Target;

        public TargetDefenceDecreaseEffect(ILeverage leverage, int duration, double cooldown, int percentage) :
            base(leverage, duration, cooldown, percentage)
        {

        }
    }
}
