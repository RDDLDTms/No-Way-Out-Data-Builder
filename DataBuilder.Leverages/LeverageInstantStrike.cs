using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace DataBuilder.Leverages
{
    public sealed class LeverageInstantStrike : InstantLeverageBase
    {
        public LeverageInstantStrike(int minValue, int maxValue, double cooldown) : base(minValue, maxValue, cooldown, LeverageType.InstantDamage)
        { 
        }
    }
}
