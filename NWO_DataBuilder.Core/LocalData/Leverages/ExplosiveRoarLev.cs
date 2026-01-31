using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class ExplosiveRoarLev : InstantDamage
    {
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.SpaceAroundUnit;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Many;
        public override string UniversalName => "Explosive roar";
        public override string RussianDisplayName => "Взрывной рык";
        public override string InstrumentalCase => "взрывным рыком";

        public ExplosiveRoarLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
    }
}
