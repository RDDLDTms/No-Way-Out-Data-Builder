using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions;

namespace DataBuilder.TargetSystem
{
    public class CommonTargetSystem
    {
        private IBattleModelling _battle;
        private IUnit _unit;

        public CommonTargetSystem(IBattleModelling battle, IUnit unit)
        {
            _battle = battle;
            _unit = unit;
        }

        public IEnumerable<ITarget>? FindTargets(IUnitSkill skill, bool mainLeverage)
        {
            ILeverage leverage = mainLeverage ? skill.MainLeverage : skill.MainLeverage;
            switch (leverage.Class.Type)
            {
                case LeverageType.Damage:
                case LeverageType.NegativeEffectApplying:
                    return FindNonImmunedEnemies(leverage);

                case LeverageType.Recovery:
                    return FindSuitableAlliesForRecover(leverage);

                case LeverageType.PositiveEffectApplying:
                    return FindNonImmunedAllies(leverage);
                    // TODO    
                case LeverageType.PositiveEffectRemoval:
                case LeverageType.NegativeEffectRemoval:
                case LeverageType.Creation:
                default: return null;
            }
        }

        private IEnumerable<ITarget>? FindSuitableAlliesForRecover(ILeverage leverage)
        {
            var myAlliesTargets = _battle.GetAllies(_unit.TeamNumber);
            var suitableTargets = leverage.Class.Restrictions switch
            {
                LeverageClassRestrictions.MechOnly => myAlliesTargets.Where(x => x.Health < x.MaxHealth && !x.IsOrganic && !x.IsAlive && x.IsMech),
                LeverageClassRestrictions.OrganicOnly => myAlliesTargets.Where(x => x.Health < x.MaxHealth && x.IsOrganic && !x.IsAlive && !x.IsMech),
                LeverageClassRestrictions.AliveOnly => myAlliesTargets.Where(x => x.Health < x.MaxHealth && !x.IsOrganic && x.IsAlive && !x.IsMech),
                LeverageClassRestrictions.OrganicAndAlive => myAlliesTargets.Where(x => x.Health < x.MaxHealth && x.IsOrganic && x.IsAlive && !x.IsMech),
                _ => myAlliesTargets.Where(x => x.Health < x.MaxHealth),
            };

            if (leverage.Targeting is LeverageTargeting.Single or LeverageTargeting.Place)
            {
                var suitableTarget = suitableTargets.FirstOrDefault();
                return suitableTarget is null ? null : new List<ITarget>() { suitableTarget };
            }

            return suitableTargets;
        }

        private IEnumerable<ITarget>? FindNonImmunedAllies(ILeverage leverage)
        {
            var nonImmunedAllies = _battle.GetAllies(_unit.TeamNumber)
                .Where(x => x.Immunes.
                   Any(x => x.ImmuneClass == leverage.Class) is false);

            if (leverage.Targeting is LeverageTargeting.Single or LeverageTargeting.Place)
            {
                var nonImmunedTarget = nonImmunedAllies.FirstOrDefault();
                return nonImmunedTarget is null ? null : new List<ITarget>() { nonImmunedTarget };
            }

            return nonImmunedAllies;
        }

        private IEnumerable<ITarget>? FindNonImmunedEnemies(ILeverage leverage)
        {
            var nonImmunedEnemies = _battle.GetEnemies(_unit.TeamNumber)
                .Where(x => x.Immunes.
                   Any(x => x.ImmuneClass == leverage.Class) is false);

            if (leverage.Targeting is LeverageTargeting.Single or LeverageTargeting.Place)
            {
                var nonImmunedTarget = nonImmunedEnemies.FirstOrDefault();
                return nonImmunedTarget is null ? null : new List<ITarget>() { nonImmunedTarget };
            }

            return nonImmunedEnemies;
        }
    }
}
