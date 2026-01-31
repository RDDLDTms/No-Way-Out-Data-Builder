using BataBuilder.Items;
using DataBuilder.Effects;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_Abstractions.Battles;
using NWO_Abstractions.Effects;
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
            Dummy.OnPeriodicEffectTick += Dummy_OnPeriodicEffectTick;
            Dummy.OnEffectWithDurationFinished += Dummy_OnEffectWithDurationFinished;
            Dummy.OnPositiveEffectApplied += Target_OnPositiveEffectApplied;
            Dummy.OnNegativeEffectApplied += Target_OnNegativeEffectApplied;
            Dummy.OnPositiveEffectRemoved += Target_OnPositiveEffectRemoved;
            Dummy.OnNegativeEffectRemoved += Target_OnNegativeEffectRemoved;

            Actor.OnTargetDamaged += Actor_OnTargetDamaged;
            Actor.OnTargetRecovered += Actor_OnTargetRecovered;
            Actor.OnHealthChanged += Actor_OnHealthChanged;
            Actor.OnPeriodicEffectTick += Actor_OnPeriodicEffectTick;
            Actor.OnEffectWithDurationFinished += Actor_OnEffectWithDurationFinished;
            Actor.OnPositiveEffectApplied += Target_OnPositiveEffectApplied;
            Actor.OnNegativeEffectApplied += Target_OnNegativeEffectApplied;
            Actor.OnPositiveEffectRemoved += Target_OnPositiveEffectRemoved;
            Actor.OnNegativeEffectRemoved += Target_OnNegativeEffectRemoved;

            Actor.OnUnitAction += Actor_OnUnitAction;
            Actor.OnUnitWaiting += Actor_OnUnitWaiting;
            Actor.OnUnitBehaviorChanged += Actor_OnUnitBehaviorChanged;
            Actor.Skills.ForEach(x => x.ResetCooldowns());
            base.StartBattle();

            IEffectsSet dummyEffectsLists = new EffectsSetBase();
            IEffectsSet unitEffectsLists = new EffectsSetBase();

            var effectsService = Locator.Current.GetService<IEffectsService>();
            var dummyEffects = effectsService!.GetTargetStartEffectsByPercentage(Dummy.StartPercentageValues);
            var actorEffects = effectsService!.GetActorStartEffectsByPercentage(Actor.StartPercentageValues);
            Dummy.StartEffects.Clear();
            Actor.StartEffects.Clear();
            Dummy.StartEffects.AddAndSpreadEffects(dummyEffects.Select(_ => _.Item1).ToArray());
            Dummy.StartEffects.AddEffectsData(dummyEffects.Select(_ => _.Item2).ToArray());
            Actor.StartEffects.AddAndSpreadEffects(actorEffects.Select(_ => _.Item1).ToArray());
            Actor.StartEffects.AddEffectsData(actorEffects.Select(_ => _.Item2).ToArray());

            Dummy.JoinBattle(this, BattlePurpose is DestroyOneTargetPurpose ? 2 : 1, 400);
            Actor.JoinBattle(this, 1, 400);
        }

        private void Actor_OnEffectWithDurationFinished(IEffectWithDuration effect, EffectFinishReason finishReason) =>
            OnEffectWithDurationFinished(effect, finishReason, Actor, Actor.RussianDisplayName);

        private void Dummy_OnEffectWithDurationFinished(IEffectWithDuration effect, EffectFinishReason finishReason) =>
            OnEffectWithDurationFinished(effect, finishReason, Dummy, Dummy.RussianDisplayName);

        private void Actor_OnTargetRecovered(double newValue) => base.OnNewRecover(newValue);

        private void Actor_OnTargetDamaged(double newValue) => base.OnNewDamage(newValue);

        private void Actor_OnHealthChanged(double newValue) => base.OnNewTargetHealth(newValue, Actor);

        private void Target_OnPositiveEffectApplied(IEffect effect, ITarget target) => base.OnNewTargetPositiveEffect(effect, target);
        private void Target_OnNegativeEffectApplied(IEffect effect,ITarget target) => base.OnNewTargetNegativeEffect(effect, target);
        private void Target_OnOtherEffectApplied(IEffect effect, ITarget target) => base.OnNewTargetOtherEffect(effect, target);

        private void Target_OnPositiveEffectRemoved(IEffect effect, ITarget target, EffectFinishReason reason) => base.OnTargetPositiveEffectFinished(effect, target, reason);
        private void Target_OnNegativeEffectRemoved(IEffect effect, ITarget target, EffectFinishReason reason) => base.OnTargetNegativeEffectFinished(effect, target, reason);
        private void Target_OnOtherEffectRemoved(IEffect effect, ITarget target, EffectFinishReason reason) => base.OnTargetOtherEffectFinished(effect, target, reason);

        public override void Dispose()
        {
            Dummy.OnTargetDamaged -= Dummy_OnTargetDamaged;
            Dummy.OnTargetRecovered -= Dummy_OnTargetRecovered;
            Dummy.OnHealthChanged -= Dummy_OnHealthChanged;
            Dummy.OnPeriodicEffectTick -= Dummy_OnPeriodicEffectTick;
            Dummy.OnEffectWithDurationFinished -= Dummy_OnEffectWithDurationFinished;
            Dummy.OnPositiveEffectApplied -= Target_OnPositiveEffectApplied;
            Dummy.OnNegativeEffectApplied -= Target_OnNegativeEffectApplied;
            Dummy.OnPositiveEffectRemoved -= Target_OnPositiveEffectRemoved;
            Dummy.OnNegativeEffectRemoved -= Target_OnNegativeEffectRemoved;

            Actor.OnTargetDamaged -= Actor_OnTargetDamaged;
            Actor.OnTargetRecovered -= Actor_OnTargetRecovered;
            Actor.OnHealthChanged -= Actor_OnHealthChanged;
            Actor.OnPeriodicEffectTick -= Actor_OnPeriodicEffectTick;
            Actor.OnEffectWithDurationFinished -= Actor_OnEffectWithDurationFinished;
            Actor.OnPositiveEffectApplied -= Target_OnPositiveEffectApplied;
            Actor.OnNegativeEffectApplied -= Target_OnNegativeEffectApplied;
            Actor.OnPositiveEffectRemoved -= Target_OnPositiveEffectRemoved;
            Actor.OnNegativeEffectRemoved -= Target_OnNegativeEffectRemoved;

            Actor.OnUnitAction -= Actor_OnUnitAction;
            Actor.OnUnitWaiting -= Actor_OnUnitWaiting;
            Actor.OnUnitBehaviorChanged -= Actor_OnUnitBehaviorChanged;
            Actor.NegativeEffects.Clear();
            Actor.PositiveEffects.Clear();
            Dummy.Effects.PositiveEffects.Clear();
            Dummy.Effects.NegativeEffects.Clear();
        }

        private void Actor_OnUnitBehaviorChanged(string russianUnitName, IBehavior newBehavior) =>
            OnAction(BattleLogService.BehaviorLogService.GetUnitBehaviorChangeMessage(russianUnitName, newBehavior));

        private void Dummy_OnPeriodicEffectTick(IEffect effect, double value) => OnPeriodicEffectTick(effect, value, Dummy.IsMech);

        private void Actor_OnPeriodicEffectTick(IEffect effect, double value) => OnPeriodicEffectTick(effect, value, Actor.IsMech);

        private void Actor_OnUnitWaiting(string russianUnitName) =>
            OnAction(BattleLogService.BehaviorLogService.GetUnitWaitingSkillCooldownsMessage(russianUnitName));

        private void Actor_OnUnitAction(string russianUnitName, IUnitLeveragesSource leveragesSource, ISkillResult skillResult, IEnumerable<ITarget> targets)
        {
            var messages = BattleLogService.BuildSkillMessages(russianUnitName, leveragesSource, skillResult, targets);
            messages.ForEach(OnAction);
        }

        private void Dummy_OnTargetRecovered(double newValue) => base.OnNewRecover(newValue);

        private void Dummy_OnTargetDamaged(double newValue) => base.OnNewDamage(newValue);

        private void Dummy_OnHealthChanged(double newValue)
        {
            if (Dummy.IsImmortal)
                newValue = (int)Dummy.MaxHealth;
            base.OnNewTargetHealth(newValue, Dummy);
        }
    }
}
