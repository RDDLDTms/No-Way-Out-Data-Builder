namespace DataBuilder.BuilderObjects
{
    /// <summary>
    /// Стандратный объект для билдера
    /// </summary>
    public interface IBaseBuilderObject
    {       
        /// <summary>
        /// Универсальное название объекта
        /// </summary>
        public string UniversalName { get; }

        /// <summary>
        /// Отображаемое имя на русском
        /// </summary>
        public string RussianDisplayName { get; }

        /// <summary>
        /// Описание объекта
        /// </summary>
        public IDescription Description { get; }

        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public Guid Id { get; }
    }
}