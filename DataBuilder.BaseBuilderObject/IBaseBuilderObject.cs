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
        /// Отображаемое имя на русском
        /// </summary>
        public string RussianDisplayName { get; }

        /// <summary>
        /// Описание объекта
        /// </summary>
        public Description Description { get; }

        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public Guid Id { get; }
    }
}