using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Effects.PercentageEffects;
using NWO_Abstractions.Effects;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class DefenceLev : PositiveEffectApplying
    {
        public override LeverageType Type => LeverageType.PositiveEffectApplying;
        public override LeverageTargetType TargetType => LeverageTargetType.Alias;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Single;
        public override string UniversalName => "Defence";
        public override string RussianName => "Защита";
        public override string InstrumentalCase => "защитой";

        public DefenceLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption)
        {
            Effects.Add(new IncreaseEffectWithDuration(EffectType.Positive, lClass, UniversalName, RussianName));
        }
    }
}
