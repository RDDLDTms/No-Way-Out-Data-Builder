namespace NWO_DataBuilder.Core.Support
{
    public static class GuidGenerator
    {
        /// <summary>
        /// Сгенрировать новый гуид
        /// </summary>
        /// <param name="ids">Список уже существующих гуидов, с которыми не должно быть совпадений</param>
        /// <returns>Новый гуид</returns>
        public static Guid GetGuid(List<Guid> ids)
        {
            Guid guid;
            do
            {
                guid = Guid.NewGuid();
            }
            while (ids.Contains(guid));
            return guid;
        }
    }
}
