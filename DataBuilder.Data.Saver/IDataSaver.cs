using NWO_Abstractions;

namespace DataBuilder.Data.Saver
{
    public interface IDataSaver
    {
        /// <summary>
        /// Сохранить типы воздействия асинхронно
        /// </summary>
        /// <param name="leverageTypes">список типов воздействий</param>
        /// <returns></returns>
        public Task SaveLeverageTypesAsync(List<ILeverageClass> leverageTypes);
    }
}