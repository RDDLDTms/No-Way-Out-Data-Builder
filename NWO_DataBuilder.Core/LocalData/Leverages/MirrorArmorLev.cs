using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;
using NWO_Abstractions.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class MirrorArmorLev : LeverageBase
    {
        public override LeverageType Type => LeverageType.InstantDamage;
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.FrontLine;
        public override LeverageRangeType RangeType => LeverageRangeType.Melee;
        public override LeverageTargeting Targeting => LeverageTargeting.Many;
        public override string UniversalName => "Mirror armor";
        public override string RussianDisplayName => "Зеркальный доспех";
        public override string InstrumentalCase => "зеркальным доспехом";

        public MirrorArmorLev(ILeverageClass lClass) : base(lClass) { }
    }
}
