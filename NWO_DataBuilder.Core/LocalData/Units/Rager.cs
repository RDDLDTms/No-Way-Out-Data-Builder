using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Effects;
using DataBuilder.Leverages;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_DataBuilder.Core.Models;
using  NWO_DataBuilder.Core.LocalData.LeverageSources;

namespace NWO_DataBuilder.Core.Tests.Units
{
    internal sealed class Rager : UnitBase
    {
        public override AccessLevel AccessLevel => AccessLevel.Fifth;
        public override bool IsBase => false;
        public override bool IsMech => false;
        public override bool IsOrganic => true;
        public override bool IsAlive => true;
        public override double MaxHealth => 666;
        public override Faction Faction => Faction.Faith;
        public override string RussianDisplayName => "Яростень";
        public override string UniversalName => "Rager";

        public override List<IUnitLeveragesSource> CreateLeveragesSources()
        {
            var allLSources = DictionaryStorage.GetInstance().AllLeveragesSources;
            var flamingAxe = allLSources[nameof(FlamingAxeLS)];
            var flamingBroadsword = allLSources[nameof(FlamingBroadswordLS)];
            var strikeWithFire = allLSources[nameof(StrikeWithFireLS)];
            return _leveragesSources = new()
            {
                new UnitLeveragesSource(flamingAxe, SkillPriority.PrimalPriority,
                    new LeverageHit(minValue: 50, maxValue: 55, cooldown: 8, LeverageType.Damage),
                    new TargetPeriodicDamageEffect(duration: 8, flamingAxe.AdditionalLeverage!, cooldown: 14, minValue: 10, maxValue: 12)),

                new UnitLeveragesSource(flamingBroadsword, SkillPriority.SecondaryPriority,
                    new LeverageHit(minValue: 35, maxValue: 38, cooldown: 3, LeverageType.Damage),
                    new TargetPeriodicDamageEffect(duration: 3, flamingBroadsword.AdditionalLeverage!, cooldown: 6, minValue: 5, maxValue: 8)),

                new UnitLeveragesSource(allLSources[nameof(ExplosiveRoarLS)], SkillPriority.HighPriority,
                    new LeverageHit(minValue: 30, maxValue: 67, cooldown: 10, LeverageType.Damage)),

                new UnitLeveragesSource(allLSources[nameof(ShaftStrikeLS)], SkillPriority.MiddlePriority,
                    new LeverageHit(minValue: 13, maxValue: 18, cooldown: 4, LeverageType.Damage)),

                new UnitLeveragesSource(allLSources[nameof(ArmouredBodyLS)], SkillPriority.SubsidiaryPriority,
                    new LeverageHit(minValue: 10, maxValue: 20, cooldown: 5, LeverageType.Damage)),

                new UnitLeveragesSource(strikeWithFire, SkillPriority.BasePriority,
                    new LeverageHit(minValue: 5, maxValue: 8, cooldown: 3, LeverageType.Damage),
                    new TargetPeriodicDamageEffect(duration: 2, strikeWithFire.AdditionalLeverage!, cooldown: 6, minValue: 2, maxValue: 5))
            };
        }
    }
}
