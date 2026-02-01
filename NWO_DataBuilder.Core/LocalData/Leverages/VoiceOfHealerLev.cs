using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class VoiceOfHealerLev : InstantRecovery
    {
        public override LeverageTargetType TargetType => LeverageTargetType.Alias;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Single;
        public override string UniversalName => "Voice of healer";
        public override string RussianName => "Глас лекаря";
        public override string InstrumentalCase => "гласом лекаря";

        public VoiceOfHealerLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
    }
}
