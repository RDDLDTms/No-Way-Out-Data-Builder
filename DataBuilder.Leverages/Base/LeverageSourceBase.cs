using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions;

namespace DataBuilder.Leverages.Base
{
    public class LeverageSourceBase : ILeveragesSource
    {
        public ILeverage MainLeverage { get; }
        public ILeverage? AdditionalLeverage { get; }
        public virtual string InstrumentalCase { get; private set; } = string.Empty;
        public virtual string UniversalName { get; private set; } = string.Empty;
        public virtual string RussianDisplayName { get; private set; } = string.Empty;
        public virtual Description Description => new();
        public virtual Guid Id => Guid.Empty;

        public LeverageSourceBase(ILeverage mainLeverage, ILeverage? additionalLeverage)
        {
            MainLeverage = mainLeverage;
            AdditionalLeverage = additionalLeverage;
        }
    }
}
