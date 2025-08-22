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
        public LeveragesPriority Priority { get; }

        /// <summary>
        /// Основное воздействие
        /// </summary>
        public ILeverage MainLeverage { get; }

        /// <summary>
        /// Дополнительное воздействие
        /// </summary>
        public ILeverage? AdditionalLeverage { get; }

        /// <summary>
        /// Может ли использовать умение
        /// </summary>
        public bool CanUseSkill { get; }

        /// <summary>
        /// Может ли использовать дополнительное воздействие
        /// </summary>
        public bool CanUseAdditionalLeverage { get; }

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

