using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Effects;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class FlamingAxeAddLev : NegativeEffectApplying
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.FrontHemisphere;
        public override LeverageRangeType RangeType => LeverageRangeType.Melee;
        public override LeverageTargeting Targeting => LeverageTargeting.Many;
        public override string UniversalName => "Firing (Flaming axe)";
        public override string RussianName => "Горение (Пылающий топор)";
        public override string InstrumentalCase => "горением (Пылающий топор)";

        public FlamingAxeAddLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) 
        {
            Effects.Add(new TargetPeriodicDamageEffect(lClass, UniversalName, RussianName));
        }
    }
}
