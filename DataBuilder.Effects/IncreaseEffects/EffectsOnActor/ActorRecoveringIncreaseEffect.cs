using NWO_Abstractions;

namespace DataBuilder.Effects
{
    public sealed class ActorRecoveringIncreaseEffect : IncreaseEffectBase
    {
        public override LeverageType Type => LeverageType.PositiveEffectApplying;
        public override EffectCarrier Carrier => EffectCarrier.Actor;

        public ActorRecoveringIncreaseEffect(int duration, ILeverage leverage, double cooldown, int percentage) :
            base(duration, leverage, cooldown, percentage)
        {

        }
    }
}
