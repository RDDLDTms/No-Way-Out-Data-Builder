using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions;

namespace DataBuilder.Leverages.Base
{
    public class LeverageClassBase : ILeverageClass
    {
        public virtual string Color => string.Empty;

        public virtual string Genitive => string.Empty;

        public virtual LeverageClassRestrictions Restrictions => LeverageClassRestrictions.NoRestrictions;

        public virtual string UniversalName => string.Empty;

        public virtual string RussianDisplayName => string.Empty;

        public virtual Description Description => new();

        public virtual Guid Id => Guid.Empty;
    }
}
