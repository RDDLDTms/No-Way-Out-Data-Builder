using NWO_Abstractions.Effects;

namespace NWO_Abstractions.Services.BattleLog
{
    public interface IEffectsLogService
    {
        /// <summary>
        /// Получить сообщение о периодическом уроне от эффекта
        /// </summary>
        /// <param name="effectName">Название эффекта</param>
        /// <param name="damageValue">Значение урона</param>
        /// <param name="genitive">Родительный падеж воздействия</param>
        /// <returns>Сообщение о нанесении периодического урона</returns>
        public string GetPeriodicDamageTextMessage(string effectName, double damageValue, string genitive);

        /// <summary>
        /// Получить сообщение о периодическом восстановлении от эффекта
        /// </summary>
        /// <param name="effectName">Название эффекта</param>
        /// <param name="recoveringValue">Значение восстановления</param>
        /// <param name="genitive">Родительный падеж воздействия</param>
        /// <param name="isMech">Признак - является ли юнит механическим</param>
        /// <returns>Сообщение о периодическом восстановлении</returns>
        public string GetPeriodicRecoveringTextMessage(string effectName, double recoveringValue, string genitive, bool isMech);

        /// <summary>
        /// Текстовое сообщение о добавлении эффекта
        /// </summary>
        /// <param name="effect">Эффект</param>
        /// <param name="effectTargetName">Имя цели для эффекта</param>
        /// <param name="effectActorName">Имя того, кто накладывает эффект</param>
        /// <returns></returns>
        public string ApplyingEffectTextMessage(IEffect effect, string effectTargetName, string effectActorName);

        /// <summary>
        /// Текстовое сообщение об окончании действия эффекта
        /// </summary>
        /// <param name="effectName">Название эффекта</param>
        /// <param name="effectTargetName">Имя цели эффета</param>
        /// <param name="reason">Причина завершения эффекта</param>
        /// <returns></returns>
        public string EffectFinished(string effectName, string effectTargetName, EffectFinishReason reason);

        /// <summary>
        /// Вариативность восстановления (здоровье/прочность)
        /// </summary>
        /// <param name="isMech">Является ли цель механизмом</param>
        /// <returns>Слово о восстановлении</returns>
        public string HitPointRussianWord(bool isMech);
    }
}
