namespace NWO_Abstractions
{
    public interface IObjectsSaverService
    {
        /// <summary>
        /// Сохранить объекты
        /// </summary>
        /// <param name="objects">Коллекция объектов для сохранения</param>
        /// <returns></returns>
        public Task SaveObjects(List<IGeneralObject> objects, string typeName);
    }
}
