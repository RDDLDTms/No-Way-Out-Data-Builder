namespace NWO_Abstractions
{
    /// <summary>
    /// Место попадания
    /// </summary>
    public enum LeverageHitPoint
    {
        /// <summary>
        /// В пределах видимости
        /// </summary>
        Vision,
        /// <summary>
        /// Передняя полусфера
        /// </summary>
        FrontHemisphere,
        /// <summary>
        /// Путь следования
        /// </summary>
        Route,
        /// <summary>
        /// Место вокруг попадания
        /// </summary>
        SpaceAroundTheHit,
        /// <summary>
        /// Место вокруг юнита
        /// </summary>
        SpaceAroundUnit,
        /// <summary>
        /// Передняя линия
        /// </summary>
        FrontLine
    }
}
