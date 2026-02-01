using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class ArmouredBodyLev : InstantDamage
    {
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.FrontLine;
        public override LeverageRangeType RangeType => LeverageRangeType.Melee;
        public override LeverageTargeting Targeting => LeverageTargeting.Many;
        public override string UniversalName => "Armoured body";
        public override string RussianName => "Тело в доспехах";
        public override string InstrumentalCase => "телом в доспехах";

        public ArmouredBodyLev(ILeverageClass lClass) : base(lClass) { }
    }
}
