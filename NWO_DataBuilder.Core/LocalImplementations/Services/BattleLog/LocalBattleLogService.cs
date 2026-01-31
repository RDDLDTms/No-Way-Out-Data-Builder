using DataBuilder.BuilderObjects;
using DataBuilder.Skills;
using NWO_Abstractions;
using NWO_Abstractions.Battles;
using NWO_Abstractions.Data.Effects;
using NWO_Abstractions.Leverages;
using NWO_Abstractions.Leverages.LeverageData;
using NWO_Abstractions.Services.BattleLog;
using NWO_DataBuilder.Core.LocalImplementations.Services.BattleLog;
using NWO_DataBuilder.Core.Models.Leverages;

namespace NWO_DataBuilder.Core.LocalImplementations.Services
{
    public class LocalBattleLogService : IBattleLogService
    {
        public IBehaviorLogService BehaviorLogService { get; }

        public IEffectsLogService EffectsLogService { get; }

        public LocalBattleLogService()
        {
            BehaviorLogService = new LocalBehaviorLogService();
            EffectsLogService = new LocalEffectLogService();
        }

        public string GetEffectImmuneFoundMessage(string effectDisplayName, string leverageClassName) => $"\"Эффект {effectDisplayName}\" снят иммунитетом к классу {leverageClassName}";

        public List<string> BuildSkillMessages(string russianObjectName, IUnitLeveragesSource unitLeveragesSource, ISkillResult skillResult, IEnumerable<ITarget> targets)
        {
            var skillMessages = new List<string>();
            
            //mainLeverage
            ILeverage mainLeverage = unitLeveragesSource.LeveragesSource.MainLeverage;
            var mainActionSentence = GetActionSentence(unitLeveragesSource.MainLeverageData, mainLeverage, skillResult.MainPart!, targets.First().IsMech);

            if (unitLeveragesSource.MainLeverageData is IInstantLeverageData)
            {
                skillMessages.Add($"{russianObjectName} {mainActionSentence} {mainLeverage.Class.Genitive} {mainLeverage.InstrumentalCase}");
            }
            else if (unitLeveragesSource.MainLeverageData is IEffectData)
            {
                skillMessages.Add($"{russianObjectName} {mainActionSentence}");
            }

            //additionalLeverages
            var additionalLeverages = unitLeveragesSource.LeveragesSource.AdditionalLeverages;
            if (skillResult.AdditionalParts is not null && skillResult.AdditionalParts.Length > 0 && additionalLeverages is not null)
            {
                for (int i = 0; i < additionalLeverages.Length; i++)
                {
                    if (skillResult.AdditionalParts[i] is null)
                        continue;
                    var additionalActionSentence = GetActionSentence(unitLeveragesSource.AdditionalLeveragesData![i], additionalLeverages[i], skillResult.AdditionalParts[i], targets.First().IsMech);
                    if (unitLeveragesSource.AdditionalLeveragesData![i] is IInstantLeverageData)
                    {
                        skillMessages.Add($"{russianObjectName} {additionalActionSentence} {additionalLeverages[i].Class.Genitive} {additionalLeverages[i].InstrumentalCase}");
                    }
                    else if (unitLeveragesSource.AdditionalLeveragesData![i] is IEffectData)
                    {
                        skillMessages.Add($"{russianObjectName} {additionalActionSentence}");
                    }
                }
            }
            return skillMessages;
        }

        public string GetBattleFinishTextMessage(BattleFinishingReason reason) =>
            reason switch
            {
                BattleFinishingReason.TimedOut => "Бой завершён, время подошло к концу",
                BattleFinishingReason.TargetRecovered => "Бой завершён, цель восстановлена",
                BattleFinishingReason.TargetDied => "Бой завершён, цель уничтожена!",
                BattleFinishingReason.AllTargetsDied => "Бой завершён, все цели уничтожены!",
                BattleFinishingReason.NoMoreTargetsFound => "Бой завершён, актуальных целей для воздействий нет",
                BattleFinishingReason.UserStop => "Бой остановлен пользователем",
                _ => "Бой завершён по неизвестной причине",
            };

        private string GetActionSentence(ILeverageData leverageData, ILeverage leverage, ISkillResultPart skillResultPart, bool isMechTarget)
        {
            string actionSentence = string.Empty;
            switch (leverageData)
            {
                case IInstantLeverageData instantData:
                    if (skillResultPart is SkillValuesResultPart srp)
                    {
                        if (leverage is InstantDamage)
                        {
                            actionSentence = $"наносит {srp.Value} урона от";
                        }
                        else if (leverage is InstantRecovery)
                        {
                            actionSentence = $"восстанавливает {srp.Value} {EffectsLogService.HitPointRussianWord(isMechTarget)} с помощью";
                        }
                    }
                    break;

                case IEffectRemovingData effectRemovingData:
                    if (skillResultPart is SkillEffectRemovingResultPart serrp)
                    {
                        if (leverage is PositiveEffectRemoving)
                        {
                            //TODO сделать множественное снятие эффектов одной чисткой
                            actionSentence = $"снимает положительный эффект {serrp.Effects[0]}";
                        }
                        else if (leverage is NegativeEffectRemoving)
                        {
                            //TODO сделать множественное снятие эффектов одной чисткой 2
                            actionSentence = $"снимает отрицательный эффект {serrp.Effects[0]}";
                        }
                    }
                    break;

                case IEffectData effectData:
                    if (skillResultPart is SkillEffectResultPart serp)
                    {
                        var lifeTimeText = serp.Effect.HasLifeTime ? $" на {((IObjectWithDuration)effectData).GetDurationSecondsText(1)} сек." : string.Empty;
                        if (leverage.Type is LeverageType.NegativeEffectApplying)
                        {
                            actionSentence = $"накладывает отрицательный эффект {serp.Effect.DisplayName}{lifeTimeText}";
                        }
                        else if (leverage.Type is LeverageType.PositiveEffectApplying)
                        {
                            actionSentence = $"накладывает положительный эффект {serp.Effect.DisplayName}{lifeTimeText}";
                        }
                    }
                    break;

                default:
                    actionSentence = $"делает неизвестно что";
                    break;
            }
            return actionSentence;
        }
    }
}
