using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Leverages
{
    public class LeverageOption : ILeverageOption, IBaseBuilderObject
    {
        public string UniversalName { get; private set; }

        public string RussianName { get; private set; }

        public string DisplayName { get; private set; }

        public Guid StorageId { get; private set; }

        public Description Description => new();

        public LeverageOption(string russianName, string universalName)
        {
            UniversalName = universalName;
            RussianName = russianName;
            DisplayName = russianName;
            StorageId = Guid.NewGuid();
        }
    }
}
