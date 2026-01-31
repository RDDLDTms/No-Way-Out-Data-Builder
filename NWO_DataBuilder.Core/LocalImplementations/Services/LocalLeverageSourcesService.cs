using DataBuilder.Leverages;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_Abstractions.Leverages;
using NWO_Abstractions.Leverages.LeverageData;
using NWO_Abstractions.Skills;
using NWO_DataBuilder.Core.Services;

namespace NWO_DataBuilder.Core.LocalImplementations.Services
{
    public class LocalLeverageSourcesService : ILeveragesSourcesService
    {
        public ILeveragesSource CreateLeveragesSource(ILeverage mainLeverage, ILeverage[]? additionalLeverages, string universalName, string russianName, string russianDescription, string instrumentalCase)
        {
            return new FakeLeveragesSource(mainLeverage, additionalLeverages, universalName, russianName, russianDescription, instrumentalCase);
        }

        public IUnitLeveragesSource CreateUnitLeverageSource(ILeveragesSource source, SkillPriority priority, ILeverageData mainData, ILeverageData[]? additionalData = null)
        {
            return new UnitLeveragesSource(source, priority, mainData, additionalData);
        }
    }
}
