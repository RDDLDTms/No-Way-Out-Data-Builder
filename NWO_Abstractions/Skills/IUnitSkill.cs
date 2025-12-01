using NWO_Abstractions.Leverages;

namespace NWO_Abstractions
{
    /// <summary>
    /// Умение юнита
    /// </summary>
    public interface IUnitSkill
    {
        /// <summary>
        /// Приоритет использования умения
        /// </summary>
        public SkillPriority Priority { get; }

        /// <summary>
        /// Основное воздействие
        /// </summary>
        public ILeverage MainLeverage { get; }

        /// <summary>
        /// Дополнительное воздействие
        /// </summary>
        public ILeverage[]? AdditionalLeverages { get; }

        /// <summary>
        /// Может ли использовать умение
        /// </summary>
        public bool CanUseSkill { get; }

        /// <summary>
        /// Может ли использовать дополнительные воздействия
        /// </summary>
        public Dictionary<int, bool> CanUseAdditionalLeverages { get; }

        /// <summary>
        /// Обновить кудауны воздействий
        /// </summary>
        public void RefreshCooldowns();

        /// <summary>
        /// Получить результат применения умения
        /// </summary>
        /// <param name="battleSpeed">Скорость боя</param>
        /// <returns></returns>
        public ISkillResult GetSkillResult(double battleSpeed);
    }
}

