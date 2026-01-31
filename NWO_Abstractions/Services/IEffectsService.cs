using NWO_Abstractions.Data.Effects;
using NWO_Abstractions.Effects;

namespace NWO_Abstractions.Services
{
    public interface IEffectsService
    {
        public List<(IEffect, IEffectData)> GetActorStartEffectsByPercentage(IPercentageValues percentageValues);

        public List<(IEffect, IEffectData)> GetTargetStartEffectsByPercentage(IPercentageValues percentageValues);
    }
}
