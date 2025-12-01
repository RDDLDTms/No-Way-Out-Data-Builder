using DataBuilder.BuilderObjects.Primal;
using DataBuilder.TargetSystem;
using DataBuilder.Units.Behaviors;
using NWO_Abstractions;
using NWO_Abstractions.Battles;

namespace DataBuilder.Units
{
    public class Unit : TargetBase, IUnit
    {
        public event UnitActionDelegate? OnUnitAction;
        public event UnitWaitingDelegate? OnUnitWaiting;
        public event UnitBehaviorDelegate? OnUnitBehaviorChanged;

        public IUnitData Data { get; }
        public IBehavior ActiveBehavior { get; private set; }
        public List<IEffect> PositiveEffects => Effects.PositiveEffects;
        public List<IEffect> NegativeEffects => Effects.NegativeEffects;
        public List<IUnitLeveragesSource> LeveragesSources => Data.LeveragesSources;
        public List<IUnitSkill> Skills { get; private set; }
        public List<IBehavior> Behaviors { get; private set; }
        public List<Guid> Formula => Data.Formula;
        public AccessLevel AccessLevel => Data.AccessLevel;
        public Faction Faction => Data.Faction;
        public bool InBattle => ActiveBehavior is BattleBehavior;
        public bool IsBase => Data.IsBase;
        public bool LeveragesSourcesCreated => Data.LeveragesSourcesCreated;
        public bool DefencesCreated => Data.DefencesCreated;
        public bool ImmunesCreated => Data.ImmunesCreated;
        public byte ImprovmentLevel => Data.ImprovmentLevel;
        public Guid Id { get; }
        public Description Description => Data.Description;
        public string UniversalName => Data.UniversalName;
        public string RussianDisplayName => Data.RussianDisplayName;

        public Unit(IUnitData unitData, Guid unitId, IPercentageValues startPercentageValues) : 
            base(startPercentageValues, unitData.MaxHealth, unitData.StartEffects, unitData.Defences, unitData.Immunes, unitData.IsAlive, unitData.IsOrganic, unitData.IsMech)
        {
            Id = unitId;
            Data = unitData;
        }

        public override void JoinBattle(IBattleModelling battle, int teamNumber, int globalCooldown)
        {
            base.JoinBattle(battle, teamNumber, globalCooldown);
            ActiveBehavior = new BattleBehavior(battle, this);
            ActiveBehavior.Enable(battle.BattleSpeed, globalCooldown);
            OnUnitBehaviorChanged?.Invoke(RussianDisplayName, ActiveBehavior);
        }

        public override void LeaveBattle()
        {
            if (ActiveBehavior is not PeacefulStandingBehavior)
            {
                ActiveBehavior = Behaviors.First(x => x is PeacefulStandingBehavior);
                OnUnitBehaviorChanged?.Invoke(RussianDisplayName, ActiveBehavior);
            }
            base.LeaveBattle();
        }

        public void CreateSkills()
        {
            Skills = new();
            LeveragesSources.ForEach(x => Skills.Add(new UnitSkill(x)));
        }

        public void CreateBehaviors()
        {
            Behaviors = new()
            {
                new PeacefulStandingBehavior(),
                new PeacefulWalkingBehavior()
            };
        }

        public void CallUnitWaitingEvent()
        {
            OnUnitWaiting?.Invoke(RussianDisplayName);
        }

        public void CallUnitActionEvent(ISkillResult skillResult)
        {
            OnUnitAction?.Invoke(
                RussianDisplayName, 
                LeveragesSources.First(x => x.LeveragesPriority == skillResult.Priority), 
                skillResult);
        }
    }
}
