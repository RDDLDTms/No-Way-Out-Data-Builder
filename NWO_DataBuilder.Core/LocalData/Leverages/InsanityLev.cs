using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Effects.ControlEffects;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class InsanityLev : NegativeEffectApplying
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Place;
        public override string UniversalName => "Insanity";
        public override string RussianDisplayName => "Помешательство";
        public override string InstrumentalCase => "помешательством";

        public InsanityLev(ILeverageClass lClass) : base(lClass) 
        {
            Effects.Add(new TargetControlEffectWithDuration(lClass, UniversalName, RussianDisplayName));
        }
    }
}
