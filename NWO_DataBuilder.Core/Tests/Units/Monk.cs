using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Effects.IncreaseEffects.EffectsOnTarget;
using DataBuilder.Effects.PeriodicEffects.EffectsOnTarget;
using DataBuilder.Leverages;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_DataBuilder.Core.Models;

namespace NWO_DataBuilder.Core.Tests
{
    internal class Monk : UnitBase
    {
        public override AccessLevel AccessLevel => AccessLevel.Second;

        public override bool IsBase => false;

        public override int MaxHealth => 70;

        public override byte ImprovmentLevel => 0;

        public override List<Guid> Formula => new();

        public override Faction Faction => Faction.Faith;

        public override string RussianDisplayName => "Монах";

        public override string UniversalName => "Monk";

        protected override List<IUnitLeveragesSource> CreateUnitLeveragesSources()
        {
            var allLSources = DictionaryStorage.GetInstance().AllLeveragesSources;
            LeveragesSourcesCreated = true;
            return new List<IUnitLeveragesSource>()
            {
                new UnitLeveragesSource(allLSources["Word of healer"], SkillPriority.MiddlePriority, 
                    new LeverageHit(minValue: 20, maxValue: 27, cooldown: 6, LeverageType.Recovery)),

                new UnitLeveragesSource(allLSources["Bless"], SkillPriority.SubsidiaryPriority, 
                    new TargetPeriodicRecoveryEffect(duration: 6, allLSources["Bless"].MainLeverage.Class, cooldown: 8, "Благо", minValue: 4, maxValue: 7)),

                new UnitLeveragesSource(allLSources["Defence"], SkillPriority.HighPriority, 
                    new TargetDefenceIncreaseEffect(duration: 7, allLSources["Defence"].MainLeverage.Class, cooldown: 10, "Защита", percentage: 30)),

                new UnitLeveragesSource(allLSources["Purifying ritual"], SkillPriority.SpecialSupportPriority,
                    new LeverageEffectsRemoval(cooldown: 10, LeverageType.NegativeEffectRemoval))
            };
        }

        protected override List<IDefence> CreateUnitDefences()
        {
            var lClasses = DictionaryStorage.GetInstance().AllLeverageClasses;
            DefencesCreated = true;
            return new List<IDefence>()
            {
                new Defence(lClasses["Will"], 50)
            };
        }
    }
}
