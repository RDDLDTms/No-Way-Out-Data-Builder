using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Effects;
using DataBuilder.Effects.IncreaseEffects.EffectsOnTarget;
using DataBuilder.Leverages;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_DataBuilder.Core.Models;

namespace NWO_DataBuilder.Core.Tests.Units
{
    internal class ChaosSower : UnitBase
    {
        public override AccessLevel AccessLevel => AccessLevel.Fourth;

        public override bool IsBase => false;

        public override byte ImprovmentLevel => 0;

        public override List<Guid> Formula => new();

        public override Faction Faction => Faction.Knowledge;

        public override string RussianDisplayName => "Сеятель хаоса";

        public override string UniversalName => "Chaos sower";

        public override int MaxHealth => 450;

        protected override List<IDefence> CreateUnitDefences() => new();
        protected override List<IImmune> CreateUnitImmunes() => new();

        protected override List<IUnitLeveragesSource> CreateUnitLeveragesSources()
        {
            var allLSources = DictionaryStorage.GetInstance().AllLeveragesSources;
            LeveragesSourcesCreated = true;
            return new List<IUnitLeveragesSource>()
            {
                new UnitLeveragesSource(allLSources["Touch"], SkillPriority.PrimalPriority,
                    new LeverageHit(minValue: 15, maxValue: 30, cooldown: 5, LeverageType.Damage),
                    new LeverageHit(minValue: 5, maxValue: 9, cooldown: 5, LeverageType.Recovery)),

                new UnitLeveragesSource(allLSources["Barrier"], SkillPriority.HighPriority,
                    new EffectBase(5, allLSources["Barrier"].MainLeverage.Class, cooldown: 8, "Размещение барьера")),

                new UnitLeveragesSource(allLSources["Viscous sphere"], SkillPriority.AdvancedPriority,
                    new TargetDefenceIncreaseEffect(duration: 6, allLSources["Viscous sphere"].MainLeverage.Class, cooldown: 10, "Создание вязкой сферы", percentage: 5)),

                new UnitLeveragesSource(allLSources["Insanity"], SkillPriority.SpecialSupportPriority,
                    new TargetControlEffect(duration: 5, allLSources["Insanity"].MainLeverage.Class, cooldown: 11, "Вокруг юнита создана область помешательства")),

                new UnitLeveragesSource(allLSources["Purifying"], SkillPriority.BasePriority,
                    new LeverageEffectsRemoval(cooldown: 6, LeverageType.NegativeEffectRemoval))
            };
        }
    }
}
