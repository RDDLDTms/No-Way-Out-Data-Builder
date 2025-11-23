using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;

namespace NWO_Abstractions
{
    /// <summary>
    /// Класс воздействия
    /// </summary>
    public interface ILeverageClass : IBaseBuilderObject
    {
        /// <summary>
        /// Цветовое выделение класса воздейтвия
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