using NWO_Abstractions;

namespace DataBuilder.Units
{
    public class DummySettings : IDummySettings
    {
        public bool IsImmortal { get; }

        public IPercentageValues StartPercentage { get; }

        public double MaxHealth { get; }

        public double StartHealth { get; } 

        public IEffectsLists StartEffects { get; }

        public bool IsOrganic { get; }

        public bool IsAlive { get; }

        public bool IsMech { get; }

        public DummySettings(bool isImmortal, IPercentageValues startPercentage, double maxHealth, double startHealth, IEffectsLists startEffects, bool isOrganic, bool isAlive, bool isMech)
        {
            IsImmortal = isImmortal;
            StartPercentage = startPercentage;
            MaxHealth = maxHealth;
            StartEffects = startEffects;
            IsOrganic = isOrganic;
            IsAlive = isAlive;
            IsMech = isMech;
            StartHealth = startHealth;
        }
    }
}
