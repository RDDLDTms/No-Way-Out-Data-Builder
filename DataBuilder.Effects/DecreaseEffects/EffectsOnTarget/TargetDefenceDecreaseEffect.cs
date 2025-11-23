using NWO_Abstractions;

namespace DataBuilder.Effects
{
    public sealed class TargetDefenceDecreaseEffect : DecreaseEffectBase
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override EffectCarrier Carrier => EffectCarrier.Target;

        public TargetDefenceDecreaseEffect(int duration, ILeverage leverage, double cooldown, int percentage) :
            base(duration, leverage, cooldown, percentage)
        {

        }
    }
}
