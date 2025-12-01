using DataBuilder.Effects;
using DataBuilder.Units.Behaviors;
using NWO_Abstractions;
using NWO_Abstractions.Leverages;
using NWO_Abstractions.Services;
using System.Text;

namespace NWO_DataBuilder.Core.LocalImplementations.Services
{
    public class LocalBattleLogService : IBattleLogService
    {
        public string GetUnitBehavourChangeMessage(string unitName, IBehavior behavior)
            => behavior switch
            {
                BattleBehavior => $"{unitName} вступает в битву!",
                PeacefulStandingBehavior => $"{unitName} мирно останавливается",
                PeacefulWalkingBehavior => $"{unitName} мирно перемещается",
                _ => $"{unitName} вышел из под контроля! (неизвестный тип поведения)",
            };
        
        public string GetEffectImmuneFoundMessage(string effectDisplayName, string leverageClassName) => $"\"Эффект {effectDisplayName}\" снят иммунитетом к классу {leverageClassName}";

        public string GetUnitWaitingSkillCooldownsMessage(string unitName) => $"{unitName} ожидает откатов умений";

        public string BuildCompleteRussianLeverageActionTextMessage(string russianObjectName, IUnitLeveragesSource unitLeveragesSource, ISkillResult skillResult)
        {
            StringBuilder stringBuilder = new();

            // основная часть сообщения
            string actionSentence = GetUnitLeverageActionTextMessage(unitLeveragesSource.LeveragesSource.MainLeverage, skillResult.MainPart!.Value);
            stringBuilder.Append($"{russianObjectName} {actionSentence} ");
            stringBuilder.Append(GetDataMessageToAppend(unitLeveragesSource.MainLeverageData, unitLeveragesSource.LeveragesSource.MainLeverage));
            var additionalLeverages = unitLeveragesSource.LeveragesSource.AdditionalLeverages;
            // дополнительная часть сообщения
            if (skillResult.AdditionalPart is not null && additionalLeverages is not null)
            {
                stringBuilder.Append($" и дополнительно ");          
                for (int i = 0; i < additionalLeverages.Length; i++)
                {
                    stringBuilder.Append(GetUnitLeverageActionTextMessage(additionalLeverages[i], skillResult.AdditionalPart[i].Value));
                    stringBuilder.Append(GetDataMessageToAppend(unitLeveragesSource.AdditionalLeveragesData![i], additionalLeverages[i]));
                    stringBuilder.Append(" и ");
                }
            }
            return stringBuilder.ToString().TrimEnd(' ','и');
        }

        public string GetUnitLeverageActionTextMessage(ILeverage leverage, int? leverageValue = null)
        {
            return leverage.Type switch
            {
                LeverageType.InstantDamage => $"наносит {leverageValue} ед. урона от",
                LeverageType.PassiveDamage => $"наносит {leverageValue} ед. урона от",
                LeverageType.InstantRecovery => $"восстанавливает {leverageValue} здоровья с помощью",
                LeverageType.PassiveRecovery => $"восстанавливает {leverageValue} здоровья с помощью",
                LeverageType.PositiveEffectApplying => "накладывает положительный эффект",
                LeverageType.NegativeEffectApplying => "накладывает отрицательный эффект",
                LeverageType.PositiveEffectRemoval => "снимает положительный эффект",
                LeverageType.NegativeEffectRemoval => "снимает отрицательный эффект",
                LeverageType.Creation => "создаёт",
                _ => $"делает неизвестно что на {leverageValue} ед.",
            };
        }

        public string GetPeriodicDamageTextMessage(string effectName, int damageValue, string genitive) =>
            $"Эффект \"{effectName}\" наносит {damageValue} ед. урона от {genitive}";

        public string GetPeriodicRecoveringTextMessage(string effectName, int recoveringValue, string genitive, bool isMech) =>
            $"Эффект \"{effectName}\" восстанавливает {recoveringValue} ед. {HitPointRussianWord(isMech)} с помощью {genitive}";

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

        private string HitPointRussianWord(bool isMech) => isMech ? "прочности" : "здоровья";

        private string GetEffectApplyDisplayMessage(ITypefulLeverage data)
        {
            var effect = (EffectBase)data;
            return $"\"{effect.EffectDisplayName}\" на {effect.Duration} сек.";
        }

        private bool IsEffectApplying(LeverageType type) => type is LeverageType.NegativeEffectApplying or LeverageType.PositiveEffectApplying;

        private string GetDataMessageToAppend(ITypefulLeverage data, ILeverage leverage) =>
            IsEffectApplying(leverage.Type) ? GetEffectApplyDisplayMessage(data) : $"{leverage.Class.Genitive} {leverage.InstrumentalCase}";
    } 
}
