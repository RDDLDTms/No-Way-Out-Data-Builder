using NWO_Abstractions.Leverages;

namespace NWO_Abstractions.Services
{
    /// <summary>
    /// Сервис для логгирования событий боя
    /// </summary>
    public interface IBattleLogService
    {
        /// <summary>
        /// Получить сообщение об изменении поведения юнита на новое
        /// </summary>
        /// <param name="unitName">Имя юнита</param>
        /// <param name="behavior">Новое поведение</param>
        /// <returns></returns>
        public string GetUnitBehavourChangeMessage(string unitName, IBehavior behavior);

        /// <summary>
        /// Получить сообщение о снятии эффекта с цели при получении целью иммунитета, невелирующего эффект
        /// </summary>
        /// <param name="effectDisplayName">Отображаемое имя снятого эффекта</param>
        /// <param name="leverageClassName">Название класса воздейстий, к которому пришёл иммунитет</param>
        /// <returns>Сообщение для лога</returns>
        public string GetEffectImmuneFoundMessage(string effectDisplayName, string leverageClassName);

        /// <summary>
        /// Получить сообщение об ожидании откатов умений юнитом
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns>Сообщение для лога</returns>
        public string GetUnitWaitingSkillCooldownsMessage(string unitName);

        /// <summary>
        /// Построить полное русское ообщение о действии с воздействиями
        /// </summary>
        /// <returns>Сообщение для лога</returns>
        public string BuildCompleteRussianLeverageActionTextMessage(string russianObjectName, IUnitLeveragesSource leveragesSource, ISkillResult skillResult);

        /// <summary>
        /// Получить сообщение о действии юнита с воздействием
        /// </summary>
        /// <param name="leverage">Воздействие</param>
        /// <param name="leverageValue">Цифровое значение воздействия</param>
        /// <returns>Сообщение для лога</returns>
        public string GetUnitLeverageActionTextMessage(ILeverage leverage, int? leverageValue = null);

        /// <summary>
        /// Получить сообщение о получении периодичекого урона от эффекта
        /// </summary>
        /// <param name="effectName">Название эффекта</param>
        /// <param name="damageValue">Значение урона</param>
        /// <param name="genitive">Родительный падеж (чем был нанесен урон)</param>
        /// <returns>Сообщение для лога</returns>
        public string GetPeriodicDamageTextMessage(string effectName, int damageValue, string genitive);

        /// <summary>
        /// Получить сообщение о получении периодического восстановления от эффекта
        /// </summary>
        /// <param name="effectName">Название эффекта</param>
        /// <param name="recoveringValue">Значение восставноелния</param>
        /// <param name="genitive">Родительный падеж (чем было вызвано востановление)</param>
        /// <param name="isMech">Является ли цель с эффектом механической</param>
        /// <returns>Сообщение для лога</returns>
        public string GetPeriodicRecoveringTextMessage(string effectName, int recoveringValue, string genitive, bool isMech);

        /// <summary>
        /// Получить сообщение об окончании боя
        /// </summary>
        /// <param name="reason">Причина окончания боя</param>
        /// <returns>Сообщение для лога</returns>
        public string GetBattleFinishTextMessage(BattleFinishingReason reason);

        /// <summary>
        /// Сообщение о начале боя
        /// </summary>
        public const string BattleBeginningText = "Начало боя";

        /// <summary>
        /// Команда к началу боя
        /// </summary>
        public const string StartBattleText = "Начать бой!";

        /// <summary>
        /// Команда к окончанию боя
        /// </summary>
        public const string StopBattleText = "Остановить бой";

        /// <summary>
        /// Сообщение об остановке боя пользователем
        /// </summary>
        public const string BattleStoppedByUserText = "Бой остановлен пользователем";
    }
}
