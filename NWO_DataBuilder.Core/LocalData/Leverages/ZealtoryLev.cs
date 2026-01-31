using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class ZealtoryLev : PositiveEffectApplying
    {
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Single;
        public override string UniversalName => "Zealtory";
        public override string RussianDisplayName => "Фанатизм";
        public override string InstrumentalCase => "фанатизмом";

        public ZealtoryLev(ILeverageClass lClass) : base(lClass) { }
    }
}
