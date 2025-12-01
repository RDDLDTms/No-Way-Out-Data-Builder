using NWO_Abstractions;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Effects
{
    public sealed class TargetDefenceIncreaseEffect : IncreaseEffectBase
    {
        public override LeverageType Type => LeverageType.PositiveEffectApplying;
        public override EffectCarrier Carrier => EffectCarrier.Target;

        public TargetDefenceIncreaseEffect(ILeverage leverage, int duration,  double cooldown, int percentage) :
            base(leverage, duration, cooldown, percentage)
        {

        }
    }
}
