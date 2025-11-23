using DataBuilder.Effects;
using NWO_Abstractions;
using NWO_Abstractions.Enums;
using NWO_Abstractions.Services;
using NWO_DataBuilder.Core.Models;
using NWO_DataBuilder.Core.Tests.Leverages;

namespace NWO_DataBuilder.Core.LocalImplementations.Services
{
    public class LocalEffectsService : IEffectsService
    {
        public IEffect[] GetEffectsByPercentage(IPercentageValues percentageValues)
        {
            List<IEffect> effects = new();
            if (percentageValues.TotalDamageIncrease > 0)
                effects.Add(GetDamageIncreaseEffect(percentageValues.TotalDamageIncrease, percentageValues.Type));

            if (percentageValues.TotalDamageDecrease > 0)
                effects.Add(GetDamageDecreaseEffect(percentageValues.TotalDamageDecrease, percentageValues.Type));

            if (percentageValues.TotalRecoveryIncrease > 0)
                effects.Add(GetRecoveringIncreaseEffect(percentageValues.TotalRecoveryIncrease, percentageValues.Type));

            if (percentageValues.TotalRecoveryDecrease > 0)
                effects.Add(GetRecoveringDecreaseEffect(percentageValues.TotalRecoveryDecrease, percentageValues.Type));
            return effects.ToArray();
        }

        private IEffect GetDamageIncreaseEffect(int increasePercentage, PercentageValuesType type)
        {
            return type switch
            {
                PercentageValuesType.Incoming => new TargetDefenceDecreaseEffect(200, DictionaryStorage.GetInstance().AllLeverages[nameof(BreakLev)], 200, increasePercentage),
                _ => new ActorDamageIncreaseEffect(200, DictionaryStorage.GetInstance().AllLeverages[nameof(GainLev)], 200, increasePercentage)
            };
        }

        private IEffect GetDamageDecreaseEffect(int decreasePercentage, PercentageValuesType type) 
        {
            return type switch
            {
                PercentageValuesType.Incoming => new TargetDefenceIncreaseEffect(200, DictionaryStorage.GetInstance().AllLeverages[nameof(DefenceLev)], 200, decreasePercentage),
                _ => new ActorDamageDecreaseEffect(200, DictionaryStorage.GetInstance().AllLeverages[nameof(WeaknessLev)], 200, decreasePercentage)
            };
        }

        private IEffect GetRecoveringIncreaseEffect(int increasePercentage, PercentageValuesType type)
        {
            return type switch
            { 
                PercentageValuesType.Incoming => new TargetRecoveryPowerIncreaseEffect(200, DictionaryStorage.GetInstance().AllLeverages[nameof(ShineLev)], 200, increasePercentage),
                _ => new ActorRecoveringIncreaseEffect(200, DictionaryStorage.GetInstance().AllLeverages[nameof(ZealtoryLev)], 200, increasePercentage)
            };
        }

        private IEffect GetRecoveringDecreaseEffect(int decreasePercentage, PercentageValuesType type)
        {
            return type switch
            {
                PercentageValuesType.Incoming => new TargetRecoveryPowerDecreaseEffect(200, DictionaryStorage.GetInstance().AllLeverages[nameof(WoundsLev)], 200, decreasePercentage),
                _ => new ActorRecoveringDecreaseEffect(200, DictionaryStorage.GetInstance().AllLeverages[nameof(DespondencyLev)], 200, decreasePercentage)
            };
        }
    }
}
