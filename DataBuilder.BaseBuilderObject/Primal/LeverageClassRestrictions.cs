namespace DataBuilder.BuilderObjects.Primal
{
    /// <summary>
    /// Ограничения классов воздействий
    /// </summary>
    public enum LeverageClassRestrictions
    {
        /// <summary>
        /// Без ограничений, воздействие работает на всех
        /// </summary>
        NoRestrictions,
        /// <summary>
        /// Воздействие работает только на механизмы
        /// </summary>
        MechOnly,
        /// <summary>
        /// Воздействие работает только на органику
        /// </summary>
        OrganicOnly,
        /// <summary>
        /// Работает только на живых
        /// </summary>
        AliveOnly,
        /// <summary>
        /// Работает только на живых и органику
        /// </summary>
        OrganicAndAlive
    }
}
