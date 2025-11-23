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

                new UnitLeveragesSource(allLSources[nameof(BarrirerLS)], SkillPriority.SecondaryPriority,
                    new EffectBase(5, allLSources[nameof(BarrirerLS)].MainLeverage, cooldown: 8)),

                new UnitLeveragesSource(allLSources[nameof(ViscousSphereLS)], SkillPriority.HighPriority,
                    new TargetDefenceIncreaseEffect(duration: 7, allLSources[nameof(ViscousSphereLS)].MainLeverage, cooldown: 3, percentage: 50)),

                new UnitLeveragesSource(allLSources[nameof(InsanityLS)], SkillPriority.AdvancedPriority,
                    new TargetControlEffect(duration: 5, allLSources[nameof(InsanityLS)].MainLeverage, cooldown: 11)),

                new UnitLeveragesSource(allLSources[nameof(PurifyingLS)], SkillPriority.SpecialSupportPriority,
                    new LeverageEffectsRemoval(cooldown: 6, LeverageType.NegativeEffectRemoval)),

                new UnitLeveragesSource(allLSources[nameof(SeizureLS)], SkillPriority.BasePriority,
                    new LeverageHit(minValue: 3, maxValue: 5, cooldown: 2, LeverageType.Damage))
            };
        }
    }
}
