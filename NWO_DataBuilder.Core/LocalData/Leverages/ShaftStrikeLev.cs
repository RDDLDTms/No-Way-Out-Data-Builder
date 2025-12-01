using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;
using NWO_Abstractions.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class ShaftStrikeLev : LeverageBase
    {
        public override LeverageType Type => LeverageType.InstantDamage;
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Melee;
        public override LeverageTargeting Targeting => LeverageTargeting.Single;
        public override string UniversalName => "Shaft strike";
        public override string RussianDisplayName => "Удар древком";
        public override string InstrumentalCase => "ударом древка топора";

        public ShaftStrikeLev(ILeverageClass lClass) : base(lClass) { }
    }
}
