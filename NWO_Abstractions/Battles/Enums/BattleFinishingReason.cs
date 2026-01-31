namespace NWO_Abstractions.Battles
{
    /// <summary>
    /// Причина завершения боя
    /// </summary>
    public enum BattleFinishingReason
    {
        /// <summary>
        /// Время вышло
        /// </summary>
        TimedOut = 0,
        /// <summary>
        /// Цель умерла
        /// </summary>
        TargetDied = 1,
        /// <summary>
        /// Все цели мертвы
        /// </summary>
        AllTargetsDied = 2,
        /// <summary>
        /// Остановлено пользователем
        /// </summary>
        UserStop = 3,
        /// <summary>
        /// Цель восстановлена
        /// </summary>
        TargetRecovered = 4,
        /// <summary>
        /// Больше не найдено целей
        /// </summary>
        NoMoreTargetsFound = 5
    }
}
