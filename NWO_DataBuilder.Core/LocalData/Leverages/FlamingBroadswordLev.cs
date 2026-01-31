using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class FlamingBroadswordLev : InstantDamage
    {
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Melee;
        public override LeverageTargeting Targeting => LeverageTargeting.Single;
        public override string UniversalName => "Flaming broadsword";
        public override string RussianDisplayName => "Пылающий палаш";
        public override string InstrumentalCase => "пылающим палашом";

        public FlamingBroadswordLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
    }
}
