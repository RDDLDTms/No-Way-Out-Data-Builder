using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.Tests.Leverages
{
    public class DefenceLev : LeverageBase
    {
        public override LeverageType Type => LeverageType.PositiveEffectApplying;
        public override LeverageTargetType TargetType => LeverageTargetType.Alias;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Single;
        public override string UniversalName => "Defence";
        public override string RussianDisplayName => "Защита";

        public DefenceLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
    }
}
