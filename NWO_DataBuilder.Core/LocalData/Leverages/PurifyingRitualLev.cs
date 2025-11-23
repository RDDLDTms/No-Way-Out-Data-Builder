using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class PurifyingRitualLev : LeverageBase
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override LeverageTargetType TargetType => LeverageTargetType.Alias;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.SpaceAroundUnit;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Many;
        public override string UniversalName => "Purifying ritual";
        public override string RussianDisplayName => "Ритуал очищения";

        public PurifyingRitualLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
    }
}
