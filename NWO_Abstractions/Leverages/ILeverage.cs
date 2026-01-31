using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Effects;

namespace NWO_Abstractions.Leverages
{
    public interface ILeverage : IBaseBuilderObject
    {
        /// <summary>
        /// Тип воздействия
        /// </summary>
        public LeverageType Type { get; }

        /// <summary>
        /// Длительность воздействия
        /// </summary>
        public LeverageDuration Duration { get; }

        /// <summary>
        /// Опции воздействия
        /// </summary>
        public List<ILeverageOption> Options { get; }

        /// <summary>
        /// Эффекты воздействия
        /// </summary>
        public List<IEffect> Effects { get; }

        /// <summary>
        /// Класс воздействия
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

        /// <summary>
        /// Есть ли эффекты внутри воздействия
        /// </summary>
        public bool HasEffects => Effects is not null && Effects.Count > 0;
    }
}
