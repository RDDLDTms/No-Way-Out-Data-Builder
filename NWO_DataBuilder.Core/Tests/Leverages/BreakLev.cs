using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.Tests.Leverages
{
    public class BreakLev : LeverageBase
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Single;
        public override string UniversalName => "Break";
        public override string RussianDisplayName => "Пролом";

        public BreakLev(ILeverageClass lClass) : base(lClass) { }
    }
}
