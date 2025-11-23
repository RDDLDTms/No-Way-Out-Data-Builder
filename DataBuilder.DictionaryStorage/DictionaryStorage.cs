using NWO_Abstractions;
using NWO_Abstractions.Services;
using Splat;

namespace NWO_DataBuilder.Core.Models
{
    public class DictionaryStorage
    {
        private static DictionaryStorage? instance;
        private DictionaryStorage()
        {
            _allUnitsData = new();
            _allLeverageClasses = new();
            _allLeverageOptions = new();
            _allLeverages = new();
            _allLeveragesSources = new();
            _allUnits = new();
        }

        public static DictionaryStorage GetInstance()
        {
            instance ??= new DictionaryStorage();
            return instance;
        }

        private Dictionary<string, IUnit> _allUnits;
        private Dictionary<string, IUnitData> _allUnitsData;
        private Dictionary<string, ILeverageClass> _allLeverageClasses;
        private Dictionary<string, ILeverageOption> _allLeverageOptions;
        private Dictionary<string, ILeverage> _allLeverages;
        private Dictionary<string, ILeveragesSource> _allLeveragesSources;

        public Dictionary<string, IUnit> AllUnits => _allUnits;
        public Dictionary<string, IUnitData> AllUnitsData => _allUnitsData;
        public Dictionary<string, ILeverageClass> AllLeverageClasses => _allLeverageClasses;
        public Dictionary<string, ILeverageOption> AllLeverageOptions => _allLeverageOptions;
        public Dictionary<string, ILeverage> AllLeverages => _allLeverages;
        public Dictionary<string, ILeveragesSource> AllLeveragesSources => _allLeveragesSources;

        /// <summary>
        /// Загрузить словари с данными
        /// </summary>
        public void LoadDictionaries()
        {
            var loader = Locator.Current.GetService<IDictionaryDataLoader>()!;

            // важен порядок загрузки!

            _allLeverageClasses = loader.LoadLeverageClasses();
            _allLeverageOptions = loader.LoadLeverageOptions();
            _allLeverages = loader.LoadLeverages();
            _allLeveragesSources = loader.LoadLeveragesSources();
            _allUnitsData = loader.LoadUnitsData();
        }

        /// <summary>
        /// Создать юнитов из данных о юнитах
        /// </summary>
        public void CreateUnitsFromData()
        {
            var unitsService = Locator.Current.GetService<IUnitsService>()!;
            foreach (var unitData in _allUnitsData)
            {
                _allUnits.Add(unitData.Key, unitsService.CreateUnitFromData(unitData.Value));
            }
        }
    }
}
