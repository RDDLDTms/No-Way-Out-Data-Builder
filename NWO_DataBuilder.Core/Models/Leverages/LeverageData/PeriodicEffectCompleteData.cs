using NWO_Abstractions.Data.Effects;

namespace NWO_DataBuilder.Core.Models.Leverages.LeverageData
{
    public class PeriodicEffectCompleteData : IPeriodicEffectCompleteData
    {
        public Guid Id { get; }

        public Guid EffectId { get; }

        public Guid SenderId { get; }

        public int Cooldown { get; }

        public int Duration { get; }

        public int TimeLeft { get; }

        public int MinValue { get; }

        public int MaxValue { get; }

        public int StartDelay { get; }

        public int DefaultDelay { get; }

        public double StoredIncomingAdditionalPercentage { get; set; } = 0;

        public PeriodicEffectCompleteData(Guid effectId, Guid senderId, int cooldown, int duration, int minValue, int maxValue, int defaultDelay, int startDelay)
        {
            Id = EffectId;
            EffectId = effectId;
            SenderId = senderId;
            Cooldown = cooldown;
            Duration = duration;
            MinValue = minValue;
            MaxValue = maxValue;
            DefaultDelay = defaultDelay;
            StartDelay = startDelay;
        }
    }
}
