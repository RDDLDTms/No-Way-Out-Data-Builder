using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_Abstractions.Skills;
using NWO_DataBuilder.Core.LocalData.LeverageSources;
using NWO_DataBuilder.Core.Models;
using NWO_DataBuilder.Core.Models.Leverages.LeverageData;

namespace NWO_DataBuilder.Core.Tests.Units
{
    internal sealed class ChaosSower : UnitBase
    {
        public override AccessLevel AccessLevel => AccessLevel.Fourth;
        public override bool IsBase => false;
        public override bool IsMech => false;
        public override bool IsOrganic => true;
        public override bool IsAlive => true;
        public override Faction Faction => Faction.Knowledge;
        public override string RussianDisplayName => "Сеятель хаоса";
        public override string UniversalName => "Chaos sower";
        public override double MaxHealth => 450;

        public override List<IUnitLeveragesSource> CreateLeveragesSources()
        {
            var allLSources = DictionaryStorage.GetInstance().AllLeveragesSources;
            LeveragesSourcesCreated = true;
            var touch = allLSources[nameof(TouchLS)];
            var seizure = allLSources[nameof(SeizureLS)];
            var purifying = allLSources[nameof(PurifyingLS)];
            var barrier = allLSources[nameof(BarrirerLS)];
            var viscousSphere = allLSources[nameof(ViscousSphereLS)];
            var insanity = allLSources[nameof(InsanityLS)];
            return _leveragesSources = new()
            {
                new UnitLeveragesSource(touch, SkillPriority.PrimalPriority,
                    new InstantLeverageData(touch.MainLeverage.Id, minValue: 15, maxValue: 30, cooldown: 5000),
                    new InstantLeverageData(touch.AdditionalLeverages![0].Id, minValue: 5, maxValue: 9, cooldown: 5000)),

                new UnitLeveragesSource(barrier, SkillPriority.SecondaryPriority,
                    new InstantCreationData(barrier.MainLeverage.Id, cooldown: 8000, duration:5000)),

                new UnitLeveragesSource(viscousSphere, SkillPriority.HighPriority,
                    new PercentageEffectCompleteData(viscousSphere.MainLeverage.Effects[0].Id, Id, cooldown: 3000, duration: 7000,  percentage: 50)),

                new UnitLeveragesSource(insanity, SkillPriority.AdvancedPriority,
                    new NonPeriodicEffectDataWithDuration(insanity.MainLeverage.Effects[0].Id, cooldown: 11000, duration: 5000)),

                new UnitLeveragesSource(purifying, SkillPriority.SpecialSupportPriority,
                    new EffectRemovalData(purifying.MainLeverage.Id, cooldown: 6000)),

                new UnitLeveragesSource(seizure, SkillPriority.BasePriority,
                    new InstantLeverageData(seizure.MainLeverage.Id, minValue: 3, maxValue: 5, cooldown: 2000))
            };
        }
    }
}
