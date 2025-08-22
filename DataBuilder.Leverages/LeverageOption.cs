using DataBuilder.BuilderObjects;
using NWO_Abstractions;

namespace DataBuilder.Leverages
{
    public class LeverageOption : ILeverageOption, IBaseBuilderObject
    {
        public string UniversalName { get; private set; }

        public string RussianDisplayName { get; private set; }

        public string RussianDescription { get; private set; }

        public Guid Id { get; private set; }

        public IDescription Description => throw new NotImplementedException();

        public LeverageOption(string russianDisplayName, string universalName, string russianDescription)
        {
            UniversalName = universalName;
            RussianDisplayName = russianDisplayName;
            RussianDescription = russianDescription;
            Id = Guid.NewGuid();
        }
    }
}
