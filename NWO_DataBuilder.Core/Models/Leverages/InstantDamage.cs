using DataBuilder.Leverages.Base;
using NWO_Abstractions.Leverages;

namespace NWO_DataBuilder.Core.Models.Leverages
{
    public class InstantDamage : LeverageBase
    {
        public override LeverageType Type => LeverageType.Damage;
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageDuration Duration => LeverageDuration.Instant;

        public InstantDamage(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
        public InstantDamage(ILeverageClass lClass, params ILeverageOption[] lOptions) : base(lClass, lOptions) { }
        public InstantDamage(ILeverageClass lClass) : base(lClass) { }
    }
}
