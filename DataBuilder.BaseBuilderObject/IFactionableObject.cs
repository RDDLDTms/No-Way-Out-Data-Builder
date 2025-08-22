using DataBuilder.BuilderObjects.Primal;

namespace DataBuilder.BuilderObjects
{
    /// <summary>
    /// Объект, имеющий фракцию
    /// </summary>
    public interface IFactionableObject
    {
        /// <summary>
        /// Фракция
        /// </summary>
        public Faction Faction { get; }
    }
}
