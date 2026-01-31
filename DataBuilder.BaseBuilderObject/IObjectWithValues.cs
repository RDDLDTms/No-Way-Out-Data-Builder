namespace DataBuilder.BuilderObjects
{
    /// <summary>
    /// Объект с максимальным и минимальным значением
    /// </summary>
    public interface IObjectWithValues
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
        public double GetValue() => Random.Shared.Next(MinValue, MaxValue + 1);
    }
}
