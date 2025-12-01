namespace NWO_Abstractions.Leverages
{
    /// <summary>
    /// Значения воздействия
    /// </summary>
    public interface ILeverageValues
    {
        /// <summary>
        /// Минимальное значение
        /// </summary>
        public int MinValue { get; }

        /// <summary>
        /// Максимальное значение
        /// </summary>
        public int MaxValue { get; }

        /// <summary>
        /// Получить значение
        /// </summary>
        /// <returns>Числовое значение от нижней до верхней границы включительно</returns>
        public int GetValue();
    }
}
