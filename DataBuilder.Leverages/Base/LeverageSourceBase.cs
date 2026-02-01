using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Leverages.Base
{
    public class LeverageSourceBase : ILeveragesSource
    {
        public ILeverage MainLeverage { get; }
        public ILeverage[] AdditionalLeverages { get; }
        public virtual string UniversalName { get; private set; } = string.Empty;
        public virtual string RussianName { get; private set; } = string.Empty;
        public virtual string DisplayName { get; private set; } = string.Empty;
        public virtual Description Description => new();
        public virtual Guid StorageId => Guid.Empty;

        public LeverageSourceBase(ILeverage mainLeverage, params ILeverage[] additionalLeverages)
        {
            MainLeverage = mainLeverage;
            AdditionalLeverages = additionalLeverages;
        }
    }
}
