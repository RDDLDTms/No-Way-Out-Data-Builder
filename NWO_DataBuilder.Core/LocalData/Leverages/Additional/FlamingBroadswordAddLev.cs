using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Effects;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class FlamingBroadswordAddLev : NegativeEffectApplying
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Melee;
        public override LeverageTargeting Targeting => LeverageTargeting.Single;
        public override string UniversalName => "Firing (Flaming broadsword)";
        public override string RussianDisplayName => "Горение (Пылающий палаш)";
        public override string InstrumentalCase => "горением (Пылающий палаш)";

        public FlamingBroadswordAddLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) 
        {
            Effects.Add(new TargetPeriodicDamageEffect(lClass, UniversalName, RussianDisplayName));
        }
    }
}
