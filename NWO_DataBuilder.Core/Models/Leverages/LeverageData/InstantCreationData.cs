using NWO_Abstractions.Leverages.LeverageData;

namespace NWO_DataBuilder.Core.Models.Leverages.LeverageData
{
    public class InstantCreationData : IInstantCreationData
    {
        public Guid Id { get; }

        public int Cooldown { get; }

        public int Duration { get; }

        public int TimeLeft { get; }

        public InstantCreationData(Guid id, int cooldown, int duration)
        {
            Id = id;
            Cooldown = cooldown;
            Duration = duration;
        }
    }
}
