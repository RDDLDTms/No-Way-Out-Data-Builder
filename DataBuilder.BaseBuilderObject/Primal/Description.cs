namespace DataBuilder.BuilderObjects.Primal
{
    /// <summary>
    /// Интерфейс разного рода описаний
    /// </summary>
    public class Description
    {
        /// <summary>
        /// Текст описания
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Язык описания
        /// </summary>
        public Language Language { get; }

        public Description(string text, Language language)
        {
            Text = text;
            Language = language;
        }

        public Description()
        {
            Text = string.Empty;
            Language = Language.English;
        }
    }
}
