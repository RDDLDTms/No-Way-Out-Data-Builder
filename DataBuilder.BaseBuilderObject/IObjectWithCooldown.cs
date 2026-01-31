namespace DataBuilder.BuilderObjects
{
    /// <summary>
    /// Объект с откатом (мс)
    /// </summary>
    public interface IObjectWithCooldown
    {
        /// <summary>
        /// Откат (мс)
        /// </summary>
        public int Cooldown { get; }
    }
}
