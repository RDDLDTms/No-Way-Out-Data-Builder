using DataBuilder.Leverages.Base;
using NWO_Abstractions.Leverages;

namespace NWO_DataBuilder.Core.Models.Leverages
{
    public class PositiveEffectRemoving : LeverageBase
    {
        public override LeverageType Type => LeverageType.PositiveEffectRemoving;
        public override LeverageTargetType TargetType => LeverageTargetType.Enemies;
        public override LeverageDuration Duration => LeverageDuration.Instant;

        public PositiveEffectRemoving(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
        public PositiveEffectRemoving(ILeverageClass lClass, params ILeverageOption[] lOptions) : base(lClass, lOptions) { }
        public PositiveEffectRemoving(ILeverageClass lClass) : base(lClass) { }
    }
}
