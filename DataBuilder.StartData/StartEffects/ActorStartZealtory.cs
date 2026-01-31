using DataBuilder.Effects.PercentageEffects;
using NWO_Abstractions.Effects;

namespace DataBuilder.StartData
{
    public sealed class ActorStartZealtory : IncreaseEffectBase
    {
        public override EffectCarrier Carrier => EffectCarrier.Actor;
        public override bool IsRemovable => false;

        public override bool HasLifeTime => false;

        public override bool HasPoints => false;

        public ActorStartZealtory() 
            : base(EffectType.Positive, new ZealtoryLevCl(), StartEffectsUniversalNames.Zealtory, StartEffectsRussianNames.Zealtory) { }
    }
}
