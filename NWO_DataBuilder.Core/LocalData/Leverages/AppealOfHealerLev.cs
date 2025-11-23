using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class AppealOfHealerLev : LeverageBase
    {
        public override LeverageType Type => LeverageType.Recovery;
        public override LeverageTargetType TargetType => LeverageTargetType.Alias;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.SpaceAroundUnit;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Place;
        public override string UniversalName => "Appeal of healer";
        public override string RussianDisplayName => "Воззвание лекаря";

        public AppealOfHealerLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
    }
}
