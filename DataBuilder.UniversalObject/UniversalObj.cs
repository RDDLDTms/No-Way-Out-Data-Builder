using DataBuilder.BuilderObjects;
using NWO_Abstractions;

namespace DataBuilder.UniversalObject
{
    public class UniversalObj : IUniversalObject
    {
        public virtual List<IEffect> PositiveEffects => new();
        public virtual List<IEffect> NegativeEffects => new();
        public virtual bool IsOrganic { get; set; } = false;
        public virtual bool IsAlive { get; set; } = false;
        public virtual bool IsMech { get; set; } = false;

        public List<IImmune> Immunes => new();
        public List<IDefence> Defences => new();
        public List<IUnitLeveragesSource> LeveragesSources => new();

        public virtual double Health { get; set; } = 0;
        public virtual double MaxHealth { get; set; } = 0;
        public double HealthPercent => Math.Round(Health / MaxHealth, 2);

        public virtual bool CanIncreaseHealth { get; } = false;
        public virtual bool CanDecreaseHealth { get; } = false;

        public virtual string UniversalName => string.Empty;

        public virtual string RussianDisplayName => string.Empty;

        public virtual Description Description => new();

        public virtual Guid Id => Guid.Empty;

        public bool LeveragesSourcesCreated { get; set; } = false;
        public bool DefencesCreated { get; set; } = false;
        public bool ImmunesCreated { get; set; } = false;

        public virtual List<IDefence> CreateDefences()
        {
            DefencesCreated = true;
            return new();
        }

        public virtual List<IImmune> CreateImmunes()
        {
            ImmunesCreated = true;
            return new();
        }

        public virtual List<IUnitLeveragesSource> CreateLeveragesSources()
        {
            LeveragesSourcesCreated = true;
            return new();
        }

        public double DecreaseHealth(double value)
        {
            Health = Health - value < 0 ? 0 : Health - value;
            return Health;
        }

        public double IncreaseHealth(double value)
        {
            Health = Health + value > MaxHealth ? MaxHealth : Health + value;
            return Health;
        }
    }
}
