using NWO_Abstractions.Leverages;

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
        public ITypefulLeverage MainLeverageData { get; }

        /// <summary>
        /// Данные для дополнительного воздействия
        /// </summary>
        public ITypefulLeverage[]? AdditionalLeveragesData { get; }
        
        /// <summary>
        /// Источник воздействий
        /// </summary>
        public ILeveragesSource LeveragesSource { get; }

        /// <summary>
        /// Приоритет использования воздействия
        /// </summary>
        public SkillPriority LeveragesPriority { get; }
    }
}
