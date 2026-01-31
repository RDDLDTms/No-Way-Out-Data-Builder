using DataBuilder.Effects.PercentageEffects;
using NWO_Abstractions.Effects;

namespace DataBuilder.StartData
{
    public sealed class TargetStartBreak : DecreaseEffectBase
    {
        public override EffectCarrier Carrier => EffectCarrier.Target;
        public override bool IsRemovable => false;

        public override bool HasLifeTime => false;

        public override bool HasPoints => false;

        public TargetStartBreak() 
            : base(EffectType.Negative, new BreakLevCl(), StartEffectsUniversalNames.Break, StartEffectsRussianNames.Break) { }
    }
}
