using DataBuilder.BuilderObjects;

namespace NWO_Abstractions.Data.Effects
{
    public interface IPeriodicEffectCompleteData : IPeriodicEffectData, IObjectWithCooldown, IObjectWithDuration, IObjectWithValues
    {
        public double StoredIncomingAdditionalPercentage { get; set; }
    }
}
