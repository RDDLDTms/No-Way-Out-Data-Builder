namespace DataBuilder.BuilderObjects
{
    /// <summary>
    /// Источник производимых объектов
    /// </summary>
    public interface IProducibleSourceObject
    {
        /// <summary>
        /// Источник производства
        /// </summary>
        public IBaseBuilderObject ProducingSource { get; }
    }
}
