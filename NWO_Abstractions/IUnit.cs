using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;

namespace NWO_Abstractions
{
    public delegate void UnitActionDelegate(string russianUnitName, IUnitLeveragesSource unitLeveragesSource, ISkillResultPart mainPart, ISkillResultPart? additionalPart);
    public delegate void UnitWaitingDelegate(string russianUnitName);
    public delegate void UnitBehaviorDelegate(string russianUnitName, IBehavior newBehavior);

    /// <summary>
    /// Юнит
    /// </summary>
    public interface IUnit : ITarget, IProducibleObject, IFactionableObject
    {
        public event UnitActionDelegate? OnUnitAction;
        public event UnitWaitingDelegate? OnUnitWaiting;
        public event UnitBehaviorDelegate? OnUnitBehaviorChanged;

        /// <summary>
        /// Уровень доступности юнита
        /// </summary>
        public AccessLevel AccessLevel { get; }

        /// <summary>
        /// Юнит в бою
        /// </summary>
        public bool InBattle { get; }

        /// <summary>
        /// Является ли юнит базовым
        /// </summary>
        public bool IsBase { get; }

        /// <summary>
        /// Уровень улучшения юнита
        /// </summary>
        public byte ImprovmentLevel { get; }

        /// <summary>
        /// Формула из айтемов для создания
        /// </summary>
        public List<Guid> ItemsFormula { get; }
        
        /// <summary>
        /// Список возможных поведений юнита
        /// </summary>
        public List<IBehavior> Behaviors { get; }

        /// <summary>
        /// Источники воздействий юнита
        /// </summary>
        public List<IUnitLeveragesSource> LeveragesSources { get; }

        /// <summary>
        /// Умения юнита
        /// </summary>
        public List<IUnitSkill> Skills { get; }

        public void CallUnitActionEvent(ISkillResult skillResult);

        public void CallUnitWaitingEvent();
    }
}
