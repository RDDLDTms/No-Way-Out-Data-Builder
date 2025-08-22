using DataBuilder.Leverages;
using DataBuilder.Units;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.Services
{
    public class LeverageSourcesService : ILeveragesSourcesService
    {
        public ILeveragesSource CreateLeveragesSource(ILeverage mainLeverage, ILeverage? additionalLeverage, string universalName, string russianName, string russianDescription, string instrumentalCase)
        {
            return new FakeLeveragesSource(mainLeverage, additionalLeverage, universalName, russianName, russianDescription, instrumentalCase);
        }

        public IUnitLeveragesSource CreateUnitLeverageSource(ILeveragesSource source, LeveragesPriority priority, ILeverageData mainData, ILeverageData? additionalData = null)
        {
            return new UnitLeveragesSource(source, priority, mainData, additionalData);
        }
    }
}
