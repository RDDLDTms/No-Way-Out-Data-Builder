namespace NWO_Abstractions
{
    /// <summary>
    /// Источник воздействий для юнита
    /// </summary>
    public interface IUnitLeveragesSource
    {
        /// <summary>
        /// Данные для оснвного воздействия
        /// </summary>
        public ILeverageData MainData { get; }

        /// <summary>
        /// Данные для дополнительного воздействия
        /// </summary>
        public ILeverageData? AdditionalData { get; }
        
        /// <summary>
        /// Источник воздействий
        /// </summary>
        public ILeveragesSource LeveragesSource { get; }

        /// <summary>
        /// Приоритет использования воздействия
        /// </summary>
        public LeveragesPriority LeveragesPriority { get; }
    }
}
