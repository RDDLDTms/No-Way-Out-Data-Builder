using DataBuilder.Leverages;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_Abstractions.Services;

namespace NWO_DataBuilder.Core.LocalImplementations.Services
{
    public class LocalUnitsService : IUnitsService
    {
        public IUnit CreateUnitFromData(IUnitData unitData)
        {
            IUnit unit = new Unit(unitData, Guid.NewGuid(), PercentageValues.Default());
            unit.CreateSkills();
            unit.CreateBehaviors();
            return unit;
        }
    }
}
