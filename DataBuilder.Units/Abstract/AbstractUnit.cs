using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions;

namespace DataBuilder.Units.Abstract
{
    public abstract class AbstractUnit
    {
        public abstract AccessLevel AccessLevel { get; }
        public abstract bool IsBase { get; }
        public abstract byte ImprovmentLevel { get; }
        public abstract List<Guid> Formula { get; }
        public abstract Faction Faction { get; }
        public abstract string RussianDisplayName { get; }
        public abstract string UniversalName { get; }
        public abstract int MaxHealth { get; }
        protected abstract List<IUnitLeveragesSource> CreateUnitLeveragesSources();
        protected abstract List<IDefence> CreateUnitDefences();
        protected abstract List<IImmune> CreateUnitImmunes();
    }
}
