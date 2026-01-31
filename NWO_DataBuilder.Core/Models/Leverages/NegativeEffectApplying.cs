using DataBuilder.Leverages.Base;
using NWO_Abstractions.Leverages;

namespace NWO_DataBuilder.Core.Models.Leverages
{
    public class NegativeEffectApplying : LeverageBase
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageDuration Duration => LeverageDuration.Instant;

        public NegativeEffectApplying(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
        public NegativeEffectApplying(ILeverageClass lClass, params ILeverageOption[] lOptions) : base(lClass, lOptions) { }
        public NegativeEffectApplying(ILeverageClass lClass) : base(lClass) { }
    }
}
