using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;
using NWO_Abstractions.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
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
        public override string InstrumentalCase => "горением (Пылающий палащ)";

        public FlamingBroadswordAddLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
    }
}
