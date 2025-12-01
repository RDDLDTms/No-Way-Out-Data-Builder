using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;
using NWO_Abstractions.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class PurifyingLev : LeverageBase
    {
        public override LeverageType Type => LeverageType.NegativeEffectRemoval;
        public override LeverageTargetType TargetType => LeverageTargetType.Alias;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Single;
        public override string UniversalName => "Purifying";
        public override string RussianDisplayName => "Очищение";
        public override string InstrumentalCase => "очищением";

        public PurifyingLev(ILeverageClass lClass) : base(lClass) { } 
    }
}
