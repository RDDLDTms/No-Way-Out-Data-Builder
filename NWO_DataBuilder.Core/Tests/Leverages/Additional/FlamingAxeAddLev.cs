using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.Tests.Leverages
{
    public class FlamingAxeAddLev : LeverageBase
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.FrontHemisphere;
        public override LeverageRangeType RangeType => LeverageRangeType.Melee;
        public override LeverageTargeting Targeting => LeverageTargeting.Many;
        public override string UniversalName => "Firing (Flaming axe)";
        public override string RussianDisplayName => "Горение (Пылающий топор)";

        public FlamingAxeAddLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
    }
}
