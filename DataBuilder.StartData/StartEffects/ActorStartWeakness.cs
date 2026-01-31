using DataBuilder.Effects.PercentageEffects;
using NWO_Abstractions.Effects;

namespace DataBuilder.StartData
{
    public sealed class ActorStartWeakness : DecreaseEffectBase
    {
        public override EffectCarrier Carrier => EffectCarrier.Actor;
        public override bool IsRemovable => false;

        public override bool HasLifeTime => false;

        public override bool HasPoints => false;

        public ActorStartWeakness() 
            : base(EffectType.Negative, new WeaknessLevCl(), StartEffectsUniversalNames.Weakness, StartEffectsRussianNames.Weakness) { }
    }
}
