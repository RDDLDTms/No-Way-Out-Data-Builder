using NWO_Abstractions.Leverages;

namespace NWO_Abstractions.Effects
{
    /// <summary>
    /// Эффект
    /// </summary>
    public interface IEffect
    {
        /// <summary>
        /// Универсальное имя эффекта
        /// </summary>
        public string UniversalName { get; }

        /// <summary>
        /// Отображаемое русское имя эффекта
        /// </summary>
        public string RussianName { get; }

        /// <summary>
        /// Выбор имени эффекта (русское или, если нет его - универсальное)
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Класс воздействия эффекта
        /// </summary>
        public ILeverageClass LeverageClass { get; }

        /// <summary>
        /// Носитель эффекта
        /// </summary>
        public EffectCarrier Carrier { get; }

        /// <summary>
        /// Тип эффекта
        /// </summary>
        public EffectType Type { get; }

        /// <summary>
        /// Идентификатор эффекта
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Является ли удаляемым с носителя
        /// </summary>
        public bool IsRemovable { get; }

        /// <summary>
        /// У эффекта есть время существования
        /// </summary>
        public bool HasLifeTime { get; }

        /// <summary>
        /// У эффекта есть очки
        /// </summary>
        public bool HasPoints { get; }

        /// <summary>
        /// У эффекта есть минимальное и максимальное значение тика
        /// </summary>
        public bool HasValues { get; }

        /// <summary>
        /// Есть процентаж
        /// </summary>
        public bool HasPercentage { get; }
    }
}
