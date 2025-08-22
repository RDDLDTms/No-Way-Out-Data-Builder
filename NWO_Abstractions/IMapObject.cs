using DataBuilder.BuilderObjects;

namespace NWO_Abstractions
{
    public interface IMapObject : IBaseBuilderObject
    {
        /// <summary>
        /// Защиты объекта
        /// </summary>
        public List<IDefence> Defences { get; }

        /// <summary>
        /// Иммунитеты объекта
        /// </summary>
        public List<IImmune> Immunes { get; }

        /// <summary>
        /// Положительные эффекты на объекте
        /// </summary>
        List<IEffect> PositiveEffects { get; }

        /// <summary>
        /// Отрицательные эффекты на объекте
        /// </summary>
        List<IEffect> NegativeEffects { get; }

        /// <summary>
        /// Здоровье объекта
        /// </summary>
        public int Health { get; }

        /// <summary>
        /// Максимальное здоровье объекта
        /// </summary>
        public int MaxHealth { get; }

        /// <summary>
        /// Номер команды
        /// </summary>
        public int TeamNumber { get; set; }

        /// <summary>
        /// Есть ли в объекте органика
        /// </summary>
        public bool IsOrganic { get; set; }

        /// <summary>
        /// Живой ли объект
        /// </summary>
        public bool IsAlive { get; set; }

        /// <summary>
        /// Есть ли в объекте механика
        /// </summary>
        public bool IsMech { get; set; }
    }
}
