using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class BarrierLev : LeverageBase
    {
        public override LeverageType Type => LeverageType.Creation;
        public override LeverageTargetType TargetType => LeverageTargetType.Neutral;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Place;
        public override string UniversalName => "Barrier";
        public override string RussianName => "Барьер";
        public override string InstrumentalCase => "барьером";

        public BarrierLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
    }
}
