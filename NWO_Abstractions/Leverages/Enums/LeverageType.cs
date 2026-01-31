namespace NWO_Abstractions.Leverages
{
    /// <summary>
    /// Глобальные типы воздействий
    /// </summary>
    public enum LeverageType
    {
        /// <summary>
        /// Без воздействий, значение по умолчанию
        /// </summary>
        None,

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
        PositiveEffectRemoving,

        /// <summary>
        /// Снятие отрицательного эффекта
        /// </summary>
        NegativeEffectRemoving,

        /// <summary>
        /// Создание
        /// </summary>
        Creation,
    }
}
