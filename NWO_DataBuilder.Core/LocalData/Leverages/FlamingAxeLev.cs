using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class FlamingAxeLev : InstantDamage
    {
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.FrontHemisphere;
        public override LeverageRangeType RangeType => LeverageRangeType.Melee;
        public override LeverageTargeting Targeting => LeverageTargeting.Many;
        public override string UniversalName => "Flaming axe";
        public override string RussianName => "Пылающий топор";
        public override string InstrumentalCase => "пылающим двуручным топором";

        public FlamingAxeLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
    }
}
