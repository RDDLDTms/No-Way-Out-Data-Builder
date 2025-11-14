using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Units;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.Services
{
    public class UnitsService : IUnitsService
    {
        public IUnit CreateNewUnit(string internationalName, string russianDisplayName, bool isBase, Faction faction, AccessLevel acceessLevel, 
            byte improvementLevel, List<Guid> formula, List<IUnitLeveragesSource> leverageSources, List<IImmune> immunes, List<IDefence> defences, int startHealth, int maxHealth, IPercentageValues incomingPercentageValues)
        {
            formula = new();
            return new Unit(internationalName, russianDisplayName, isBase, faction, acceessLevel, improvementLevel, formula, leverageSources, immunes, defences, startHealth, maxHealth, incomingPercentageValues);
        }

        public IUnit CreateNewUnit(UnitBase unitDTO) => new Unit(unitDTO);

        public IUnit AddUnitDefences(List<IDefence> defencesToAdd, IUnit unit)
        {
            unit.Defences.AddRange(defencesToAdd);
            return unit;
        }

        public IUnit AddUnitImmunes(List<IImmune> defencesToAdd, IUnit unit)
        {
            unit.Immunes.AddRange(defencesToAdd);
            return unit;
        }

        public IUnit AddUnitLeverageSources(List<IUnitLeveragesSource> unitLeveragesSources, IUnit unit)
        {
            unit.LeveragesSources.AddRange(unitLeveragesSources);
            return unit;
        }
    }
}
