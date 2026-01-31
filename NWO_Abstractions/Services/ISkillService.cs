using NWO_Abstractions.Skills;

namespace NWO_Abstractions.Services
{
    /// <summary>
    /// Сервис для работы с умениями
    /// </summary>
    public interface ISkillService
    {
        /// <summary>
        /// Сощздать умение
        /// </summary>
        /// <param name="source">Источник воздействий юнита для умения</param>
        /// <param name="skillPriority">Приоритет использования умения</param>
        /// <returns></returns>
        public ISkill CreateSkill(IUnitLeveragesSource source, SkillPriority skillPriority);
    }
}
