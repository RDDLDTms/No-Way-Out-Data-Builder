using NWO_Abstractions.Data.Effects;

namespace NWO_DataBuilder.Core.Models.Leverages.LeverageData
{
    public class NonPeriodicEffectData : INonPeriodicEffectData
    {
        public Guid EffectId { get; }

        public Guid Id { get; }

        public Guid SenderId { get; }

        public int Cooldown { get; }

        public NonPeriodicEffectData(Guid effectId, int cooldown)
        {
            Id = effectId;
            EffectId = effectId;
            Cooldown = cooldown;
        }
    }
}
