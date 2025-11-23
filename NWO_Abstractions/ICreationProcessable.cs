namespace NWO_Abstractions
{
    public interface ICreationProcessable
    {
        /// <summary>
        /// Признак созданных источников воздействий
        /// </summary>
        public bool LeveragesSourcesCreated { get; }

        /// <summary>
        /// Признак созданного списка защит
        /// </summary>
        public bool DefencesCreated { get; }

        /// <summary>
        /// Список созданного списка иммунок
        /// </summary>
        public bool ImmunesCreated { get; }

        /// <summary>
        /// Создать источники воздейтвий для объекта
        /// </summary>
        /// <returns>Список источников воздействий для юнита</returns>
        public List<IUnitLeveragesSource> CreateLeveragesSources();

        /// <summary>
        /// Создать список защит объекта
        /// </summary>
        /// <returns>Список защит объекта</returns>
        public List<IDefence> CreateDefences();

        /// <summary>
        /// Создать список иммунок объекта
        /// </summary>
        /// <returns>Список имунок объекта</returns>
        public List<IImmune> CreateImmunes();

        /// <summary>
        /// Список источников воздействий объекта
        /// </summary>
        public List<IUnitLeveragesSource> LeveragesSources { get; }

        /// <summary>
        /// Список иммунок объекта
        /// </summary>
        public List<IImmune> Immunes { get; }

        /// <summary>
        /// Список защит объекта
        /// </summary>
        public List<IDefence> Defences { get; }
    }
}
