namespace DataBuilder.BuilderObjects
{
    /// <summary>
    /// Создаваемый объект
    /// </summary>
    public interface IProducibleObject
    {
        /// <summary>
        /// Извелкаемые объекты, требуемые для производства
        /// </summary>
        List<IExtractive> Extractives { get; }

        /// <summary>
        /// Создавамые объекты для производства
        /// </summary>
        List<IProducibleObject> ProducibleObjects { get; }
    }
}
