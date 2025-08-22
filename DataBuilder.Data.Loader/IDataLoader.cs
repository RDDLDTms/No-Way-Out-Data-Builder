using NWO_Abstractions;
using System.Collections.ObjectModel;

namespace DataBuilder.Data.Loader
{
    public interface IDataLoader
    {
        /// <summary>
        /// Сохранить типы воздействия асинхронно
        /// </summary>
        /// <param name="leverageTypes">список типов воздействий</param>
        /// <returns></returns>
        public Task<ObservableCollection<ILeverageClass>> LoadLeverageTypesAsync();
    }
}
