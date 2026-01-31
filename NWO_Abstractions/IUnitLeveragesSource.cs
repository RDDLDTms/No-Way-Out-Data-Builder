using NWO_Abstractions.Leverages;
using NWO_Abstractions.Leverages.LeverageData;
using NWO_Abstractions.Skills;

namespace NWO_Abstractions
{
    /// <summary>
    /// Источник воздействий для юнита
    /// </summary>
    public interface IUnitLeveragesSource
    {
                /// <summary>
        /// Данные для основного воздействия
        /// </summary>
        public ILeverageData MainLeverageData { get; }

        /// <summary>
        /// Данные для дополнительного воздействия
        /// </summary>
        public ILeverageData[]? AdditionalLeveragesData { get; }
        
        /// <summary>
        /// Источник воздействий
        /// </summary>
        public ILeveragesSource LeveragesSource { get; }

        /// <summary>
        /// Приоритет использования воздействия
        /// </summary>
        public SkillPriority SkillPriority { get; }
    }
}
