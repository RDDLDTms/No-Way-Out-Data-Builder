namespace NWO_Abstractions.Enums
{
    /// <summary>
    /// Категория сообщения боя
    /// </summary>
    public enum BattleMessageCategory
    {
        /// <summary>
        /// Сообщение без категории
        /// </summary>
        None = 0,
        /// <summary>
        /// Сообщение неизвестной категории
        /// </summary>
        Unknown = 1,
        /// <summary>
        /// Сообщение о протекании боя
        /// </summary>
        BattleProcessing = 2,
        /// <summary>
        /// Юнит использовал умение
        /// </summary>
        UnitUseSkill = 3,
        /// <summary>
        /// Сработал тик периодического эффекта
        /// </summary>
        PeriodicEffectTick = 4,
        /// <summary>
        /// Эффект завершился
        /// </summary>
        EffectFinish = 5,
        /// <summary>
        /// Сообщение про юнита, но не умение
        /// </summary>
        UnitNotSkillEvent = 6,
    }
}
