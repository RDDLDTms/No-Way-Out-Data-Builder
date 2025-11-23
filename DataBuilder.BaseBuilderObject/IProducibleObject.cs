namespace DataBuilder.BuilderObjects
{
    /// <summary>
    /// Создаваемый объект
    /// </summary>
    public interface IProducibleObject
    {
        /// <summary>
        /// Формула из айтемов для создания
        /// </summary>
        public List<Guid> Formula { get; }
    }
}
