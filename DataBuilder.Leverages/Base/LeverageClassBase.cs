using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Leverages.Base
{
    public class LeverageClassBase : ILeverageClass
    {
        public virtual string Color => string.Empty;

        public virtual string Genitive => string.Empty;

        public virtual LeverageClassRestrictions Restrictions => LeverageClassRestrictions.NoRestrictions;

        public virtual string UniversalName => string.Empty;

        public virtual string RussianName => string.Empty;

        public string DisplayName { get; } = string.Empty;

        public virtual Description Description => new();

        public virtual Guid StorageId => Guid.Empty;
    }
}
