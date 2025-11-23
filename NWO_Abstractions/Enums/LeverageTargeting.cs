namespace NWO_Abstractions
{
    /// <summary>
    /// Целеполагание воздействия
    /// </summary>
    public enum LeverageTargeting
    {
        /// <summary>
        /// Нет целей (по умолчанию)
        /// </summary>
        None = 0,
        /// <summary>
        /// Одиночная цель
        /// </summary>
        Single,
        /// <summary>
        /// Несколько целей
        /// </summary>
        Many,
        /// <summary>
        /// Место
        /// </summary>
        Place,
    }
}
