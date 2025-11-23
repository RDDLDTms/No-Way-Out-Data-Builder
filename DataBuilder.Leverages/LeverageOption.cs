using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions;

namespace DataBuilder.Leverages
{
    public class LeverageOption : ILeverageOption, IBaseBuilderObject
    {
        public string UniversalName { get; private set; }

        public string RussianDisplayName { get; private set; }

        public string RussianDescription { get; private set; }

        public Guid Id { get; private set; }

        public Description Description => new();

        public LeverageOption(string russianDisplayName, string universalName, string russianDescription)
        {
            UniversalName = universalName;
            RussianDisplayName = russianDisplayName;
            RussianDescription = russianDescription;
            Id = Guid.NewGuid();
        }
    }
}
