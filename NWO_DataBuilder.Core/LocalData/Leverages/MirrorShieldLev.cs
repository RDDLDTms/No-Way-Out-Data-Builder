using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class MirrorShieldLev : InstantDamage
    {
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.FrontHemisphere;
        public override LeverageRangeType RangeType => LeverageRangeType.Melee;
        public override LeverageTargeting Targeting => LeverageTargeting.Many;
        public override string UniversalName => "Mirror shield";
        public override string RussianDisplayName => "Зеркальный щит";
        public override string InstrumentalCase => "зеркальным щитом";

        public MirrorShieldLev(ILeverageClass lClass) : base(lClass) { }
    }
}
