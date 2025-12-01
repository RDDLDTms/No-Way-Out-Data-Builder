using NWO_Abstractions;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Leverages.Base
{
    public class InstantLeverageBase : IInstantLeverage
    {
        public int MinValue { get; }

        public int MaxValue { get; }

        public double Cooldown { get; }

        public LeverageType Type { get; }

        public InstantLeverageBase(int minValue, int maxValue, double cooldown, LeverageType type) 
        { 
            MinValue = minValue;
            MaxValue = maxValue;
            Cooldown = cooldown;
            Type = type;
        }

        public int GetValue()
        {
            return Random.Shared.Next(MinValue, MaxValue + 1);
        }
    }
}
