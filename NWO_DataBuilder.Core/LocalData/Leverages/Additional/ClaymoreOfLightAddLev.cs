using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class ClaymoreOfLightAddLev : InstantDamage
    {
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.Vision;
        public override LeverageRangeType RangeType => LeverageRangeType.Melee;
        public override LeverageTargeting Targeting => LeverageTargeting.Single;
        public override string UniversalName => "Claymore of light";
        public override string RussianDisplayName => "Клеймор света";
        public override string InstrumentalCase => "cветовым ожогом";

        public ClaymoreOfLightAddLev(ILeverageClass lClass) : base(lClass) { }
    }
}
