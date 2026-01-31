using DataBuilder.Leverages.Base;
using NWO_Abstractions.Leverages;

namespace NWO_DataBuilder.Core.Models.Leverages
{
    public class PositiveEffectApplying : LeverageBase
    {
        public override LeverageType Type => LeverageType.PositiveEffectApplying;
        public override LeverageTargetType TargetType => LeverageTargetType.Alias;
        public override LeverageDuration Duration => LeverageDuration.Instant;

        public PositiveEffectApplying(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
        public PositiveEffectApplying(ILeverageClass lClass, params ILeverageOption[] lOptions) : base(lClass, lOptions) { }
        public PositiveEffectApplying(ILeverageClass lClass) : base(lClass) { }
    }
}
