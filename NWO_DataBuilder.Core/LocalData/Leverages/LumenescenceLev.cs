using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions.Leverages;

namespace NWO_DataBuilder.Core.LocalData.Leverages
{
    public class LumenescenceLev : LeverageBase
    {
        public override LeverageType Type => LeverageType.Damage;
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageHitPoint HitPoint => LeverageHitPoint.SpaceAroundUnit;
        public override LeverageRangeType RangeType => LeverageRangeType.Range;
        public override LeverageTargeting Targeting => LeverageTargeting.Many;
        public override string UniversalName => "Lumenescence";
        public override string RussianName => "Люминесценция";
        public override string InstrumentalCase => "люминесценцией";

        public LumenescenceLev(ILeverageClass lClass) : base(lClass) { }
    }
}
