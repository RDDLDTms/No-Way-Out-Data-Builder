using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.Tests.Leverages
{
    public class WordOfHealerLev : LeverageBase
    {
        public override LeverageType Type => LeverageType.Recovery;
        public override LeverageTargetType TargetType => LeverageTargetType.Alias;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Single;
        public override string UniversalName => "Word of healer";
        public override string RussianDisplayName => "Слово лекаря";

        public WordOfHealerLev(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
    }
}
