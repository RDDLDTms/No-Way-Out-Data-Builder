using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.TargetSystem;
using DataBuilder.Units.Behaviors;
using NWO_Abstractions;

namespace DataBuilder.Units
{
    public class Unit : TargetBase, IUnit
    {
        public event UnitActionDelegate? OnUnitAction;

        public event UnitWaitingDelegate? OnUnitWaiting;

        public event UnitBehaviorDelegate? OnUnitBehaviorChanged;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public AccessLevel AccessLevel { get; private set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool IsBase { get; private set; }

        public byte ImprovmentLevel { get; private set; }

        public List<IEffect> Effects { get; private set; }

        public List<IUnitLeveragesSource> LeveragesSources { get; private set; }
        
        public IDescription RussianDisplayDescription { get; private set; }

        public IDescription RussianVisualDescription { get; private set; }

        public List<IExtractive> Extractives { get; private set; }

        public List<IProducibleObject> ProducibleObjects { get; private set; }

        public Faction Faction { get; private set; }

        public List<Guid> Formula { get; private set; }

        public List<IUnitSkill> Skills { get; private set; }

        public bool InBattle => ActiveBehavior is BattleBehavior;

        public IBehavior ActiveBehavior { get; private set; }

        public List<IBehavior> Behaviors { get; private set; }

        public Unit(string universalName, string russianDisplayName, bool isBase, Faction faction, AccessLevel accessLevel, byte improvmentLevel, List<Guid> formula, 
            List<IUnitLeveragesSource> leverageSources, List<IImmune> immunes, List<IDefence> defences, int startHealth, int maxHealth, IPercentageValues incomingPercentageValues) : 
            base(immunes, defences, startHealth, maxHealth, incomingPercentageValues)
        {
            RussianDisplayName = russianDisplayName;
            UniversalName = universalName;
            IsBase = isBase;
            Faction = faction;
            AccessLevel = accessLevel;
            ImprovmentLevel = improvmentLevel;
            Formula = formula;
            LeveragesSources = leverageSources;
            CreateSkills();
            CreateBehaviors();
        }

        public Unit(UnitBase unitBase) : base(unitBase.Immunes, unitBase.Defences, unitBase.MaxHealth)
        {
            RussianDisplayName = unitBase.RussianDisplayName;
            UniversalName = unitBase.UniversalName;
            IsBase = unitBase.IsBase;
            Faction = unitBase.Faction;
            AccessLevel = unitBase.AccessLevel;
            ImprovmentLevel = unitBase.ImprovmentLevel;
            Formula = unitBase.Formula;
            LeveragesSources = unitBase.LeveragesSources;
            CreateSkills();
            CreateBehaviors();
        }


        public override void JoinBattle(IBattleModelling battle, int teamNumber, int globalCooldown, List<IEffect>? negativeStartEffects, List<IEffect>? positiveStartEffects)
        {
            base.JoinBattle(battle, teamNumber, globalCooldown, negativeStartEffects, positiveStartEffects);
            ActiveBehavior = new BattleBehavior(this, battle);
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

        private void CreateSkills()
        {
            Skills = new List<IUnitSkill>();
            foreach (var leveragesSource in LeveragesSources)
            {
                Skills.Add(new UnitSkill(leveragesSource));
            }
        }

        private void CreateBehaviors()
        {
            Behaviors = new List<IBehavior>()
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
                skillResult.MainPart, 
                skillResult.AdditionalPart);
        }
    }
}
