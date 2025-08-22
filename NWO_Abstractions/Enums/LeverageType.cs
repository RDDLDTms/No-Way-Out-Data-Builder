namespace NWO_Abstractions
{
    /// <summary>
    /// Глобальные типы воздействий
    /// </summary>
    public enum LeverageType
    {
        /// <summary>
        /// Урон
        /// </summary>
        Damage,

        /// <summary>
        /// Восстановление
        /// </summary>
        Recovery,

        /// <summary>
        /// Применение положительного эффекта
        /// </summary>
        PositiveEffectApplying,

        /// <summary>
        /// Применение отрицательного эффекта
        /// </summary>
        NegativeEffectApplying,

        /// <summary>
        /// Снятие положительного эффекта
        /// </summary>
        PositiveEffectRemoval,

        /// <summary>
        /// Снятие отрицательного эффекта
        /// </summary>
        NegativeEffectRemoval,

        /// <summary>
        /// Создание
        /// </summary>
        Creation,       
    }
}
