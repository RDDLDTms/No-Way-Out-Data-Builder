using DataBuilder.Effects;
using DataBuilder.StartData;
using DataBuilder.TargetSystem;
using DataBuilder.Skills;
using NWO_Abstractions;
using NWO_Abstractions.Battles;
using NWO_Abstractions.Data.Effects;
using NWO_Abstractions.Leverages;
using NWO_Abstractions.Skills;

namespace DataBuilder.Units.Behaviors
{
    public class BattleBehavior : IBehavior
    {
        private const int WAITING_COOLDOWN = 100;
        private const int MAX_WAITING_SECONDS = 7;
        private int waitingSeconds = 0;
        private Timer? _timer = null;
        private Unit _unit;
        private IBattleModelling _battle;
        private CommonTargetSystem _targetSystem;
        private bool SkillsCooldownWaiting = false;

        //TODO cache
        private bool _startDamagePercentageCalculated = false;
        private bool _startRecoveryPercentageCalculated = false;
        private double _startDamage = 0;
        private double _startRecovery = 0;

        public bool CanUseAnySkill => _unit.Skills.Any(x => x.CanUseSkill);
        
        public BattleBehavior(IBattleModelling battle, Unit unit)
        {
            _battle = battle;
            _unit = unit;
            _targetSystem = new CommonTargetSystem(battle);
        }

        public async Task Enable(double battleSpeed, int globalCooldown)
        {
            waitingSeconds = 0;
            _timer = new Timer(TimerCallback, null, (int)(1000 / battleSpeed), (int)(1000 / battleSpeed));
            EnablePassiveSkills();
            while (_unit.InBattle)
            {
                if (CanIDoSmth() is false)
                {
                    await Wait(battleSpeed);
                    continue;
                }
                try
                {
                    if (TryUseSkill(battleSpeed, out ISkillResult? skillResult) is false)
                    {
                        await Wait(battleSpeed);
                        continue;
                    }
                }
                catch (Exception ex)
                {

                }

                RefreshWaitingTimer();
                SkillsCooldownWaiting = false;
                await Task.Delay((int)(globalCooldown / battleSpeed));
            }
            DisablePassiveSkills();
            waitingSeconds = 0;
            _timer?.Dispose();
        }

        public void RefreshWaitingTimer()
        {
            waitingSeconds = 0;
        }

        private void EnablePassiveSkills()
        {
            //TODO
        }

        private void DisablePassiveSkills()
        {
            //TODO
        }

        private void TimerCallback(object? state) 
        { 
            if (waitingSeconds >= MAX_WAITING_SECONDS)
            {
                _timer!.Dispose();
                (_unit as ITarget).LeaveBattle();
                return;
            }
            waitingSeconds++;
        }

        private async Task Wait(double battleSpeed)
        {
            if (SkillsCooldownWaiting is false)
            {
                SkillsCooldownWaiting = true;
                _unit.CallUnitWaitingEvent();
            }
            await Task.Delay((int)(WAITING_COOLDOWN / battleSpeed));
        }

        private bool TryUseSkill(double battleSpeed, out ISkillResult? skillResult)
        {
            for (int i = (int)SkillPriority.PrimalPriority; i > -1; i--)
            {
                var skill = _unit.Skills.FirstOrDefault(x => (int)x.Priority == i && x.CanUseSkill);
                if (skill is null || CanUseSkillOnTargets(skill.MainLeverage.Type) is false)
                    continue;

                var targets = _targetSystem.FindTargets(skill.MainLeverage, _unit.TeamNumber);
                if (targets is null || targets.Any() is false)
                    continue;

                List<ITarget> targetsFixed = targets.ToList();

                skillResult = ApplyEffectsToSkillResult(skill.GetSkillResult(battleSpeed));

                if (DoActionToTargets(targetsFixed, skillResult.MainPart!) is false)
                    return false;              

                if (skillResult.AdditionalParts is not null  && skill.AdditionalLeverages is not null)
                {
                    for (int j = 0; j < skill.AdditionalLeverages.Length; j++)
                    {
                        if (skill.AdditionalLeverages[j] is null || skillResult.AdditionalParts.Length == 0 || skillResult.AdditionalParts[j] is null)
                            continue;
                        var additionalTargets = skill.MainLeverage.Type == skill.AdditionalLeverages[j].Type ? targetsFixed : _targetSystem.FindTargets(skill.AdditionalLeverages[j], _unit.TeamNumber);

                        if (additionalTargets is not null && additionalTargets.Any())
                        {
                            try
                            {
                                DoActionToTargets(additionalTargets, skillResult.AdditionalParts[j]);
                            }
                            catch (Exception ex)
                            {
                                //TODO
                            }
                        }
                    }
                }
                try
                {
                    _unit.CallUnitUseSkillOnTargetsEvent(skillResult, skill.Priority, targetsFixed);
                }
                catch (Exception ex)
                {
                    //TODO
                }
                return true;
            }
            skillResult = null;
            return false;
        }

        private ISkillResultPart ApplyEffectsToSkillPart(ISkillResultPart skillResultPart)
        {
            if (skillResultPart is SkillValuesResultPart skillValuesResultPart)
            {
                if (skillValuesResultPart.LeverageType is LeverageType.Damage or LeverageType.Recovery)
                {
                    var percentage = skillValuesResultPart.LeverageType is LeverageType.Damage ? CollectActorDamagePercentage() : CollectActorRecoveryPercentage();
                    double newValue = skillValuesResultPart.Value + skillValuesResultPart.Value * percentage / 100;
                    skillValuesResultPart.UpdateValue(newValue > 0 ? newValue : 0);
                }
                return skillValuesResultPart;
            }
            else if (skillResultPart is SkillEffectResultPart skillEffectResultPart)
            {
                if (skillEffectResultPart.EffectData is IPeriodicEffectCompleteData data)
                {
                    if (skillEffectResultPart.Effect is TargetPeriodicDamageEffect)
                    {
                        data.StoredIncomingAdditionalPercentage = CollectActorDamagePercentage();
                    }

                    if (skillEffectResultPart.Effect is TargetPeriodicRecoveryEffect)
                    {
                        data.StoredIncomingAdditionalPercentage = CollectActorRecoveryPercentage();
                    }
                }
                return skillEffectResultPart;
            }

            return skillResultPart;
        }

        private ISkillResult ApplyEffectsToSkillResult(ISkillResult skillResult)
        {
            if (skillResult.MainPart is not null)
                skillResult.MainPart = ApplyEffectsToSkillPart(skillResult.MainPart);

            if (skillResult.AdditionalParts is not null)
            {
                for (int i = 0; i < skillResult.AdditionalParts.Length; i++)
                {
                    if (skillResult.AdditionalParts[i] is not null)
                        skillResult.AdditionalParts[i] = ApplyEffectsToSkillPart(skillResult.AdditionalParts[i]);
                }
            }

            return skillResult;
        }

        private bool CanIDoSmth()
        {
            if (CanUseAnySkill)
            {
                // могу ли я дамажить?
                if (HasDamageSkills)
                    return true;               

                // могу ли я восстанавливать хп?
                if (HasRecoverySkills)
                    return true;

                // могу ли я создать что-то?
                if (HasCreationSkills)
                    return true;

                // могу ли я накладывать положительные эффекты?
                if (HasPoisitiveEffectApplyingSkills)
                    return true;

                // могу ли я накладывать отрицательные эффекты?
                if (HasNegativeEffectApplyingSkills)
                    return true;

                // могу ли я снимать положительные эффекты?
                if (HasPositiveEffectRemovalSkills)
                    return true;

                // могу ли я снимать отрицательные эффекты?
                if (HasNegativeEffectRemovalSkills)
                    return true;
            }

            return false;
        }

        private bool DoActionToTargets(IEnumerable<ITarget>? targets, ISkillResultPart skillResultPart)
        {
            if (targets is null || skillResultPart is null)
            {
                return false;
            }
            try
            {
                switch (skillResultPart.LeverageType)
                {
                    case LeverageType.Damage:
                        var damageResultPart = ((SkillValuesResultPart)skillResultPart);
                        targets.ToList().ForEach(x => damageResultPart.UpdateValue(x.DamageTarget(damageResultPart.Value)));
                        return true;

                    case LeverageType.Recovery:
                        var recoveryResultPart = ((SkillValuesResultPart)skillResultPart);
                        targets.ToList().ForEach(x => recoveryResultPart.UpdateValue(x.RecoverTarget(recoveryResultPart.Value)));
                        return true;

                    case LeverageType.NegativeEffectApplying:
                    case LeverageType.PositiveEffectApplying:
                        var effectResultPart = (SkillEffectResultPart)skillResultPart;
                        targets.ToList().ForEach(x => x.ApplyEffect(effectResultPart));
                        return true;

                    case LeverageType.PositiveEffectRemoving:
                    case LeverageType.NegativeEffectRemoving:
                        var effectsRemovingResultPart = (SkillEffectRemovingResultPart)skillResultPart;
                        targets.ToList().ForEach(x => x.RemoveEffects(effectsRemovingResultPart.Effects));
                        return true;

                    default: return false;
                }
            }
            catch (Exception ex)
            {
                //TODO
                return false;
            }
        }

        private bool HasNegativeEffectApplyingSkills => CanUseSkill(LeverageType.NegativeEffectApplying);
        private bool HasPoisitiveEffectApplyingSkills => CanUseSkill(LeverageType.PositiveEffectApplying);
        private bool HasNegativeEffectRemovalSkills => CanUseSkill(LeverageType.NegativeEffectRemoving);
        private bool HasPositiveEffectRemovalSkills => CanUseSkill(LeverageType.PositiveEffectRemoving);
        private bool HasCreationSkills => CanUseSkill(LeverageType.Creation);
        private bool HasRecoverySkills => CanUseSkill(LeverageType.Recovery);
        private bool HasDamageSkills => CanUseSkill(LeverageType.Damage);
        private bool CanUseSkill(LeverageType leverageType) => _unit.Skills.Any(x => x.MainLeverage.Type == leverageType);

        private bool CanUseSkillOnTargets(LeverageType type)
        {
            var _myEnemyTargets = _battle.GetEnemies(_unit.TeamNumber);
            var _myAlliesTargets = _battle.GetAllies(_unit.TeamNumber);

            if (type is LeverageType.Damage && _myEnemyTargets.Count > 0)
                return true;

            if (type is LeverageType.Recovery && _myAlliesTargets.Count(x => x.Health < x.MaxHealth) > 0)
                return true;

            if (type is LeverageType.NegativeEffectRemoving && _myAlliesTargets.Any(x => x.Effects.NegativeEffects.Count > 0))
                return true;

            if (type is LeverageType.NegativeEffectApplying && _myEnemyTargets.Count > 0)
                return true;

            if (type is LeverageType.PositiveEffectApplying && _myAlliesTargets.Count > 0)
                return true;

            if (type is LeverageType.PositiveEffectRemoving && _myEnemyTargets.Any(x => x.Effects.PositiveEffects.Count > 0))
                return true;

            return false;
        }

        private double CollectActorDamagePercentage() => (_startDamagePercentageCalculated ? _startDamage : CollectActorStartDamagePercentage()) + CollectActorDynamicDamagePercentage();
        
        private double CollectActorRecoveryPercentage() => (_startRecoveryPercentageCalculated ? _startRecovery : CollectActorStartRecoveryPercentage()) + CollectActorDynamicRecoveryPercentage();

        //TODO
        private double CollectActorDynamicDamagePercentage() => 0;

        //TODO
        private double CollectActorDynamicRecoveryPercentage() => 0;

        private double CollectActorStartDamagePercentage()
        {
            var startEffects = _unit.Data.StartEffects;
            double summaryPercentage = 0;
            foreach (var startGain in startEffects.PositiveEffects.Where(x => x is ActorStartGain).Cast<ActorStartGain>())
            {
                summaryPercentage += startEffects.TryGetPercentage(startGain);
            }

            foreach (var startWeakness in startEffects.NegativeEffects.Where(x => x is ActorStartWeakness).Cast<ActorStartWeakness>())
            {
                summaryPercentage -= startEffects.TryGetPercentage(startWeakness);
            }
            return summaryPercentage;
        }

        private double CollectActorStartRecoveryPercentage()
        {
            var startEffects = _unit.Data.StartEffects;
            double summaryPercentage = 0;
            foreach (var startZealtory in startEffects.PositiveEffects.Where(x => x is ActorStartZealtory).Cast<ActorStartZealtory>())
            {
                summaryPercentage += startEffects.TryGetPercentage(startZealtory);
            }

            foreach (var startDespondency in startEffects.NegativeEffects.Where(x => x is ActorStartDespondency).Cast<ActorStartDespondency>())
            {
                summaryPercentage -= startEffects.TryGetPercentage(startDespondency);
            }
            return summaryPercentage;
        }
    }
}
