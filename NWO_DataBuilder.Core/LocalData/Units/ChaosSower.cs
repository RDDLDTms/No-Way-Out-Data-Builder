using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Effects;
using DataBuilder.Leverages;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_DataBuilder.Core.Models;
using  NWO_DataBuilder.Core.LocalData.LeverageSources;

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
            return _leveragesSources = new()
            {
                new UnitLeveragesSource(allLSources[nameof(TouchLS)], SkillPriority.PrimalPriority,
                    new LeverageInstantStrike(minValue: 15, maxValue: 30, cooldown: 5),
                    new LeverageInstantRecovery(minValue: 5, maxValue: 9, cooldown: 5)),

                new UnitLeveragesSource(allLSources[nameof(BarrirerLS)], SkillPriority.SecondaryPriority,
                    new EffectBase(allLSources[nameof(BarrirerLS)].MainLeverage, duration:5, cooldown: 8)),

                new UnitLeveragesSource(allLSources[nameof(ViscousSphereLS)], SkillPriority.HighPriority,
                    new TargetDefenceIncreaseEffect(allLSources[nameof(ViscousSphereLS)].MainLeverage, duration: 7, cooldown: 3, percentage: 50)),

                new UnitLeveragesSource(allLSources[nameof(InsanityLS)], SkillPriority.AdvancedPriority,
                    new TargetControlEffect(allLSources[nameof(InsanityLS)].MainLeverage, duration: 5, cooldown: 11)),

                new UnitLeveragesSource(allLSources[nameof(PurifyingLS)], SkillPriority.SpecialSupportPriority,
                    new LeverageNegativeEffectsRemoval(cooldown: 6)),

                new UnitLeveragesSource(allLSources[nameof(SeizureLS)], SkillPriority.BasePriority,
                    new LeverageInstantStrike(minValue: 3, maxValue: 5, cooldown: 2))
            };
        }
    }
}
