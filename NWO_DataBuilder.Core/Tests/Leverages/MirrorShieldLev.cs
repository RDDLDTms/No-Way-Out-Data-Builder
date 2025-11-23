using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.Tests.Leverages
{
    public class MirrorShieldLev : LeverageBase
    {
        public override LeverageType Type => LeverageType.Damage;
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.FrontHemisphere;
        public override LeverageRangeType RangeType => LeverageRangeType.Melee;
        public override LeverageTargeting Targeting => LeverageTargeting.Many;
        public override string UniversalName => "Mirror shield";
        public override string RussianDisplayName => "Зеркальный щит";

        public MirrorShieldLev(ILeverageClass lClass) : base(lClass) { }
    }
}
