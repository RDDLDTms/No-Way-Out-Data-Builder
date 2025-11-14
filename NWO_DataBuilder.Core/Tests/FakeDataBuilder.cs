using DataBuilder.Units;
using NWO_Abstractions;
using NWO_Abstractions.Services;
using NWO_DataBuilder.Core.Services;
using NWO_DataBuilder.Core.Tests.Units;
using Splat;

namespace NWO_DataBuilder.Core.Tests
{
    public class FakeDataBuilder : IDictionaryDataLoader
    {
        Dictionary<string, IUnit> _allUnits;
        Dictionary<string, ILeverageClass> _allLeverageClasses;
        Dictionary<string, ILeverageOption> _allLeverageOptions;
        Dictionary<string, ILeverage> _allLeverages;
        Dictionary<string, ILeveragesSource> _allLeveragesSources;

        IUnitsService _unitsService;
        ILeverageService _leverageService;
        ILeveragesSourcesService _leveragesSourcesService;

        public FakeDataBuilder()
        {
            _allUnits = new Dictionary<string, IUnit>();
            _allLeverageClasses = new Dictionary<string, ILeverageClass>();
            _allLeverageOptions = new Dictionary<string, ILeverageOption>();
            _allLeverages = new Dictionary<string, ILeverage>();
            _allLeveragesSources = new Dictionary<string, ILeveragesSource>();

            _unitsService = Locator.Current.GetService<IUnitsService>()!;
            _leverageService = Locator.Current.GetService<ILeverageService>()!;
            _leveragesSourcesService = Locator.Current.GetService<ILeveragesSourcesService>()!;
        }

        #region Units
        public Dictionary<string, IUnit> LoadUnits()
        {
            var units = new List<UnitBase>()
            {
                new Monk(),
                new Rager(),
                new Preacher(),
                new ChaosSower(),
                new Executor(),
                new Caller()
            };

            foreach (var unit in units)
            {
                if (_allUnits.GetValueOrDefault(unit.UniversalName) is null)
                    _allUnits.Add(unit.UniversalName, _unitsService.CreateNewUnit(unit));
            }

            return _allUnits;
        }

        #endregion

        public Dictionary<string, ILeverageClass> LoadLeverageClasses() => _allLeverageClasses.Any() ? _allLeverageClasses : FakeDataLeverageClassesFactory.CreateLeverageClasses();

        public Dictionary<string, ILeverageOption> LoadLeverageOptions() => _allLeverageOptions.Any() ? _allLeverageOptions : FakeDataLeverageOptionsFactory.CreateLeverageOptions();

        public Dictionary<string, ILeverage> LoadLeverages() => _allLeverages.Any() ? _allLeverages : FakeDataLeverageFactory.CreateLeverages();

        public Dictionary<string, ILeveragesSource> LoadLeveragesSources() => _allLeveragesSources.Any() ? _allLeveragesSources : FakeDataLeverageSourcesFactory.CreateLeverageSources();
    }
}
