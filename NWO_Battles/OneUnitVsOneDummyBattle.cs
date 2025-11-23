using BataBuilder.Items;
using DataBuilder.Effects;
using DataBuilder.Units;
using DataBuilder.Units.Behaviors;
using NWO_Abstractions;
using NWO_Abstractions.Services;
using Splat;

namespace NWO_Battles
{
    public abstract class OneUnitVsOneDummyBattle : BattleBase, IDisposable
    {
        public Dummy Dummy;
        protected Unit Actor;

        public OneUnitVsOneDummyBattle(OneDummyBattleSettings settings, string russianDisplayName, string universalDisplayName) 
            : base(settings, russianDisplayName, universalDisplayName)
        {
            Dummy = settings.Dummy;
            Actor = settings.Unit;
        }

        public override void FinishBattle(BattleFinishingReason reason)
        {
            base.FinishBattle(reason);
        }

        public override void StartBattle()
        {
            Dummy.OnTargetDamaged += Dummy_OnTargetDamaged;
            Dummy.OnTargetRecovered += Dummy_OnTargetRecovered;
            Dummy.OnHealthChanged += Dummy_OnHealthChanged;
            Dummy.OnEffectTickMessage += BattleDummy_OnEffectTickMessage;
            Dummy.OnEffectEndMessage += BattleDummy_OnEffectEndMessage;
            Dummy.OnPositiveEffectApplied += BattleDummy_OnPositiveEffectApplied;
            Dummy.OnNegativeEffectApplied += BattleDummy_OnNegativeEffectApplied;
            Dummy.OnPositiveEffectRemoved += BattleDummy_OnPositiveEffectRemoved;
            Dummy.OnNegativeEffectRemoved += BattleDummy_OnNegativeEffectRemoved;

            Actor.OnPositiveEffectApplied += Actor_OnPositiveEffectApplied;
            Actor.OnNegativeEffectApplied += Actor_OnNegativeEffectApplied;
            Actor.OnPositiveEffectRemoved += Actor_OnPositiveEffectRemoved;
            Actor.OnNegativeEffectRemoved += Actor_OnNegativeEffectRemoved;

            Actor.OnUnitAction += Actor_OnUnitAction;
            Actor.OnUnitWaiting += Actor_OnUnitWaiting;
            Actor.OnUnitBehaviorChanged += Actor_OnUnitBehaviorChanged;
            Actor.Skills.ForEach(x => x.RefreshCooldowns());
            base.StartBattle();

            IEffectsLists dummyEffectsLists = new EffectsLists();
            IEffectsLists unitEffectsLists = new EffectsLists();

            var effectsService = Locator.Current.GetService<IEffectsService>();
            var dummyEffects = effectsService!.GetEffectsByPercentage(Dummy.StartPercentageValues);
            var actorEffects = effectsService!.GetEffectsByPercentage(Actor.StartPercentageValues);
            Dummy.StartEffects.Clear();
            Actor.StartEffects.Clear();
            Dummy.StartEffects.AddAndSpreadEffects(dummyEffects);
            Actor.StartEffects.AddAndSpreadEffects(actorEffects);

            Dummy.JoinBattle(this, BattlePurpose is DestroyOneTargetPurpose ? 2 : 1, 400);
            Actor.JoinBattle(this, 1, 400);
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
            base.OnTargetNegativeEffectEnds(effect, Dummy);
        }

        private void BattleDummy_OnPositiveEffectRemoved(IEffect effect)
        {
            base.OnTargetPositiveEffectEnds(effect, Dummy);
        }

        private void BattleDummy_OnNegativeEffectApplied(IEffect effect)
        {
            base.OnNewTargetNeagetiveEffect(effect, Dummy);
        }

        private void BattleDummy_OnPositiveEffectApplied(IEffect effect)
        {
            base.OnNewTargetPositiveEffect(effect, Dummy);
        }

        public override void Dispose()
        {
            Dummy.OnTargetDamaged -= Dummy_OnTargetDamaged;
            Dummy.OnTargetRecovered -= Dummy_OnTargetRecovered;
            Dummy.OnHealthChanged -= Dummy_OnHealthChanged;
            Dummy.OnEffectTickMessage -= BattleDummy_OnEffectTickMessage;
            Dummy.OnEffectEndMessage -= BattleDummy_OnEffectEndMessage;
            Dummy.OnPositiveEffectApplied -= BattleDummy_OnPositiveEffectApplied;
            Dummy.OnNegativeEffectApplied -= BattleDummy_OnNegativeEffectApplied;
            Dummy.OnPositiveEffectRemoved -= BattleDummy_OnPositiveEffectRemoved;
            Dummy.OnNegativeEffectRemoved -= BattleDummy_OnNegativeEffectRemoved;

            Actor.OnPositiveEffectApplied -= Actor_OnPositiveEffectApplied;
            Actor.OnNegativeEffectApplied -= Actor_OnNegativeEffectApplied;
            Actor.OnPositiveEffectRemoved -= Actor_OnPositiveEffectRemoved;
            Actor.OnNegativeEffectRemoved -= Actor_OnNegativeEffectRemoved;

            Actor.OnUnitAction -= Actor_OnUnitAction;
            Actor.OnUnitWaiting -= Actor_OnUnitWaiting;
            Actor.OnUnitBehaviorChanged -= Actor_OnUnitBehaviorChanged;
            Actor.NegativeEffects.Clear();
            Actor.PositiveEffects.Clear();
            Dummy.Effects.PositiveEffects.Clear();
            Dummy.Effects.NegativeEffects.Clear();
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

        private void Dummy_OnHealthChanged(double newValue)
        {
            if (Dummy.IsImmortal)
                newValue = (int)Dummy.MaxHealth;
            base.OnNewTargetHealth(newValue, Dummy);
        }
    }
}
