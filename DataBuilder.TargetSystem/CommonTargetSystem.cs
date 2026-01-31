using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions;
using NWO_Abstractions.Battles;
using NWO_Abstractions.Leverages;

namespace DataBuilder.TargetSystem
{
    public class CommonTargetSystem
    {
        private IBattleModelling _battle;

        public CommonTargetSystem(IBattleModelling battle)
        {
            _battle = battle;
        }

        public IEnumerable<ITarget>? FindTargets(ILeverage leverage, int unitTeamNumber)
        {
            return leverage.Type switch
            {
                LeverageType.Damage or LeverageType.NegativeEffectApplying => FindNonImmunedEnemies(leverage, unitTeamNumber),
                LeverageType.Recovery => FindSuitableAlliesForRecover(leverage, unitTeamNumber),
                LeverageType.PositiveEffectApplying => FindNonImmunedAllies(leverage, unitTeamNumber),
                _ => null,
            };
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
            //TODO 23.11.2025 сделать обновление старых эффектов с перекрытием
            return alliasTargets ? _battle.GetAllies(teamNumber) : _battle.GetEnemies(teamNumber)
                .Where(x => x.Immunes.
                   Any(x => x.ImmuneClass == leverage.Class) is false);
        }
    }
}
