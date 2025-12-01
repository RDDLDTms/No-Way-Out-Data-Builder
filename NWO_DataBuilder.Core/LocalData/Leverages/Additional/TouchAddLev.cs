using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;
using NWO_Abstractions.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class TouchAddLev : LeverageBase
    {
        public override LeverageType Type => LeverageType.InstantRecovery;
        public override LeverageTargetType TargetType => LeverageTargetType.Alias;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Single;
        public override string UniversalName => "Touch";
        public override string RussianDisplayName => "Касание";
        public override string InstrumentalCase => "касанием";

        public TouchAddLev(ILeverageClass lClass) : base(lClass) { }
    }
}
