using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class WoundsLev : NegativeEffectApplying
    {
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Single;
        public override string UniversalName => "Wounds";
        public override string RussianName => "Раны";
        public override string InstrumentalCase => "ранами";

        public WoundsLev(ILeverageClass lClass) : base(lClass) { }
    }
}
