namespace DataBuilder.Resources
{
    /// <summary>
    /// Тип источника добычи ресурса
    /// </summary>
    public enum ExtractionType
    {
        /// <summary>
        /// Добыча
        /// </summary>
        Mining,
        /// <summary>
        /// Поиски
        /// </summary>
        Searching,
        /// <summary>
        /// Судоходные перевозки
        /// </summary>
        Shipping,
        /// <summary>
        /// Нет источника или он неизвестен
        /// </summary>
        None
    }
}