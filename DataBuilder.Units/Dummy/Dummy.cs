using DataBuilder.TargetSystem;
using NWO_Abstractions;

namespace DataBuilder.Units
{
    public class Dummy : TargetBase, IDummy
    {
        public bool IsImmortal => Settings.IsImmortal;
        public IDummySettings Settings { get; }
        public Dummy(IDummySettings settings) : 
            base(settings.StartPercentage, settings.MaxHealth, settings.StartEffects, new(), new(), settings.IsAlive, settings.IsOrganic, settings.IsMech)
        {
            Settings = settings;
            Health = settings.StartHealth;
        }
    }
}
