using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Effects;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class VoiceOfHealerAddLev : PositiveEffectApplying
    {
        public override LeverageType Type => LeverageType.PositiveEffectApplying;
        public override LeverageTargetType TargetType => LeverageTargetType.Alias;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.SpaceAroundUnit;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Place;
        public override string UniversalName => "Voice of healer echo";
        public override string RussianName => "Эхо гласа лекаря";
        public override string InstrumentalCase => "эхом гласа лекаря";

        public VoiceOfHealerAddLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) 
        {
            Effects.Add(new TargetPeriodicRecoveryEffect(lClass, UniversalName, RussianName));
        }
    }
}
