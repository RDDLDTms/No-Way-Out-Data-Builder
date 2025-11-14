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
            _allUnits = new();
        }

        public static DictionaryStorage GetInstance()
        {
            instance ??= new DictionaryStorage();
            return instance;
        }

        private Dictionary<string, IUnit> _allUnits;
        private Dictionary<string, ILeverageClass> _allLeverageClasses;
        private Dictionary<string, ILeverageOption> _allLeverageOptions;
        private Dictionary<string, ILeverage> _allLeverages;
        private Dictionary<string, ILeveragesSource> _allLeveragesSources;

        public Dictionary<string, IUnit> AllUnits => _allUnits;
        public Dictionary<string, ILeverageClass> AllLeverageClasses => _allLeverageClasses;
        public Dictionary<string, ILeverageOption> AllLeverageOptions => _allLeverageOptions;
        public Dictionary<string, ILeverage> AllLeverages => _allLeverages;
        public Dictionary<string, ILeveragesSource> AllLeveragesSources => _allLeveragesSources;
        public void LoadDictionaries()
        {
            var loader = Locator.Current.GetService<IDictionaryDataLoader>()!;

            // важен порядок загрузки!

            _allLeverageClasses = loader.LoadLeverageClasses();
            _allLeverageOptions = loader.LoadLeverageOptions();
            _allLeverages = loader.LoadLeverages();
            _allLeveragesSources = loader.LoadLeveragesSources();
            _allUnits = loader.LoadUnits();
        }
    }
}
