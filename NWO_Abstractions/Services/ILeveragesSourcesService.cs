using NWO_Abstractions;

namespace NWO_DataBuilder.Core.Services
{
    /// <summary>
    /// Сервис по работе с источниками воздействий
    /// </summary>
    public interface ILeveragesSourcesService
    {
        /// <summary>
        /// Создать источник воздействий
        /// </summary>
        /// <returns>Новый истоник воздействий</returns>
        public ILeveragesSource CreateLeveragesSource(ILeverage mainLeverage, ILeverage? additionalLeverage, string universalName, string russianName, string russianDescription, string secondWord);

        /// <summary>
        /// Создать источник воздействий для юнита
        /// </summary>
        /// <param name="source">Истоник воздействий</param>
        /// <param name="priority">Приоритет использования</param>
        /// <param name="mainValues">Значения основного воздействия</param>
        /// <param name="additionalValues">Значения дополнительного воздействия</param>
        /// <returns>Источник воздействий для юнита</returns>
        public IUnitLeveragesSource CreateUnitLeverageSource(ILeveragesSource source, SkillPriority priority, ILeverageData mainData, ILeverageData? additionalData = null);
    }
}
