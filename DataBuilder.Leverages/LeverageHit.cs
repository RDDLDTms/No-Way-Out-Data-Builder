using NWO_Abstractions;

namespace DataBuilder.Leverages
{
    public class LeverageHit : ILeverageValues, ILeverageData
    {
        public int MinValue { get; private set; }

        public int MaxValue { get; private set; }

        public double Cooldown { get; set; }

        public LeverageType Type { get; }

        public LeverageHit(int minValue, int maxValue, double cooldown, LeverageType type) 
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
