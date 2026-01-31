using NWO_Abstractions.Battles;

namespace NWO_Abstractions.Services.BattleLog
{
    /// <summary>
    /// Сервис для логгирования событий боя
    /// </summary>
    public interface IBattleLogService
    {
        IBehaviorLogService BehaviorLogService { get; }

        IEffectsLogService EffectsLogService { get; }

        /// <summary>
        /// Получить сообщение о снятии эффекта с цели при получении целью иммунитета, невелирующего эффект
        /// </summary>
        /// <param name="effectDisplayName">Отображаемое имя снятого эффекта</param>
        /// <param name="leverageClassName">Название класса воздейстий, к которому пришёл иммунитет</param>
        /// <returns>Сообщение для лога</returns>
        public string GetEffectImmuneFoundMessage(string effectDisplayName, string leverageClassName);

        /// <summary>
        /// Построить полные русские сообщения об использовании умения
        /// </summary>
        /// <param name="russianObjectName">Русское имя объекта, который использовал умение</param>
        /// <param name="unitLeveragesSource">Источник воздействий юнита</param>
        /// <param name="skillResult">Результат использования умения</param>
        /// <param name="targets">Цели воздействий умения</param>
        /// <returns>Список сообщений лога</returns>
        public List<string> BuildSkillMessages(string russianObjectName, IUnitLeveragesSource unitLeveragesSource, ISkillResult skillResult, IEnumerable<ITarget> targets);

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
