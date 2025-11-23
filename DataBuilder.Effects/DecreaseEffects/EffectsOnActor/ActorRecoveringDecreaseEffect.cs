using NWO_Abstractions;

namespace DataBuilder.Effects
{ 
    public class ActorRecoveringDecreaseEffect : DecreaseEffectBase
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override EffectCarrier Carrier => EffectCarrier.Actor;

        public ActorRecoveringDecreaseEffect(int duration, ILeverage leverage, double cooldown, int percentage) :
            base(duration, leverage, cooldown, percentage)
        {

        }
    }
}
