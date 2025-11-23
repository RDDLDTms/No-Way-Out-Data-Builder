using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.Tests.Leverages
{
    public class VoiceOfHealerLev : LeverageBase
    {
        public override LeverageType Type => LeverageType.Recovery;
        public override LeverageTargetType TargetType => LeverageTargetType.Alias;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Single;
        public override string UniversalName => "Voice of healer";
        public override string RussianDisplayName => "Глас лекаря";

        public VoiceOfHealerLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
    }
}
