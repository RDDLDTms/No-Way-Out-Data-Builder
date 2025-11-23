using NWO_Abstractions;

namespace DataBuilder.Effects
{
    public sealed class ActorDamageDecreaseEffect : DecreaseEffectBase
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override EffectCarrier Carrier => EffectCarrier.Actor;

        public ActorDamageDecreaseEffect(int duration, ILeverage leverage, double cooldown, int percentage) :
            base(duration, leverage, cooldown, percentage)
        {

        }
    }
}
