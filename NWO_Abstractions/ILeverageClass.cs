using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;

namespace NWO_Abstractions
{
    /// <summary>
    /// Тип воздействия
    /// </summary>
    public interface ILeverageClass : IBaseBuilderObject
    {
        /// <summary>
        /// Глобальный тип воздействия
        /// </summary>
        public LeverageType Type { get; }
        
        /// <summary>
        /// Цветовое выделение типа воздействия
        /// </summary>
        public string Color { get; }

        /// <summary>
        /// Родительный падеж для сообщений (кого/чего)
        /// </summary>
        public string Genitive { get; }

        /// <summary>
        /// Ограничения класса воздействий
        /// </summary>
        public LeverageClassRestrictions Restrictions { get; }
    }
}