using DataBuilder.Effects;
using DataBuilder.TargetSystem;
using NWO_Abstractions;
using NWO_Abstractions.Battles;

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
                var skillResult = TryUseSkill(battleSpeed);

                if (skillResult is null)
                {
                    await Wait(battleSpeed);
                    continue;
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

        private ISkillResult? TryUseSkill(double battleSpeed)
        {
            for (int i = (int)SkillPriority.PrimalPriority; i > -1; i--)
            {
                var skill = _unit.Skills.FirstOrDefault(x => (int)x.Priority == i && x.CanUseSkill);
                if (skill is null || CanUseSkillOnTargets(skill.MainLeverage.Type) is false)
                    continue;

                var targets = _targetSystem.FindTargets(skill.MainLeverage, _unit.TeamNumber);
                if (targets is null || targets.Any() is false)
                    continue;

                ISkillResult skillResult = ApplyEffectsToSkillResult(skill.GetSkillResult(battleSpeed));

                if (DoActionToTargets(skill.MainLeverage.Type, targets, skillResult.MainPart!) is false)
                {
                    return skillResult;
                }

                if (skillResult.AdditionalPart is not null && skill.AdditionalLeverages is not null)
                {
                    for (int j = 0; j < skill.AdditionalLeverages.Length; j++)
                    {
                        if (skill.AdditionalLeverages[j] is null)
                            continue;
                        var additionaltargets = skill.MainLeverage.Type == skill.AdditionalLeverages[j].Type ? targets : _targetSystem.FindTargets(skill.AdditionalLeverages[j], _unit.TeamNumber);

                        if (additionaltargets is not null && additionaltargets.Any())
                        {
                            DoActionToTargets(skill.AdditionalLeverages[j].Type, additionaltargets, skillResult.AdditionalPart[j]);
                        }
                    }
                }
                _unit.CallUnitActionEvent(skillResult);
                return skillResult;
            }
            return null;
        }

        private int ApplyEffectsToSkillPart(ISkillResultPart skillResultPart)
        {
            if (skillResultPart.LeverageType is LeverageType.InstantDamage or LeverageType.PassiveDamage)
            {
                int percentage = 0;
                foreach (var postivieActorDamageEffect in _unit.Effects.PositiveEffects.Where(x => x is ActorDamageIncreaseEffect).Cast<ActorDamageIncreaseEffect>())
                {
                    percentage += postivieActorDamageEffect.Percentage;
                }
                foreach (var negativeActorDamageEffect in _unit.Effects.NegativeEffects.Where(x => x is ActorDamageDecreaseEffect).Cast<ActorDamageDecreaseEffect>())
                {
                    percentage -= negativeActorDamageEffect.Percentage;
                }
                skillResultPart.Value += skillResultPart.Value * percentage / 100;
                return (int)skillResultPart.Value! < 0 ? 0: (int)skillResultPart.Value!;
            }

            if (skillResultPart.LeverageType is LeverageType.InstantRecovery or LeverageType.PassiveRecovery)
            {
                int percentage = 0;
                foreach (var positiveActorRecoveryEffect in _unit.Effects.PositiveEffects.Where(x => x is ActorRecoveringIncreaseEffect).Cast<ActorRecoveringIncreaseEffect>())
                {
                    percentage += positiveActorRecoveryEffect.Percentage;
                }
                foreach (var negativeActorRecoveryPowerEffect in _unit.Effects.NegativeEffects.Where(x => x is ActorRecoveringDecreaseEffect).Cast<ActorRecoveringDecreaseEffect>())
                {
                    percentage -= negativeActorRecoveryPowerEffect.Percentage;
                }
                skillResultPart.Value += skillResultPart.Value * percentage /100;
                return (int)skillResultPart.Value! < 0 ? 0 : (int)skillResultPart.Value!;
            }

            return (int)skillResultPart.Value!;
        }

        private ISkillResult ApplyEffectsToSkillResult(ISkillResult skillResult)
        {
            if (skillResult.MainPart is SkillResultPart mainPart && IsDamageOrRecovery(mainPart.LeverageType))
            {
                skillResult.MainPart.Value = ApplyEffectsToSkillPart(mainPart);
            }

            if (skillResult.AdditionalPart is not null && skillResult.AdditionalPart.Any())
            {
                for (int i = 0; i < skillResult.AdditionalPart.Length; i++)
                {
                    if (skillResult.AdditionalPart[i] is SkillResultPart additionalPart && IsDamageOrRecovery(additionalPart.LeverageType))
                        skillResult.AdditionalPart[i].Value = ApplyEffectsToSkillPart(additionalPart);
                }
            }

            return skillResult;
        }

        private bool IsDamageOrRecovery(LeverageType type)
            => type is LeverageType.InstantDamage or LeverageType.InstantRecovery or LeverageType.PassiveDamage or LeverageType.PassiveRecovery;

        private bool CanIDoSmth()
        {
            if (CanUseAnySkill)
            {
                // могу ли я дамажить?
                if (CanDamage())
                {
                    return true;
                }

                // могу ли я восстанавливать хп?
                if (CanRecover())
                {
                    return true;
                }

                // могу ли я создать что-то?
                if (CanCreate())
                {
                    //TODO
                    return true;
                }

                // могу ли я накладывать положительные эффекты?
                if (CanApplyPositiveEffect())
                {
                    //TODO
                    return true;
                }

                // могу ли я накладывать отрицательные эффекты?
                if (CanApplyNegativeEffect())
                {
                    //TODO
                    return true;
                }

                // могу ли я снимать положительные эффекты?
                if (CanRemovePositiveEffect())
                {
                    //TODO
                    return true;
                }

                // могу ли я снимать отрицательные эффекты?
                if (CanRemoveNegativeEffect())
                {
                    //TODO
                    return true;
                }
            }

            return false;
        }

        private bool DoActionToTargets(LeverageType type, IEnumerable<ITarget>? targets, ISkillResultPart skillResultPart)
        {
            if (targets is null || skillResultPart is null)
            {
                return false;
            }
            
            switch (type)
            {
                case LeverageType.InstantDamage:
                    targets.ToList().ForEach(x => skillResultPart.Value = x.DamageTarget((int)skillResultPart.Value!));
                    return true;

                case LeverageType.InstantRecovery:
                    targets.ToList().ForEach(x => x.RecoverTarget((int)skillResultPart.Value!));
                    return true;

                case LeverageType.NegativeEffectApplying:
                    targets.ToList().ForEach(x => x.ApplyNegativeEffect(skillResultPart.EffectForTargets!, skillResultPart.EffectForTargets is TargetPeriodicDamageEffect ? GetActorDamagePercentage() : 0));
                    return true;

                case LeverageType.PositiveEffectApplying:
                    targets.ToList().ForEach(x => x.ApplyPositiveEffect(skillResultPart.EffectForTargets!, skillResultPart.EffectForTargets is TargetPeriodicRecoveryEffect ? GetActorRecoveryPercentage() : 0));
                    return true;

                case LeverageType.PositiveEffectRemoval:
                    targets.ToList().ForEach(x => x.RemovePositiveEffect(skillResultPart.EffectForTargets!));
                    return true;

                case LeverageType.NegativeEffectRemoval:
                    targets.ToList().ForEach(x => x.RemoveNegativeEffect(skillResultPart.EffectForTargets!));
                    return true;

                case LeverageType.Creation:
                    //TODO
                    return true;

                default: return false;
            }
        }

        private bool CanRemovePositiveEffect()
        {
            return CanUseSkill(LeverageType.PositiveEffectRemoval);
        }

        private bool CanRemoveNegativeEffect()
        {
            return CanUseSkill(LeverageType.NegativeEffectRemoval);
        }

        private bool CanApplyPositiveEffect()
        {
            return CanUseSkill(LeverageType.PositiveEffectApplying);
        }

        private bool CanApplyNegativeEffect()
        {
            return CanUseSkill(LeverageType.NegativeEffectApplying);
        }

        private bool CanCreate()
        {
            return CanUseSkill(LeverageType.Creation);
        }

        private bool CanRecover()
        {
            return CanUseSkill(LeverageType.InstantRecovery);
        }

        private bool CanDamage()
        {
            return CanUseSkill(LeverageType.InstantDamage);
        }

        private bool CanUseSkill(LeverageType leverageType)
        {
            return _unit.Skills.Any(x => x.MainLeverage.Type == leverageType);
        }

        private bool CanUseSkillOnTargets(LeverageType type)
        {
            var _myEnemyTargets = _battle.GetEnemies(_unit.TeamNumber);
            var _myAlliesTargets = _battle.GetAllies(_unit.TeamNumber);

            if (type is LeverageType.InstantDamage && _myEnemyTargets.Count > 0)
                return true;

            if (type is LeverageType.InstantRecovery && _myAlliesTargets.Count(x => x.Health < x.MaxHealth) > 0)
                return true;

            if (type is LeverageType.NegativeEffectRemoval && _myAlliesTargets.Any(x => x.Effects.NegativeEffects.Count > 0))
                return true;

            if (type is LeverageType.NegativeEffectApplying && _myEnemyTargets.Count > 0)
                return true;

            if (type is LeverageType.PositiveEffectApplying && _myAlliesTargets.Count > 0)
                return true;

            if (type is LeverageType.PositiveEffectRemoval && _myEnemyTargets.Any(x => x.Effects.PositiveEffects.Count > 0))
                return true;

            return false;
        }

        private int GetActorDamagePercentage()
        {
            int summaryPercentage = 0;
            foreach (ActorDamageIncreaseEffect damInc in (_unit as ITarget).Effects.PositiveEffects.Where(x => x is ActorDamageIncreaseEffect).Cast<ActorDamageIncreaseEffect>())
            {
                summaryPercentage += damInc.Percentage;
            }

            foreach (ActorDamageDecreaseEffect damDec in _unit.Data.StartEffects.NegativeEffects.Where(x => x is ActorDamageDecreaseEffect).Cast<ActorDamageDecreaseEffect>())
            {
                summaryPercentage -= damDec.Percentage;
            }
            return summaryPercentage;
        }

        private int GetActorRecoveryPercentage()
        {
            int summaryPercentage = 0;
            foreach (ActorRecoveringIncreaseEffect recInc in _unit.Data.StartEffects.PositiveEffects.Where(x => x is ActorRecoveringIncreaseEffect).Cast<ActorRecoveringIncreaseEffect>())
            {
                summaryPercentage += recInc.Percentage;
            }

            foreach (ActorRecoveringDecreaseEffect recDec in _unit.Data.StartEffects.NegativeEffects.Where(x => x is ActorRecoveringDecreaseEffect).Cast<ActorRecoveringDecreaseEffect>())
            {
                summaryPercentage -= recDec.Percentage;
            }
            return summaryPercentage;
        }
    }
}
