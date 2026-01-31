namespace NWO_Abstractions.Leverages
{
    /// <summary>
    /// Типы целей
    /// </summary>
    public enum LeverageTargetType
    {
        /// <summary>
        /// Никакие (по умолчанию)
        /// </summary>
        None = 0,
        /// <summary>
        /// Дружественные
        /// </summary>
        Alias = 1,
        /// <summary>
        /// Вражеские
        /// </summary>
        Enemies = 2,
        /// <summary>
        /// Нейтральные
        /// </summary>
        Neutral = 3,
        /// <summary>
        /// Все
        /// </summary>
        All = 4
    }
}
