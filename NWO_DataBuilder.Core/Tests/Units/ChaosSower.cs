using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Effects;
using DataBuilder.Leverages;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_DataBuilder.Core.Models;
using NWO_DataBuilder.Core.Tests.LeverageSources;

namespace NWO_DataBuilder.Core.Tests.Units
{
    internal sealed class ChaosSower : UnitBase
    {
        public override AccessLevel AccessLevel => AccessLevel.Fourth;
        public override bool IsBase => false;
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
                    new LeverageHit(minValue: 15, maxValue: 30, cooldown: 5, LeverageType.Damage),
                    new LeverageHit(minValue: 5, maxValue: 9, cooldown: 5, LeverageType.Recovery)),

                new UnitLeveragesSource(allLSources[nameof(BarrirerLS)], SkillPriority.HighPriority,
                    new EffectBase(5, allLSources[nameof(BarrirerLS)].MainLeverage, cooldown: 8)),

                new UnitLeveragesSource(allLSources[nameof(ViscousSphereLS)], SkillPriority.AdvancedPriority,
                    new TargetDefenceIncreaseEffect(duration: 6, allLSources[nameof(ViscousSphereLS)].MainLeverage, cooldown: 10, percentage: 5)),

                new UnitLeveragesSource(allLSources[nameof(InsanityLS)], SkillPriority.SpecialSupportPriority,
                    new TargetControlEffect(duration: 5, allLSources[nameof(InsanityLS)].MainLeverage, cooldown: 11)),

                new UnitLeveragesSource(allLSources[nameof(PurifyingLS)], SkillPriority.BasePriority,
                    new LeverageEffectsRemoval(cooldown: 6, LeverageType.NegativeEffectRemoval))
            };
        }
    }
}
