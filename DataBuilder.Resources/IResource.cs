using DataBuilder.BuilderObjects;

namespace DataBuilder.Resources
{
    /// <summary>
    /// Ресурс
    /// </summary>
    public interface IResource : IExtractive, IBaseBuilderObject
    {
        /// <summary>
        /// Тип добычи ресурса
        /// </summary>
        public ExtractionType ExtractionType { get; }
    }
}
