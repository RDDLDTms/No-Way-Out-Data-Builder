using NWO_Abstractions.Leverages.LeverageData;

namespace NWO_DataBuilder.Core.Models.Leverages.LeverageData
{
    public class EffectRemovalData : IEffectRemovingData
    {
        public Guid Id { get; }

        public int Cooldown { get; }

        public EffectRemovalData(Guid id, int cooldown)
        {
            Id = id;
            Cooldown = cooldown;
        }
    }
}
