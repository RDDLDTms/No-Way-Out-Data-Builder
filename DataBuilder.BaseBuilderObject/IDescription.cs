namespace DataBuilder.BuilderObjects
{
    /// <summary>
    /// Интерфейс разного рода описаний
    /// </summary>
    public interface IDescription
    {
        /// <summary>
        /// Текст описания
        /// </summary>
        string Text { get; }

        /// <summary>
        /// Язык описания
        /// </summary>
        Language Language { get; }
    }
}
