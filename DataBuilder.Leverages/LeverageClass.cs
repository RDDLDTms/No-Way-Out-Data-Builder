using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Leverages
{
    public class LeverageClass : ILeverageClass
    {
        public LeverageType Type { get; }
        
        public string UniversalName { get; }

        public string RussianDescription { get; }

        public string RussianName { get; }

        public string DisplayName { get; }

        public string Color { get; }

        public Guid StorageId { get; }

        public string Genitive { get; }

        public Description Description => throw new NotImplementedException();

        public LeverageClassRestrictions Restrictions { get; }

        public LeverageClass(string universalName, string russianName, string color, string genitive, LeverageType type, LeverageClassRestrictions restrictions)
        {
            UniversalName = universalName;
            RussianName = russianName;
            Color = color;
            Genitive = genitive;
            StorageId = Guid.NewGuid();
            Type = type;
            Restrictions = restrictions;
        }
    }
}
