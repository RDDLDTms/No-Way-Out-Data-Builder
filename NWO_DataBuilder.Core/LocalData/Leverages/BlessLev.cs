using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Effects;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class BlessLev : PositiveEffectApplying
    {
        public override LeverageType Type => LeverageType.PositiveEffectApplying;
        public override LeverageTargetType TargetType => LeverageTargetType.Alias;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Single;
        public override string UniversalName => "Bless";
        public override string RussianName => "Благословение";
        public override string InstrumentalCase => "благословением";

        public BlessLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) 
        {
            Effects.Add(new TargetPeriodicRecoveryEffect(lClass, UniversalName, RussianName));
        }
    }
}
