namespace DataBuilder.BuilderObjects
{
    /// <summary>
    /// Объект с длительностью существования
    /// </summary>
    public interface IObjectWithDuration
    {
        /// <summary>
        /// Длительность существования (мс)
        /// </summary>
        public int Duration { get; }

        /// <summary>
        /// Оставшееся время
        /// </summary>
        public int TimeLeft { get; }

        /// <summary>
        /// Получить текстовое сообщение в секундах, сколько времени осталось объекту до конца своего существования
        /// </summary>
        /// <param name="digitsCount">Количество цифр после запятой для округления времени жизни объекта</param>
        /// <returns>Число в виде текста в секундах</returns>
        public string GetDurationSecondsText(int digitsCount) => Math.Round((double)Duration/1000, digitsCount).ToString();
    }
}
