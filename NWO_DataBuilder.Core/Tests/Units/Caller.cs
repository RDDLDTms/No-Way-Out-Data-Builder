using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Effects.PeriodicEffects.EffectsOnTarget;
using DataBuilder.Leverages;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_DataBuilder.Core.Models;

namespace NWO_DataBuilder.Core.Tests.Units
{
    internal class Caller : UnitBase
    {
        public override AccessLevel AccessLevel => AccessLevel.Fourth;
        public override bool IsBase => false;

        public override int MaxHealth => 250;

        public override byte ImprovmentLevel => 0;

        public override List<Guid> Formula => new();

        public override Faction Faction => Faction.Faith;

        public override string RussianDisplayName => "Взывающий";

        public override string UniversalName => "Caller";

        protected override List<IUnitLeveragesSource> CreateUnitLeveragesSources()
        {
            var allLSources = DictionaryStorage.GetInstance().AllLeveragesSources;
            LeveragesSourcesCreated = true;
            return new List<IUnitLeveragesSource>
            {
                new UnitLeveragesSource(allLSources["Voice of healer"], SkillPriority.PrimalPriority,
                    new LeverageHit(minValue: 25, maxValue: 38, cooldown: 3, LeverageType.Recovery),
                    new TargetPeriodicRecoveryEffect(duration: 6, allLSources["Voice of healer"].AdditionalLeverage!.Class, cooldown: 12, "Благо", minValue: 5, maxValue: 9)),

                new UnitLeveragesSource(allLSources["Appeal of healer"], SkillPriority.MiddlePriority,
                    new LeverageHit(minValue: 15, maxValue: 20, cooldown: 5, LeverageType.Recovery)),

                new UnitLeveragesSource(allLSources["Purifying ritual"], SkillPriority.SpecialSupportPriority,
                    new LeverageEffectsRemoval(cooldown: 8, LeverageType.NegativeEffectRemoval)),

                new UnitLeveragesSource(allLSources["Armoured body"], SkillPriority.SubsidiaryPriority,
                    new LeverageHit(minValue: 10, maxValue: 20, cooldown: 7, LeverageType.Damage))
            };
        }
    }
}
