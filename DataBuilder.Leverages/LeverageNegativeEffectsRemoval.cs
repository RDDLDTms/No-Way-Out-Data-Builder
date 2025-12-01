using NWO_Abstractions;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Leverages
{
    public sealed class LeverageNegativeEffectsRemoval : ILeverageWithCooldown, ITypefulLeverage
    {
        public double Cooldown { get; }
        public LeverageType Type => LeverageType.NegativeEffectRemoval;

        public LeverageNegativeEffectsRemoval(double cooldown)
        {
            Cooldown = cooldown;
        }
    }
}
