using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class StrikeWithFireAddLev : LeverageBase
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Melee;
        public override LeverageTargeting Targeting => LeverageTargeting.Single;
        public override string UniversalName => "(Firing) Strike with fire";
        public override string RussianDisplayName => "Горение (Удар с поджёгом)";

        public StrikeWithFireAddLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
    }
}
