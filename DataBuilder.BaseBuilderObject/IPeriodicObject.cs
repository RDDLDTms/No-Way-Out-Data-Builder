namespace DataBuilder.BuilderObjects
{
    /// <summary>
    /// Объект с периодическим срабатыванием
    /// </summary>
    public interface IPeriodicObject
    {
        /// <summary>
        /// Стартовая задержка перед первым срабатыванием
        /// </summary>
        public int StartDelay { get; }

        /// <summary>
        /// Стандартная задержка между срабатываниями
        /// </summary>
        public int DefaultDelay { get; }
    }
}
