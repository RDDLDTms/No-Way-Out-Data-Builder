using NWO_Abstractions.Effects;

namespace NWO_Abstractions
{
    public interface IUniversalObject 
    {
        /// <summary>
        /// Начальные эффекты на объекте
        /// </summary>
        public IEffectsSet StartEffects { get; }

        /// <summary>
        /// Есть ли в объекте органика
        /// </summary>
        public bool IsOrganic { get; }

        /// <summary>
        /// Живой ли объект
        /// </summary>
        public bool IsAlive { get; }

        /// <summary>
        /// Есть ли в объекте механика
        /// </summary>
        public bool IsMech { get; }
    }
}
