using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.Tests.Leverages
{
    public class FlamingBroadswordAddLev : LeverageBase
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Melee;
        public override LeverageTargeting Targeting => LeverageTargeting.Single;
        public override string UniversalName => "Firing (Flaming broadsword)";
        public override string RussianDisplayName => "Горение (Пылающий палаш)";

        public FlamingBroadswordAddLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
    }
}
