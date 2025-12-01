namespace NWO_Abstractions.Leverages
{
    public interface ITypefulLeverage
    {
        /// <summary>
        /// Тип воздействия
        /// </summary>
        public LeverageType Type { get; }
    }
}
