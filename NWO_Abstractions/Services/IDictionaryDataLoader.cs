using NWO_Abstractions.Leverages;

namespace NWO_Abstractions.Services
{
    public interface IDictionaryDataLoader
    {
        public Dictionary<string, IUnitData> LoadUnitsData();

        public Dictionary<string, ILeverageClass> LoadLeverageClasses();

        public Dictionary<string, ILeverageOption> LoadLeverageOptions();

        public Dictionary<string, ILeverage> LoadLeverages();

        public Dictionary<string, ILeveragesSource> LoadLeveragesSources();
    }
}
