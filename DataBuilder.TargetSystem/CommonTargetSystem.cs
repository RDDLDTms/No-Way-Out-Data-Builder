using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions;
using NWO_Abstractions.Battles;

namespace DataBuilder.TargetSystem
{
    public class CommonTargetSystem
    {
        private IBattleModelling _battle;

        public CommonTargetSystem(IBattleModelling battle)
        {
            _battle = battle;
        }

        public IEnumerable<ITarget>? FindTargets(IUnitSkill skill, bool mainLeverage, int unitTeamNumber)
        {
            ILeverage leverage = mainLeverage ? skill.MainLeverage : skill.AdditionalLeverage!;
            switch (leverage.Type)
            {
                case LeverageType.Damage:
                case LeverageType.NegativeEffectApplying:
                    return FindNonImmunedEnemies(leverage, unitTeamNumber);

                case LeverageType.Recovery:
                    return FindSuitableAlliesForRecover(leverage, unitTeamNumber);

                case LeverageType.PositiveEffectApplying:
                    return FindNonImmunedAllies(leverage, unitTeamNumber);

                case LeverageType.PositiveEffectRemoval:
                case LeverageType.NegativeEffectRemoval:
                case LeverageType.Creation:
                case LeverageType.None:
                default: return null;
            }
        }

        private IEnumerable<ITarget>? FindSuitableAlliesForRecover(ILeverage leverage, int teamNumber) => 
            FindNonImmunedAllies(leverage, teamNumber)?.Where(x => x.Health < x.MaxHealth);

        private IEnumerable<ITarget>? FindNonImmunedAllies(ILeverage leverage, int unitTeamNumber)
        {
            var nonImmunedAllies = GetNonImmunedTargets(leverage, unitTeamNumber, true);
            nonImmunedAllies = FilterTargetsByRestrictions(leverage, nonImmunedAllies);
            if (leverage.Targeting is LeverageTargeting.Single or LeverageTargeting.Place)
            {
                var nonImmunedTarget = nonImmunedAllies.FirstOrDefault();
                return nonImmunedTarget is null ? null : new List<ITarget>() { nonImmunedTarget };
            }

            return nonImmunedAllies;
        }

        private IEnumerable<ITarget>? FindNonImmunedEnemies(ILeverage leverage, int unitTeamNumber)
        {
            var nonImmunedEnemies = GetNonImmunedTargets(leverage, unitTeamNumber, false);
            nonImmunedEnemies = FilterTargetsByRestrictions(leverage, nonImmunedEnemies);

            if (leverage.Targeting is LeverageTargeting.Single or LeverageTargeting.Place)
            {
                var nonImmunedTarget = nonImmunedEnemies.FirstOrDefault();
                return nonImmunedTarget is null ? null : new List<ITarget>() { nonImmunedTarget };
            }

            return nonImmunedEnemies;
        }

        private IEnumerable<ITarget> FilterTargetsByRestrictions(ILeverage leverage, IEnumerable<ITarget> targets)
        {
            return leverage.Class.Restrictions switch
            {
                LeverageClassRestrictions.MechOnly => targets.Where(x => !x.IsOrganic && !x.IsAlive && x.IsMech),
                LeverageClassRestrictions.OrganicOnly => targets.Where(x => x.IsOrganic && !x.IsAlive && !x.IsMech),
                LeverageClassRestrictions.AliveOnly => targets.Where(x => !x.IsOrganic && x.IsAlive && !x.IsMech),
                LeverageClassRestrictions.OrganicAndAlive => targets.Where(x => x.IsOrganic && x.IsAlive && !x.IsMech),
                _ => targets
            };  
        }

        private IEnumerable<ITarget> GetNonImmunedTargets(ILeverage leverage, int teamNumber, bool alliasTargets)
        {
            return alliasTargets ? _battle.GetAllies(teamNumber) : _battle.GetEnemies(teamNumber)
                .Where(x => x.Immunes.
                   Any(x => x.ImmuneClass == leverage.Class) is false);
        }
    }
}
