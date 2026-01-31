using NWO_Abstractions.Effects;
using NWO_Abstractions.Services.BattleLog;

namespace NWO_DataBuilder.Core.LocalImplementations.Services.BattleLog
{
    public class LocalEffectLogService : IEffectsLogService
    {
        public string ApplyingEffectTextMessage(IEffect effect, string effectTargetName, string effectActorName)
        {
            if (effect is IEffectWithDuration effectWithDuration)
                return $"\"{effect.DisplayName}\" на {effectWithDuration.Duration} сек.";
            return $"\"{effect.DisplayName}\"";
        }

        public string EffectFinished(string effectName, string effectTargetName, EffectFinishReason reason)
        {
            return reason switch
            {
                EffectFinishReason.FinishedByTime => $"Время эффекта {effectName} истекло",
                EffectFinishReason.FinishedByBattleEnd => $"Эффект {effectName} завершился по окончанию боя",
                EffectFinishReason.RemovedByAnotherObject => $"Эффект {effectName} был убран воздействием извне",
                EffectFinishReason.FinishedByObjectEnd => $"Эффект {effectName} завершился после ликвидации объекта",
                _ => $"Эффект завершился по неизвестной причине",
            };
        }

        public string GetPeriodicDamageTextMessage(string effectName, double damageValue, string genitive) =>
            $"Эффект \"{effectName}\" наносит {damageValue} ед. урона от {genitive}";

        public string GetPeriodicRecoveringTextMessage(string effectName, double recoveringValue, string genitive, bool isMech) =>
            $"Эффект \"{effectName}\" восстанавливает {recoveringValue} ед. {HitPointRussianWord(isMech)} с помощью {genitive}";

        public string HitPointRussianWord(bool isMech) => isMech ? "прочности" : "здоровья";
    }
}
