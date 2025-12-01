namespace NWO_Abstractions
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
        InstantDamage,

        /// <summary>
        /// Восстановление
        /// </summary>
        InstantRecovery,

        /// <summary>
        /// Пассивный урон
        /// </summary>
        PassiveDamage,

        /// <summary>
        /// Пассивное восстановление
        /// </summary>
        PassiveRecovery,

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
