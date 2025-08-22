namespace NWO_Abstractions
{
    /// <summary>
    /// Защитный эффект
    /// </summary>
    public interface IDefence
    {
        /// <summary>
        /// Класс защиты
        /// </summary>
        ILeverageClass DefenceClass { get; }

        /// <summary>
        /// Процент защиты
        /// </summary>
        double DefencePercent { get; }
    }
}
