using NWO_Abstractions;

namespace DataBuilder.Leverages
{
    public class LeverageEffectsRemoval : ILeverageData
    {
        public double Cooldown { get; set; }

        public LeverageType Type { get; }

        public LeverageEffectsRemoval(double cooldown, LeverageType type)
        {
            Cooldown = cooldown;
            Type = type;
        }
    }
}
