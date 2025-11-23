using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class MirrorArmorAddLev : LeverageBase
    {
        public override LeverageType Type => LeverageType.Damage;
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.FrontLine;
        public override LeverageRangeType RangeType => LeverageRangeType.Melee;
        public override LeverageTargeting Targeting => LeverageTargeting.Many;
        public override string UniversalName => "Mirror armor";
        public override string RussianDisplayName => "Зеркальный доспех";

        public MirrorArmorAddLev(ILeverageClass lClass) : base(lClass) { }
    }
}
