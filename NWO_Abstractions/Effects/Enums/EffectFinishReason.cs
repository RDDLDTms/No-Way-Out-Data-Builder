namespace NWO_Abstractions.Effects
{
    /// <summary>
    /// Причина окончания действия эффекта
    /// </summary>
    public enum EffectFinishReason
    {
        /// <summary>
        /// Время действия эффекта вышло
        /// </summary>
        FinishedByTime = 0,
        /// <summary>
        /// Эффект был удалён другим объектом
        /// </summary>
        RemovedByAnotherObject = 1,
        /// <summary>
        /// Эффект закончился в связи с окончанием боя
        /// </summary>
        FinishedByBattleEnd = 2,
        /// <summary>
        /// Эффект закончился в связи с окончанием существования объекта
        /// </summary>
        FinishedByObjectEnd = 3,
        /// <summary>
        /// Любая другая не перечисленная причина
        /// </summary>
        Other = 4
    }
}
