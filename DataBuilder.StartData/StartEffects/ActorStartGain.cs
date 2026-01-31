using DataBuilder.Effects.PercentageEffects;
using NWO_Abstractions.Effects;

namespace DataBuilder.StartData
{
    public sealed class ActorStartGain : IncreaseEffectBase
    {
        public override EffectCarrier Carrier => EffectCarrier.Actor;
        public override bool IsRemovable => false;

        public override bool HasLifeTime => false;

        public override bool HasPoints => false;

        public ActorStartGain() 
            : base(EffectType.Positive, new GainLevCl(), StartEffectsUniversalNames.Gain, StartEffectsRussianNames.Gain) { }
    }
}
