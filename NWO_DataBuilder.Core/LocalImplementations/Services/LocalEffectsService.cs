using DataBuilder.StartData;
using NWO_Abstractions;
using NWO_Abstractions.Data.Effects;
using NWO_Abstractions.Effects;
using NWO_Abstractions.Services;
using NWO_DataBuilder.Core.Models.Leverages.LeverageData;

namespace NWO_DataBuilder.Core.LocalImplementations.Services
{
    public class LocalEffectsService : IEffectsService
    {
        public List<(IEffect, IEffectData)> GetActorStartEffectsByPercentage(IPercentageValues percentageValues)
        {
            List<(IEffect, IEffectData)> effectsAndData = new();
            if (percentageValues.TotalDamageIncrease > 0)
            {
                var startGain = new ActorStartGain();
                effectsAndData.Add((startGain, new PercentageEffectData(startGain.Id, percentageValues.TotalDamageIncrease)));
            }

            if (percentageValues.TotalDamageDecrease > 0)
            {
                var startWeakness = new ActorStartWeakness();
                effectsAndData.Add((startWeakness, new PercentageEffectData(startWeakness.Id, percentageValues.TotalDamageDecrease)));
            }

            if (percentageValues.TotalRecoveryIncrease > 0)
            {
                var startZealtory = new ActorStartZealtory();
                effectsAndData.Add((startZealtory, new PercentageEffectData(startZealtory.Id, percentageValues.TotalRecoveryIncrease)));
            }

            if (percentageValues.TotalRecoveryDecrease > 0)
            {
                var startDespondency = new ActorStartDespondency();
                effectsAndData.Add((startDespondency, new PercentageEffectData(startDespondency.Id, percentageValues.TotalRecoveryDecrease)));
            }
            return effectsAndData;
        }

        public List<(IEffect, IEffectData)> GetTargetStartEffectsByPercentage(IPercentageValues percentageValues)
        {
            List<(IEffect, IEffectData)> effects = new();
            if (percentageValues.TotalDamageIncrease > 0)
            {
                var startBreak = new TargetStartBreak();
                effects.Add((startBreak, new PercentageEffectData(startBreak.Id, percentageValues.TotalDamageIncrease)));
            }

            if (percentageValues.TotalDamageDecrease > 0)
            {
                var startDefence = new TargetStartDefence();
                effects.Add((startDefence, new PercentageEffectData(startDefence.Id, percentageValues.TotalDamageDecrease)));
            }

            if (percentageValues.TotalRecoveryIncrease > 0)
            {
                var startShine = new TargetStartShine();
                effects.Add((startShine, new PercentageEffectData(startShine.Id, percentageValues.TotalRecoveryIncrease)));
            }

            if (percentageValues.TotalRecoveryDecrease > 0)
            {
                var startWounds = new TargetStartWounds();
                effects.Add((startWounds, new PercentageEffectData(startWounds.Id, percentageValues.TotalRecoveryDecrease)));
            }
            return effects;
        }
    }
}
