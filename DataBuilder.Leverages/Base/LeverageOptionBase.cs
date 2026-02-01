using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Leverages.Base
{
    public class LeverageOptionBase : ILeverageOption
    {
        public virtual string UniversalName => string.Empty;

        public virtual string RussianName => string.Empty;

        public virtual string DisplayName => string.Empty;

        public virtual Description Description => new();

        public virtual Guid StorageId => Guid.Empty;
    }
}
