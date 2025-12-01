using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace DataBuilder.Leverages
{
    public sealed class LeverageInstantRecovery : InstantLeverageBase
    {
        public LeverageInstantRecovery(int minValue, int maxValue, double cooldown) : base(minValue, maxValue, cooldown, LeverageType.InstantRecovery)
        {
        }
    }
}
