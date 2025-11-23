using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Effects;
using NWO_Abstractions;

namespace DataBuilder.Units
{
    public class UnitBase : IUnitData
    {
        public virtual AccessLevel AccessLevel => AccessLevel.None;

        public virtual bool IsBase => false;

        public virtual bool IsMech => false;

        public virtual bool IsOrganic => false;

        public virtual bool IsAlive => false;

        public virtual byte ImprovmentLevel => 0;

        public virtual List<Guid> Formula => throw new NotImplementedException();

        public virtual Faction Faction => Faction.None;

        public virtual string RussianDisplayName => string.Empty;

        public virtual string UniversalName => string.Empty;

        public virtual double MaxHealth => 0;

        public virtual bool ImmunesCreated { get; set; } = false;

        public virtual bool DefencesCreated { get; set; } = false;

        public virtual bool LeveragesSourcesCreated { get; set; } = false;

        public virtual Guid Id => Guid.Empty;

        public virtual Description Description { get; } = new();

        public IEffectsLists StartEffects { get; } = EffectsLists.Default();

        public List<IUnitLeveragesSource> LeveragesSources => LeveragesSourcesCreated ? _leveragesSources : CreateLeveragesSources();
        public List<IImmune> Immunes => ImmunesCreated ? Immunes : CreateImmunes();
        public List<IDefence> Defences => DefencesCreated ? Defences : CreateDefences();

        protected List<IUnitLeveragesSource> _leveragesSources = new();
        protected List<IImmune> _immunes = new();
        protected List<IDefence> _defences = new();

        public virtual List<IUnitLeveragesSource> CreateLeveragesSources()
        {
            LeveragesSourcesCreated = true;
            return _leveragesSources;
        }

        public virtual List<IDefence> CreateDefences()
        {
            DefencesCreated = true;
            return _defences;
        }

        public virtual List<IImmune> CreateImmunes()
        {
            ImmunesCreated = true;
            return _immunes;
        }
    }
}
