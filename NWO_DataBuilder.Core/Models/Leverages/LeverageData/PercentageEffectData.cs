using NWO_Abstractions.Data.Effects;

namespace NWO_DataBuilder.Core.Models.Leverages.LeverageData
{
    public class PercentageEffectData : IPercentageEffectData
    {
        public Guid Id { get; }
        public Guid EffectId { get; }
        public Guid SenderId { get; }
        public double Percentage { get; }

        public PercentageEffectData(Guid effectId, double percentage)
        {
            Id = effectId;
            EffectId = effectId;
            Percentage = percentage;
        }
    }
}
