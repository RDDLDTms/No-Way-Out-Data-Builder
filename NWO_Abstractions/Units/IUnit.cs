namespace NWO_Abstractions
{
    public delegate void UnitActionDelegate(string russianUnitName, IUnitLeveragesSource unitLeveragesSource, ISkillResult skillresult);
    public delegate void UnitWaitingDelegate(string russianUnitName);
    public delegate void UnitBehaviorDelegate(string russianUnitName, IBehavior newBehavior);

    public interface IUnit
    {
        public event UnitActionDelegate? OnUnitAction;
        public event UnitWaitingDelegate? OnUnitWaiting;
        public event UnitBehaviorDelegate? OnUnitBehaviorChanged;

        public IUnitData Data { get; }

        /// <summary>
        /// Юнит в бою
        /// </summary>
        public bool InBattle { get; }

        /// <summary>
        /// Список возможных поведений юнита
        /// </summary>
        public List<IBehavior> Behaviors { get; }

        /// <summary>
        /// Умения юнита
        /// </summary>
        public List<IUnitSkill> Skills { get; }

        /// <summary>
        /// Создать умения юнита
        /// </summary>
        public void CreateSkills();

        /// <summary>
        /// Создать поведения юнита
        /// </summary>
        public void CreateBehaviors();

        public void CallUnitActionEvent(ISkillResult skillResult);

        public void CallUnitWaitingEvent();
    }
}
