namespace DataBuilder.BuilderObjects
{
    /// <summary>
    /// Объект со временем каста
    /// </summary>
    public interface IObjectWithCast
    {
        /// <summary>
        /// Время каста (мс)
        /// </summary>
        public int CastTime { get; set; }
    }
}
