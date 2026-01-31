using DataBuilder.Leverages.Base;
using NWO_Abstractions.Leverages;

namespace NWO_DataBuilder.Core.Models.Leverages
{
    public class NegativeEffectRemoving : LeverageBase
    {
        public override LeverageType Type => LeverageType.NegativeEffectRemoving;
        public override LeverageTargetType TargetType => LeverageTargetType.Alias;
        public override LeverageDuration Duration => LeverageDuration.Instant;

        public NegativeEffectRemoving(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
        public NegativeEffectRemoving(ILeverageClass lClass, params ILeverageOption[] lOptions) : base(lClass, lOptions) { }
        public NegativeEffectRemoving(ILeverageClass lClass) : base(lClass) { }
    }
}
