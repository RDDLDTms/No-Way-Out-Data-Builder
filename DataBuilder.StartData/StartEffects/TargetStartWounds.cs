using DataBuilder.Effects.PercentageEffects;
using NWO_Abstractions.Effects;

namespace DataBuilder.StartData
{
    public class TargetStartWounds : DecreaseEffectBase
    {
        public override EffectCarrier Carrier => EffectCarrier.Target;

        public override bool IsRemovable => false;

        public override bool HasLifeTime => false;

        public override bool HasPoints => false;

        public TargetStartWounds() 
            : base(EffectType.Negative, new WoundsLevCl(), StartEffectsUniversalNames.Wounds, StartEffectsRussianNames.Wounds) { }
    }
}
