using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;
using NWO_Abstractions.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class VoiceOfHealerAddLev : LeverageBase
    {
        public override LeverageType Type => LeverageType.PositiveEffectApplying;
        public override LeverageTargetType TargetType => LeverageTargetType.Alias;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.SpaceAroundUnit;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Place;
        public override string UniversalName => "Voice of healer echo";
        public override string RussianDisplayName => "Эхо гласа лекаря";
        public override string InstrumentalCase => "эхом гласа лекаря";

        public VoiceOfHealerAddLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
    }
}
