using NWO_Abstractions;

namespace DataBuilder.Effects
{
    public sealed class TargetDefenceIncreaseEffect : IncreaseEffectBase
    {
        public override LeverageType Type => LeverageType.PositiveEffectApplying;
        public override EffectCarrier Carrier => EffectCarrier.Target;

        public TargetDefenceIncreaseEffect(int duration, ILeverage leverage, double cooldown, int percentage) :
            base(duration, leverage, cooldown, percentage)
        {

        }
    }
}
