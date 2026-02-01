using DataBuilder.BuilderObjects.Primal;

namespace DataBuilder.BuilderObjects
{
    /// <summary>
    /// Стандартный объект для билдера
    /// </summary>
    public interface IBaseBuilderObject
    {       
        /// <summary>
        /// Универсальное название объекта
        /// </summary>
        public string UniversalName { get; }

        /// <summary>
        /// Русское имя объекта
        /// </summary>
        public string RussianName { get; }

        /// <summary>
        /// Отображаемое имя объекта
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Описание объекта
        /// </summary>
        public Description Description { get; }

        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public Guid StorageId { get; }
    }
}