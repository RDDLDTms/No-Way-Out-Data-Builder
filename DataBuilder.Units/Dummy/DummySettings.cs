using DataBuilder.Effects;
using DataBuilder.Leverages;
using NWO_Abstractions;
using NWO_Abstractions.Enums;

namespace DataBuilder.Units
{
    public class DummySettings : IDummySettings
    {
        public bool IsImmortal { get; set; } = false;
        public bool IsOrganic { get; set; } = true;
        public bool IsAlive { get; set; } = true;
        public bool IsMech { get; set; } = false;
        public double MaxHealth { get; set; } = 1000;
        public double StartHealth { get; set; } = 1000;
        public IPercentageValues StartPercentage { get; set; } = new PercentageValues(PercentageValuesType.Incoming);
        public IEffectsLists StartEffects => EffectsLists.Default();
    }
}
