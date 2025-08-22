using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions;

namespace DataBuilder.Leverages
{
    public class LeverageClass : ILeverageClass
    {
        public LeverageType Type { get; }
        
        public string UniversalName { get; }

        public string RussianDescription { get; }

        public string RussianDisplayName { get; }

        public string Color { get; }

        public Guid Id { get; }

        public string Genitive { get; }

        public IDescription Description => throw new NotImplementedException();

        public LeverageClassRestrictions Restrictions { get; }

        public LeverageClass(string universalName, string russianDisplayName, string color, string genitive, LeverageType type, LeverageClassRestrictions restrictions)
        {
            UniversalName = universalName;
            RussianDisplayName = russianDisplayName;
            Color = color;
            Genitive = genitive;
            Id = Guid.NewGuid();
            Type = type;
            Restrictions = restrictions;
        }
    }
}
