using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_Abstractions.Skills;
using NWO_DataBuilder.Core.LocalData.LeverageSources;
using NWO_DataBuilder.Core.Models;
using NWO_DataBuilder.Core.Models.Leverages.LeverageData;

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
            var explosiveRoar = allLSources[nameof(ExplosiveRoarLS)];
            var shaftStrike = allLSources[nameof(ShaftStrikeLS)];
            var armouredBody = allLSources[nameof(ArmouredBodyLS)];
            return _leveragesSources = new()
            {
                new UnitLeveragesSource(flamingAxe, SkillPriority.PrimalPriority,
                    new InstantLeverageData(flamingAxe.MainLeverage.Id, minValue: 50, maxValue: 55, cooldown: 8000),
                    new PeriodicEffectCompleteData(flamingAxe.AdditionalLeverages![0].Effects[0].Id, Id, cooldown: 14000, duration: 8000, minValue: 10, maxValue: 12, defaultDelay: 1000, startDelay: 1000 )),

                new UnitLeveragesSource(flamingBroadsword, SkillPriority.SecondaryPriority,
                    new InstantLeverageData(flamingBroadsword.MainLeverage.Id, minValue: 35, maxValue: 38, cooldown: 3000),
                    new PeriodicEffectCompleteData(flamingBroadsword.AdditionalLeverages![0].Effects[0].Id, Id, cooldown: 6000, duration: 3000, minValue: 5, maxValue: 8, defaultDelay: 1000, startDelay: 1000 )),

                new UnitLeveragesSource(explosiveRoar, SkillPriority.HighPriority,
                    new InstantLeverageData(explosiveRoar.MainLeverage.Id, minValue: 30, maxValue: 67, cooldown: 10000)),

                new UnitLeveragesSource(shaftStrike, SkillPriority.MiddlePriority,
                    new InstantLeverageData(shaftStrike.MainLeverage.Id, minValue: 13, maxValue: 18, cooldown: 4000)),

                new UnitLeveragesSource(armouredBody, SkillPriority.SubsidiaryPriority,
                    new InstantLeverageData(armouredBody.MainLeverage.Id, minValue: 10, maxValue: 20, cooldown: 5000)),

                new UnitLeveragesSource(strikeWithFire, SkillPriority.BasePriority,
                    new InstantLeverageData(strikeWithFire.MainLeverage.Id, minValue: 5, maxValue: 8, cooldown: 3000),
                    new PeriodicEffectCompleteData(strikeWithFire.AdditionalLeverages![0].Effects[0].Id, Id, cooldown: 6000, duration: 2000, minValue: 2, maxValue: 5, defaultDelay: 1000, startDelay: 1000 ))
            };
        }
    }
}
