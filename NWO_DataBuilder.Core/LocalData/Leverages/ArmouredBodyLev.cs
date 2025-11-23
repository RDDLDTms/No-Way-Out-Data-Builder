using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class ArmouredBodyLev : LeverageBase
    {
        public override LeverageType Type => LeverageType.Damage;
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.FrontLine;
        public override LeverageRangeType RangeType => LeverageRangeType.Melee;
        public override LeverageTargeting Targeting => LeverageTargeting.Many;
        public override string UniversalName => "Armoured body";
        public override string RussianDisplayName => "Тело в доспехах";

        public ArmouredBodyLev(ILeverageClass lClass) : base(lClass) { }
    }
}
