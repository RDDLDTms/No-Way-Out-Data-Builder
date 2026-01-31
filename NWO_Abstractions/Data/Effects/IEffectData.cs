using NWO_Abstractions.Leverages.LeverageData;

namespace NWO_Abstractions.Data.Effects
{
    public interface IEffectData : ILeverageData
    {
        /// <summary>
        /// Идентификатор эффекта для данных
        /// </summary>
        public Guid EffectId { get; }

        /// <summary>
        /// Идентификатор объекта, который отправил эффект
        /// </summary>
        public Guid SenderId { get; }
    }
}
