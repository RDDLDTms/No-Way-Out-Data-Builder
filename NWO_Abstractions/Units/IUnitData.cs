using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;

namespace NWO_Abstractions
{
    /// <summary>
    /// Юнит
    /// </summary>
    public interface IUnitData : IProducibleObject, IFactionableObject, IUniversalObject, IObjectWithHealth, ICreationProcessable, IBaseBuilderObject
    {
        /// <summary>
        /// Уровень доступности юнита
        /// </summary>
        public AccessLevel AccessLevel { get; }

        /// <summary>
        /// Является ли юнит базовым
        /// </summary>
        public bool IsBase { get; }

        /// <summary>
        /// Уровень улучшения юнита
        /// </summary>
        public byte ImprovmentLevel { get; }
    }
}
