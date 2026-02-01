using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Effects.ControlEffects;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class WordOfPreacherLev : NegativeEffectApplying
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Place;
        public override string UniversalName => "Word of preacher";
        public override string RussianName => "Слово проповедника";
        public override string InstrumentalCase => "словом проповедника";

        public WordOfPreacherLev(ILeverageClass lClass, params ILeverageOption[] lOptions) : base(lClass, lOptions) 
        {
            Effects.Add(new TargetControlEffectWithDuration(lClass, UniversalName, RussianName));
        }
    }
}
