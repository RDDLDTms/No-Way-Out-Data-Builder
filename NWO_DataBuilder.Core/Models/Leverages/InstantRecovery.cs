using DataBuilder.Leverages.Base;
using NWO_Abstractions.Leverages;

namespace NWO_DataBuilder.Core.Models.Leverages
{
    public class InstantRecovery : LeverageBase
    {
        public override LeverageType Type => LeverageType.Recovery;
        public override LeverageTargetType TargetType => LeverageTargetType.Alias;
        public override LeverageDuration Duration => LeverageDuration.Instant;

        public InstantRecovery(ILeverageClass lClass, ILeverageOption lOption) : base(lClass, lOption) { }
        public InstantRecovery(ILeverageClass lClass, params ILeverageOption[] lOptions) : base(lClass, lOptions) { }
        public InstantRecovery(ILeverageClass lClass) : base(lClass) { }
    }
}
