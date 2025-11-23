using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions;

namespace DataBuilder.Leverages
{
    public class FakeLeveragesSource : ILeveragesSource
    {
        public ILeverage MainLeverage { get; set; }

        public ILeverage? AdditionalLeverage { get; set; }

        public string UniversalName { get; private set; }

        public string InstrumentalCase { get; private set; }

        public string RussianDisplayName { get; private set; }

        public string RussianDescription { get; private set; }

        public Guid Id { get; private set; }

        public Description Description => throw new NotImplementedException();

        public FakeLeveragesSource(ILeverage mainLeverage, ILeverage? additionalLeverage, string universalName, string russianDisplayName, string russianDescription, string instrumentalCase)
        {
            Id = Guid.NewGuid();
            MainLeverage = mainLeverage;
            AdditionalLeverage = additionalLeverage;
            UniversalName = universalName;
            RussianDisplayName = russianDisplayName;
            RussianDescription = russianDescription;
            InstrumentalCase = instrumentalCase;
        }
    }
}
