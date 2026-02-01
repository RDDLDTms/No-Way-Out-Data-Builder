using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class WeaknessLev : LeverageBase
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Single;
        public override string UniversalName => "Weakness";
        public override string RussianName => "Слабость";
        public override string InstrumentalCase => "слабостью";

        public WeaknessLev(ILeverageClass lClass) : base(lClass) { }
    }
}
