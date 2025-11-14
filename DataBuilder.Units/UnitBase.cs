using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Units.Abstract;
using NWO_Abstractions;

namespace DataBuilder.Units
{
    public class UnitBase : AbstractUnit
    {
        public override AccessLevel AccessLevel => AccessLevel.None;

        public override bool IsBase => false;

        public override byte ImprovmentLevel => 0;

        public override List<Guid> Formula => throw new NotImplementedException();

        public override Faction Faction => Faction.None;

        public override string RussianDisplayName => string.Empty;

        public override string UniversalName => string.Empty;

        public override int MaxHealth => 0;

        protected bool ImmunesCreated { get; set; } = false;

        protected bool DefencesCreated { get; set; } = false;

        protected bool LeveragesSourcesCreated { get; set; } = false;

        public List<IUnitLeveragesSource> LeveragesSources => LeveragesSourcesCreated ? LeveragesSources : CreateUnitLeveragesSources();
        public List<IImmune> Immunes => ImmunesCreated ? Immunes : CreateUnitImmunes();
        public List<IDefence> Defences => DefencesCreated ? Defences : CreateUnitDefences();

        protected override List<IUnitLeveragesSource> CreateUnitLeveragesSources()
        {
            LeveragesSourcesCreated = true;
            return new();
        }

        protected override List<IDefence> CreateUnitDefences()
        {
            DefencesCreated = true;
            return new();
        }

        protected override List<IImmune> CreateUnitImmunes()
        {
            ImmunesCreated = true;
            return new();
        }
    }
}
