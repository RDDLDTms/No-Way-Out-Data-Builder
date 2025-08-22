using NWO_Abstractions;

namespace DataBuilder.Effects.DecreaseEffects.EffectsOnActor
{
    public class ActorRecoveringDecreaseEffect : DecreaseEffectBase
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override EffectCarrier Carrier => EffectCarrier.Actor;

        public ActorRecoveringDecreaseEffect(int duration, ILeverageClass effectClass, double cooldown, string effectName, int percentage) :
            base(duration, effectClass, cooldown, effectName, percentage)
        {

        }
    }
}
