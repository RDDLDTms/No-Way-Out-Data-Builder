using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Leverages.Base
{
    public class LeverageOptionBase : ILeverageOption
    {
        public virtual string UniversalName => string.Empty;

        public virtual string RussianDisplayName => string.Empty;

        public virtual Description Description => new();

        public virtual Guid Id => Guid.Empty;
    }
}
