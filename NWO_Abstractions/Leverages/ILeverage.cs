using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;

namespace NWO_Abstractions.Leverages
{
    public interface ILeverage : IBaseBuilderObject, ITypefulLeverage
    {
        /// <summary>
        /// Классы воздействия
        /// </summary>
        public List<ILeverageOption> Options { get; }

        /// <summary>
        /// Тип воздействия
        /// </summary>
        public ILeverageClass Class { get; }

        /// <summary>
        /// Цель воздействия
        /// </summary>
        public LeverageTargetType TargetType { get;  }

        /// <summary>
        /// Место попадания
        /// </summary>
        public LeverageHitPoint HitPoint { get; }

        /// <summary>
        /// Тип дальности воздействия
        /// </summary>
        public LeverageRangeType RangeType { get; }

        /// <summary>
        /// Целеполагание воздействия
        /// </summary>
        public LeverageTargeting Targeting { get; }

        /// <summary>
        /// Творительный падеж
        /// </summary>
        public string InstrumentalCase { get; }
    }
}
