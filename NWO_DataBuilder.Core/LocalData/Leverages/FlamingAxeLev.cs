using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;
using NWO_Abstractions.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class FlamingAxeLev : LeverageBase
    {
        public override LeverageType Type => LeverageType.InstantDamage;
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.FrontHemisphere;
        public override LeverageRangeType RangeType => LeverageRangeType.Melee;
        public override LeverageTargeting Targeting => LeverageTargeting.Many;
        public override string UniversalName => "Flaming axe";
        public override string RussianDisplayName => "Пылающий топор";
        public override string InstrumentalCase => "пылающим двуручным топором";

        public FlamingAxeLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
    }
}
