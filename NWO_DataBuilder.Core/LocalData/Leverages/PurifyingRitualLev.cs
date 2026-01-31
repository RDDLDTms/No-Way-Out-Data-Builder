using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class PurifyingRitualLev : NegativeEffectRemoving
    {
        public override LeverageType Type => LeverageType.NegativeEffectRemoving;
        public override LeverageTargetType TargetType => LeverageTargetType.Alias;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.SpaceAroundUnit;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Many;
        public override string UniversalName => "Purifying ritual";
        public override string RussianDisplayName => "Ритуал очищения";
        public override string InstrumentalCase => "ритуалом очищения";

        public PurifyingRitualLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
    }
}
