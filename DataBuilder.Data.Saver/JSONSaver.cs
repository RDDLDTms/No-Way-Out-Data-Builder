using DataBuilder.BuilderObjects;
using Newtonsoft.Json;
using NWO_Abstractions;

namespace DataBuilder.Data.Saver
{
    public class JSONSaver : IDataSaver
    {
        public async Task SaveLeverageTypesAsync(List<ILeverageClass> leverageTypes)
        {
            await SaveAsync(leverageTypes, nameof(leverageTypes));
        }

        /// <summary>
        /// Сохранить список объектов
        /// </summary>
        /// <typeparam name="T">Объект BaseBuilderObject</typeparam>
        /// <param name="objectsToSave">Список объектов для сохранения</param>
        /// <param name="directoryName">Имя директории</param>
        /// <returns></returns>
        private static async Task SaveAsync<T>(List<T> objectsToSave, string directoryName) where T : IBaseBuilderObject
        {
            if (Directory.Exists(directoryName) is false)
            {
                Directory.CreateDirectory(directoryName);
            }

            Directory.Delete(directoryName, true);
            foreach (var nextObject in objectsToSave)
            {
                await File.WriteAllTextAsync(@"c:\movie.json", JsonConvert.SerializeObject(nextObject));
            }
        }
    }
}
