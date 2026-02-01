using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.TargetSystem;
using NWO_Abstractions;

namespace DataBuilder.Units
{
    public class Dummy : TargetBase, IDummy, IBaseBuilderObject
    {
        public bool IsImmortal => Settings.IsImmortal;
        public IDummySettings Settings { get; }

        public string UniversalName => "Dummy";

        public string RussianName => "Манекен";

        public string DisplayName => "Манекен";

        public Description Description => new();

        public Guid StorageId => new();

        public Dummy(IDummySettings settings) : 
            base(settings.StartPercentage, settings.MaxHealth, settings.StartEffects, new(), new(), settings.IsAlive, settings.IsOrganic, settings.IsMech)
        {
            Settings = settings;
            Health = settings.StartHealth;
        }
    }
}
