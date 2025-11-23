using NWO_Abstractions;

namespace DataBuilder.Effects
{
    public sealed class ActorDamageIncreaseEffect : IncreaseEffectBase
    {
        public override LeverageType Type => LeverageType.PositiveEffectApplying;
        public override EffectCarrier Carrier => EffectCarrier.Actor;

        public ActorDamageIncreaseEffect(int duration, ILeverage leverage, double cooldown, int percentage) :
            base(duration, leverage, cooldown, percentage)
        {

        }
    }
}
