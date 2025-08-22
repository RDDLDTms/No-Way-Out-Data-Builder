using BataBuilder.Items;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Effects.DecreaseEffects.EffectsOnActor;
using DataBuilder.Effects.DecreaseEffects.EffectsOnTarget;
using DataBuilder.Effects.IncreaseEffects.EffectsOnActor;
using DataBuilder.Effects.IncreaseEffects.EffectsOnTarget;
using DataBuilder.Leverages;
using DataBuilder.Units;
using DataBuilder.Units.Behaviors;
using NWO_Abstractions;

namespace NWO_Battles
{
    public abstract class OneUnitVsOneDummyBattle : BattleBase, IDisposable
    {
        public Dummy BattleDummy;
        protected IUnit Actor;
        

        public OneUnitVsOneDummyBattle(IUnit actor, double battleSpeed, int battleTime, bool isImmortal, int startHealth, int maxHealth, IPurpose purpose, 
            string russianDisplayName, string universalDisplayName, IPercentageValues dummyPercentageValues, IPercentageValues unitPercentageValues) 
            : base(battleSpeed, battleTime, purpose, russianDisplayName, universalDisplayName)
        {
            BattleDummy = new Dummy(new List<IImmune>(), new List<IDefence>(), startHealth, maxHealth, isImmortal, dummyPercentageValues);
            Actor = actor;
            Actor.IncomingPercentageValues = unitPercentageValues;
        }

        public override void FinishBattle(BattleFinishingReason reason)
        {
            base.FinishBattle(reason);
        }

        public override void StartBattle()
        {
            BattleDummy.OnTargetDamaged += Dummy_OnTargetDamaged;
            BattleDummy.OnTargetRecovered += Dummy_OnTargetRecovered;
            BattleDummy.OnHealthChanged += Dummy_OnHealthChanged;
            BattleDummy.OnEffectTickMessage += BattleDummy_OnEffectTickMessage;
            BattleDummy.OnEffectEndMessage += BattleDummy_OnEffectEndMessage;
            BattleDummy.OnPositiveEffectApplied += BattleDummy_OnPositiveEffectApplied;
            BattleDummy.OnNegativeEffectApplied += BattleDummy_OnNegativeEffectApplied;
            BattleDummy.OnPositiveEffectRemoved += BattleDummy_OnPositiveEffectRemoved;
            BattleDummy.OnNegativeEffectRemoved += BattleDummy_OnNegativeEffectRemoved;

            Actor.OnPositiveEffectApplied += Actor_OnPositiveEffectApplied;
            Actor.OnNegativeEffectApplied += Actor_OnNegativeEffectApplied;
            Actor.OnPositiveEffectRemoved += Actor_OnPositiveEffectRemoved;
            Actor.OnNegativeEffectRemoved += Actor_OnNegativeEffectRemoved;

            Actor.OnUnitAction += Actor_OnUnitAction;
            Actor.OnUnitWaiting += Actor_OnUnitWaiting;
            Actor.OnUnitBehaviorChanged += Actor_OnUnitBehaviorChanged;
            Actor.Skills.ForEach(x => x.RefreshCooldowns());
            base.StartBattle();
            List<IEffect> dummyNegativeStartEffects = new List<IEffect>();
            List<IEffect> dummyPositiveStartEffects = new List<IEffect>();
            List<IEffect> unitNegativeStartEffects = new List<IEffect>();
            List<IEffect> unitPositiveStartEffects = new List<IEffect>();

            if (BattleDummy.IncomingPercentageValues.TotalDamageDecrease > 0)
            {
                IEffect startDefenceEffect = new TargetDefenceIncreaseEffect(200,
                    new LeverageClass("Защита", "Defence", "565656", "уменьшения урона", LeverageType.PositiveEffectApplying, 
                    LeverageClassRestrictions.NoRestrictions), 9, "Защита", BattleDummy.IncomingPercentageValues.TotalDamageDecrease);
                dummyPositiveStartEffects.Add(startDefenceEffect);
            }

            if (BattleDummy.IncomingPercentageValues.TotalDamageIncrease > 0)
            {
                IEffect startBreakEffect = new TargetDefenceDecreaseEffect(200,
                new LeverageClass("Пролом", "Break", "565656", "увеличения урона", LeverageType.NegativeEffectApplying, 
                LeverageClassRestrictions.NoRestrictions), 9, "Пролом", BattleDummy.IncomingPercentageValues.TotalDamageIncrease);
                dummyNegativeStartEffects.Add(startBreakEffect);
            }

            if (BattleDummy.IncomingPercentageValues.TotalRecoveryDecrease > 0)
            {
                IEffect startWoundsEffect = new TargetRecoveryPowerDecreaseEffect(200,
                    new LeverageClass("Раны", "Wounds", "565656", "уменьшения восстановления", LeverageType.NegativeEffectApplying,
                    LeverageClassRestrictions.NoRestrictions), 9, "Раны", BattleDummy.IncomingPercentageValues.TotalRecoveryDecrease);
                dummyNegativeStartEffects.Add(startWoundsEffect);
            }

            if (BattleDummy.IncomingPercentageValues.TotalRecoveryIncrease > 0)
            {
                IEffect startLightEffect = new TargetDefenceIncreaseEffect(200, 
                    new LeverageClass("Свет", "Light", "565656", "увеличения восстановления", LeverageType.PositiveEffectApplying,
                    LeverageClassRestrictions.NoRestrictions), 9, "Свет", BattleDummy.IncomingPercentageValues.TotalRecoveryIncrease);
                dummyPositiveStartEffects.Add(startLightEffect);
            }

            BattleDummy.JoinBattle(this, BattlePurpose is DestroyOneTargetPurpose ? 2 : 1, 400, dummyNegativeStartEffects, dummyPositiveStartEffects);

            if (Actor.IncomingPercentageValues.TotalDamageIncrease > 0)
            {
                ILeverageClass gain = new LeverageClass("Усиление", "Gain", "434343", "усиления", LeverageType.PositiveEffectApplying, LeverageClassRestrictions.NoRestrictions);
                IEffect startGainEffect = new ActorDamageIncreaseEffect(200, gain, 9, "Усиление",
                    Actor.IncomingPercentageValues.TotalDamageIncrease);
                unitPositiveStartEffects.Add(startGainEffect);
            }

            if (Actor.IncomingPercentageValues.TotalRecoveryIncrease > 0)
            {
                ILeverageClass zealotry = new LeverageClass("Фанатизм", "Zealtory", "434343", "фанатизма", LeverageType.PositiveEffectApplying, LeverageClassRestrictions.NoRestrictions);
                IEffect startZealotryEffect = new ActorRecoveringIncreaseEffect(200, zealotry, 9, "Фанатизм",
                    Actor.IncomingPercentageValues.TotalRecoveryIncrease);
                unitPositiveStartEffects.Add(startZealotryEffect);
            }

            if (Actor.IncomingPercentageValues.TotalDamageDecrease > 0)
            {
                ILeverageClass weakness = new LeverageClass("Слабость", "Weakness", "434343", "слабости", LeverageType.NegativeEffectApplying, LeverageClassRestrictions.NoRestrictions);
                IEffect startWeaknessEffect = new ActorDamageDecreaseEffect(200, weakness, 9, "Слабость",
                    Actor.IncomingPercentageValues.TotalDamageDecrease);
                unitNegativeStartEffects.Add(startWeaknessEffect);
            }

            if (Actor.IncomingPercentageValues.TotalRecoveryDecrease > 0)
            {
                ILeverageClass despondency = new LeverageClass("Уныние", "Despondency", "434343", "уныния", LeverageType.NegativeEffectApplying, LeverageClassRestrictions.NoRestrictions);
                IEffect startDespondencyWeaknessEffect = new ActorRecoveringDecreaseEffect(200, despondency, 9, "Уныние",
                    Actor.IncomingPercentageValues.TotalRecoveryDecrease);
                unitNegativeStartEffects.Add(startDespondencyWeaknessEffect);
            }

            Actor.JoinBattle(this, 1, 400, unitNegativeStartEffects, unitPositiveStartEffects);
        }

        private void Actor_OnNegativeEffectRemoved(IEffect effect)
        {
            base.OnTargetNegativeEffectEnds(effect, Actor);
        }

        private void Actor_OnPositiveEffectRemoved(IEffect effect)
        {
            base.OnTargetPositiveEffectEnds(effect, Actor);
        }

        private void Actor_OnNegativeEffectApplied(IEffect effect)
        {
            base.OnNewTargetNeagetiveEffect(effect, Actor);
        }

        private void Actor_OnPositiveEffectApplied(IEffect effect)
        {
            base.OnNewTargetPositiveEffect(effect, Actor);
        }

        private void BattleDummy_OnNegativeEffectRemoved(IEffect effect)
        {
            base.OnTargetNegativeEffectEnds(effect, BattleDummy);
        }

        private void BattleDummy_OnPositiveEffectRemoved(IEffect effect)
        {
            base.OnTargetPositiveEffectEnds(effect, BattleDummy);
        }

        private void BattleDummy_OnNegativeEffectApplied(IEffect effect)
        {
            base.OnNewTargetNeagetiveEffect(effect, BattleDummy);
        }

        private void BattleDummy_OnPositiveEffectApplied(IEffect effect)
        {
            base.OnNewTargetPositiveEffect(effect, BattleDummy);
        }

        public override void Dispose()
        {
            BattleDummy.OnTargetDamaged -= Dummy_OnTargetDamaged;
            BattleDummy.OnTargetRecovered -= Dummy_OnTargetRecovered;
            BattleDummy.OnHealthChanged -= Dummy_OnHealthChanged;
            BattleDummy.OnEffectTickMessage -= BattleDummy_OnEffectTickMessage;
            BattleDummy.OnEffectEndMessage -= BattleDummy_OnEffectEndMessage;
            BattleDummy.OnPositiveEffectApplied -= BattleDummy_OnPositiveEffectApplied;
            BattleDummy.OnNegativeEffectApplied -= BattleDummy_OnNegativeEffectApplied;
            BattleDummy.OnPositiveEffectRemoved -= BattleDummy_OnPositiveEffectRemoved;
            BattleDummy.OnNegativeEffectRemoved -= BattleDummy_OnNegativeEffectRemoved;

            Actor.OnPositiveEffectApplied -= Actor_OnPositiveEffectApplied;
            Actor.OnNegativeEffectApplied -= Actor_OnNegativeEffectApplied;
            Actor.OnPositiveEffectRemoved -= Actor_OnPositiveEffectRemoved;
            Actor.OnNegativeEffectRemoved -= Actor_OnNegativeEffectRemoved;

            Actor.OnUnitAction -= Actor_OnUnitAction;
            Actor.OnUnitWaiting -= Actor_OnUnitWaiting;
            Actor.OnUnitBehaviorChanged -= Actor_OnUnitBehaviorChanged;
            Actor.NegativeEffects.Clear();
            Actor.PositiveEffects.Clear();
            BattleDummy.PositiveEffects.Clear();
            BattleDummy.NegativeEffects.Clear();
        }

        private void Actor_OnUnitBehaviorChanged(string russianUnitName, IBehavior newBehavior)
        {
            switch (newBehavior)
            {
                case BattleBehavior:
                    OnAction($"{russianUnitName} вступает в битву!");
                    break;
                case PeacefulStandingBehavior:
                    OnAction($"{russianUnitName} мирно останавливается");
                    break;
                case PeacefulWalkingBehavior:
                    OnAction($"{russianUnitName} мирно перемещается");
                    break;
                default:
                    OnAction($"{russianUnitName} вышел из под контроля! (неизвестный тип поведения)");
                    break;
            }
        }

        private void BattleDummy_OnEffectTickMessage(string logMessage)
        {
            OnAction(logMessage);
        }

        private void BattleDummy_OnEffectEndMessage(string logMessage)
        {
            OnAction(logMessage);
        }

        private void Actor_OnUnitWaiting(string russianUnitName)
        {
            OnAction($"{russianUnitName} ожидает откатов умений");
        }

        private void Actor_OnUnitAction(string russianUnitName, IUnitLeveragesSource leveragesSource, ISkillResultPart mainPart, ISkillResultPart? additionalPart)
        {
            var message = BuildActionMessage(russianUnitName, leveragesSource, mainPart, additionalPart);
            OnAction(message);
        }

        private void Dummy_OnTargetRecovered(int newValue)
        {
            base.OnNewRecover(newValue);
        }

        private void Dummy_OnTargetDamaged(int newValue)
        {
            base.OnNewDamage(newValue);
        }

        private void Dummy_OnHealthChanged(int newValue)
        {
            if (BattleDummy.IsImmortal)
                newValue = BattleDummy.MaxHealth;
            base.OnNewTargetHealth(newValue, BattleDummy);
        }
    }
}
