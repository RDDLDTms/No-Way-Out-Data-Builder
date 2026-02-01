using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class AppealOfHealerLev : InstantRecovery
    {
        public override LeverageTargetType TargetType => LeverageTargetType.Alias;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.SpaceAroundUnit;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Place;
        public override string UniversalName => "Appeal of healer";
        public override string RussianName => "Воззвание лекаря";
        public override string InstrumentalCase => "воззванием лекаря";

        public AppealOfHealerLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
    }
}
