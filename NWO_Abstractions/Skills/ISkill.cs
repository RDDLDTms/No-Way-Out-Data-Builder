using NWO_Abstractions.Leverages;
using NWO_Abstractions.Skills;

namespace NWO_Abstractions
{
    /// <summary>
    /// Умение юнита
    /// </summary>
    public interface ISkill
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
        /// Умение в откате
        /// </summary>
        public bool OnCooldown { get; }

        /// <summary>
        /// Умение включено/выключено
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Умение заблокировано
        /// </summary>
        public bool Blocked { get; }

        /// <summary>
        /// Может ли использовать умение
        /// </summary>
        public bool CanUseSkill => !OnCooldown && !Blocked && Enabled;

        /// <summary>
        /// Сбросить все кулдауны
        /// </summary>
        public void ResetCooldowns();

        /// <summary>
        /// Обновить кулдауны до стартовых значений
        /// </summary>
        public void RestoreCooldowns();

        /// <summary>
        /// Получить результат применения умения
        /// </summary>
        /// <param name="battleSpeed">Скорость боя</param>
        /// <returns></returns>
        public ISkillResult GetSkillResult(double battleSpeed);
    }
}

