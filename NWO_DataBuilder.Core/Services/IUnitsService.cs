using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Units;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.Services
{
    public interface IUnitsService
    {
        public IUnit CreateNewUnit(string internationalName, string russianDisplayName, bool isBase, Faction faction, AccessLevel acceessLevel,
            byte improvementLevel, List<Guid> formula, List<IUnitLeveragesSource> leverageSources, List<IImmune> immunes, List<IDefence> defences, int startHealth, int maxHealth, IPercentageValues incomingPercentageValues);

        public IUnit CreateNewUnit(UnitBase absrtarctUnit);

        public IUnit AddUnitDefences(List<IDefence> defencesToAdd, IUnit unit);

        public IUnit AddUnitImmunes(List<IImmune> defencesToAdd, IUnit unit);
            
        public IUnit AddUnitLeverageSources(List<IUnitLeveragesSource> unitLeveragesSources, IUnit unit);
    }
}
