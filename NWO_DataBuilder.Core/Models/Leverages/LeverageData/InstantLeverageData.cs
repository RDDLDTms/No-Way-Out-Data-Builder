using NWO_Abstractions.Leverages.LeverageData;

namespace NWO_DataBuilder.Core.Models.Leverages.LeverageData
{
    internal class InstantLeverageData : IInstantLeverageData
    {
        public Guid Id { get; }

        public int Cooldown { get; }

        public int MinValue { get; }

        public int MaxValue { get; }

        public InstantLeverageData(Guid id, int minValue, int maxValue, int cooldown)
        {
            Id = id;
            MinValue = minValue;
            MaxValue = maxValue;
            Cooldown = cooldown;
        }
    }
}
