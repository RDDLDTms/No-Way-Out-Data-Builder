using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.Support
{
    public sealed class Collections
    {
        public Collections()
        {
            LeverageTypes = new();
            Factions = new();
        }

        #region Словари
        /// <summary>
        /// Словарь типов воздействий
        /// </summary>
        public Dictionary<Guid, ILeverageClass> LeverageTypes { get; set; }

        /// <summary>
        /// Словарь фракций
        /// </summary>
        public Dictionary<Guid, Faction> Factions { get; set; }

        #endregion
    }
}
