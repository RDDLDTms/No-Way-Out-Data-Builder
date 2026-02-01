using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Leverages
{
    public class FakeLeveragesSource : ILeveragesSource
    {
        public ILeverage MainLeverage { get; set; }

        public ILeverage[]? AdditionalLeverages { get; set; }

        public string UniversalName { get; private set; }

        public string InstrumentalCase { get; private set; }

        public string DisplayName { get; private set; }

        public string RussianName { get; private set; }

        public string RussianDescription { get; private set; }

        public Guid StorageId { get; private set; }

        public Description Description => throw new NotImplementedException();

        public FakeLeveragesSource(ILeverage mainLeverage, ILeverage[]? additionalLeverages, string universalName, string russianName, string russianDescription, string instrumentalCase)
        {
            StorageId = Guid.NewGuid();
            MainLeverage = mainLeverage;
            AdditionalLeverages = additionalLeverages;
            UniversalName = universalName;
            RussianName = russianName;
            RussianDescription = russianDescription;
            InstrumentalCase = instrumentalCase;
        }
    }
}
