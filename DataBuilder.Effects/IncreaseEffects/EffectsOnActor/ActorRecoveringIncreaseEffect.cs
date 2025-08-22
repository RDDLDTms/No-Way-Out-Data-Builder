using NWO_Abstractions;

namespace DataBuilder.Effects.IncreaseEffects.EffectsOnActor
{
    public sealed class ActorRecoveringIncreaseEffect : IncreaseEffectBase
    {
        public override LeverageType Type => LeverageType.PositiveEffectApplying;
        public override EffectCarrier Carrier => EffectCarrier.Actor;

        public ActorRecoveringIncreaseEffect(int duration, ILeverageClass effectClass, double cooldown, string effectName, int percentage) :
            base(duration, effectClass, cooldown, effectName, percentage)
        {

        }
    }
}
