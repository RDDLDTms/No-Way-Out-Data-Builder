using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Effects;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class StrikeWithFireAddLev : NegativeEffectApplying
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Melee;
        public override LeverageTargeting Targeting => LeverageTargeting.Single;
        public override string UniversalName => "Firing (Strike with fire)";
        public override string RussianName => "Горение (Удар с поджёгом)";
        public override string InstrumentalCase => "горением (Удар с поджёгом)";

        public StrikeWithFireAddLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) 
        {
            Effects.Add(new TargetPeriodicDamageEffect(lClass, UniversalName, RussianName));
        }
    }
}
