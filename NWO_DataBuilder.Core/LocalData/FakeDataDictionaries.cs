using NWO_Abstractions;
using NWO_Abstractions.Leverages;
using NWO_Abstractions.Services;

namespace NWO_DataBuilder.Core.Tests
{
    public class FakeDataDictionaries : IDictionaryDataLoader
    {
        Dictionary<string, IUnitData> _allUnits;
        Dictionary<string, ILeverageClass> _allLeverageClasses;
        Dictionary<string, ILeverageOption> _allLeverageOptions;
        Dictionary<string, ILeverage> _allLeverages;
        Dictionary<string, ILeveragesSource> _allLeveragesSources;

        public FakeDataDictionaries()
        {
            _allUnits = new Dictionary<string, IUnitData>();
            _allLeverageClasses = new Dictionary<string, ILeverageClass>();
            _allLeverageOptions = new Dictionary<string, ILeverageOption>();
            _allLeverages = new Dictionary<string, ILeverage>();
            _allLeveragesSources = new Dictionary<string, ILeveragesSource>();
        }

        public Dictionary<string, IUnitData> LoadUnitsData() => _allUnits.Any() ? _allUnits : FakeDataUnitsFactory.CreateUnitsData();

        public Dictionary<string, ILeverageClass> LoadLeverageClasses() => _allLeverageClasses.Any() ? _allLeverageClasses : FakeDataLeverageClassesFactory.CreateLeverageClasses();

        public Dictionary<string, ILeverageOption> LoadLeverageOptions() => _allLeverageOptions.Any() ? _allLeverageOptions : FakeDataLeverageOptionsFactory.CreateLeverageOptions();

        public Dictionary<string, ILeverage> LoadLeverages() => _allLeverages.Any() ? _allLeverages : FakeDataLeverageFactory.CreateLeverages();

        public Dictionary<string, ILeveragesSource> LoadLeveragesSources() => _allLeveragesSources.Any() ? _allLeveragesSources : FakeDataLeverageSourcesFactory.CreateLeverageSources();
    }
}
