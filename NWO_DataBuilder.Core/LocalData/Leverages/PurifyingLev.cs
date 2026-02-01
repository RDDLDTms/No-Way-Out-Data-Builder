using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class PurifyingLev : NegativeEffectRemoving
    {
        public override LeverageType Type => LeverageType.NegativeEffectRemoving;
        public override LeverageTargetType TargetType => LeverageTargetType.Alias;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Single;
        public override string UniversalName => "Purifying";
        public override string RussianName => "Очищение";
        public override string InstrumentalCase => "очищением";

        public PurifyingLev(ILeverageClass lClass) : base(lClass) { } 
    }
}
