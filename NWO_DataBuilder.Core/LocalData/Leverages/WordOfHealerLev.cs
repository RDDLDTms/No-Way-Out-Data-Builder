using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class WordOfHealerLev : InstantRecovery
    {
        public override LeverageTargetType TargetType => LeverageTargetType.Alias;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Single;
        public override string UniversalName => "Word of healer";
        public override string RussianName => "Слово лекаря";
        public override string InstrumentalCase => "словом лекаря";

        public WordOfHealerLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption)
        {

        }
    }
}
