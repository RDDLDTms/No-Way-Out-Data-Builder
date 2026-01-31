using DataBuilder.Effects.PercentageEffects;
using NWO_Abstractions.Effects;

namespace DataBuilder.StartData
{
    public sealed class TargetStartDefence : IncreaseEffectBase
    {
        public override EffectCarrier Carrier => EffectCarrier.Target;
        public override bool IsRemovable => false;

        public override bool HasLifeTime => false;

        public override bool HasPoints => false;

        public TargetStartDefence() 
            : base(EffectType.Positive, new DefenceLevCl(), StartEffectsUniversalNames.Defence, StartEffectsRussianNames.Defence) { }
    }
}
