using DataBuilder.Effects.PercentageEffects;
using NWO_Abstractions.Effects;

namespace DataBuilder.StartData
{
    public sealed class ActorStartDespondency : DecreaseEffectBase
    {
        public override EffectCarrier Carrier => EffectCarrier.Actor;

        public override bool IsRemovable => false;

        public override bool HasLifeTime => false;

        public override bool HasPoints => false;

        public ActorStartDespondency() 
            : base(EffectType.Negative, new DespondencyLevCl(), StartEffectsUniversalNames.Despondency, StartEffectsRussianNames.Despondency) { }
    }
}
