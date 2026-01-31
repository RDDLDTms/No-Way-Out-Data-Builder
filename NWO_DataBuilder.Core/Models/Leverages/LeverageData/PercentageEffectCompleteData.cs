using NWO_Abstractions.Data.Effects;

namespace NWO_DataBuilder.Core.Models.Leverages.LeverageData
{
    public class PercentageEffectCompleteData : IPercentageEffectCompleteData
    {
        public Guid Id { get; }
        public Guid EffectId { get; }
        public Guid SenderId { get; }
        public double Percentage { get; }
        public int Cooldown { get; }
        public int Duration { get; }

        public int TimeLeft { get; }

        public PercentageEffectCompleteData(Guid effectId, Guid senderId, int cooldown, int duration, double percentage)
        {
            Id = effectId;
            EffectId = effectId;
            SenderId = senderId;
            Percentage = percentage;
            Cooldown = cooldown;
            Duration = duration;
        }
    }
}
