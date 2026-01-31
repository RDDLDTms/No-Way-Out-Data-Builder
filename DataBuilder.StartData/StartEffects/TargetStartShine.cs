using DataBuilder.Effects.PercentageEffects;
using NWO_Abstractions.Effects;

namespace DataBuilder.StartData
{
    public class TargetStartShine : IncreaseEffectBase
    {
        public override EffectCarrier Carrier => EffectCarrier.Target;
        public override bool IsRemovable => false;

        public override bool HasLifeTime => false;

        public override bool HasPoints => false;

        public TargetStartShine() 
            : base(EffectType.Positive, new ShineLevCl(), StartEffectsUniversalNames.Shine, StartEffectsRussianNames.Shine) { }
    }
}
