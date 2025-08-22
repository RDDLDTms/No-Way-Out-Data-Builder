namespace NWO_Abstractions
{
    /// <summary>
    /// Приоритет использования воздействий
    /// </summary>
    public enum LeveragesPriority
    {
        /// <summary>
        /// Используй это, когда больше нечего
        /// </summary>
        LowPriority = 1,

        /// <summary>
        /// Используй это в качестве основного воздействия
        /// </summary>
        BasePriority = 2,

        /// <summary>
        /// Время от времени используй это, когда оно доступно
        /// </summary>
        SupportPriority = 3,

        /// <summary>
        /// Это воздействие сильнее среднего, старайся использовать его чаще
        /// </summary>
        AdvancedPriority = 4,

        /// <summary>
        /// Это мощное воздействие, не пренебрегай его использованием
        /// </summary>
        HighPriority = 5,

        /// <summary>
        /// Используй это воздействие всегда в первую очередь, если возможно
        /// </summary>
        PrimalPriority = 6
    }
}
