using NWO_Abstractions;

namespace DataBuilder.Effects.DecreaseEffects.EffectsOnActor
{
    public sealed class ActorDamageDecreaseEffect : DecreaseEffectBase
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override EffectCarrier Carrier => EffectCarrier.Actor;

        public ActorDamageDecreaseEffect(int duration, ILeverageClass effectClass, double cooldown, string effectName, int percentage) :
            base(duration, effectClass, cooldown, effectName, percentage)
        {

        }
    }
}
