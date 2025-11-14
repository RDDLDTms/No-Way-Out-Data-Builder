using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Effects.PeriodicEffects.EffectsOnTarget;
using DataBuilder.Leverages;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_DataBuilder.Core.Models;

namespace NWO_DataBuilder.Core.Tests.Units
{
    internal class Rager : UnitBase
    {
        public override AccessLevel AccessLevel => AccessLevel.Fifth;
        public override bool IsBase => false;

        public override int MaxHealth => 666;

        public override byte ImprovmentLevel => 0;

        public override List<Guid> Formula => new();

        public override Faction Faction => Faction.Faith;

        public override string RussianDisplayName => "Яростень";

        public override string UniversalName => "Rager";

        protected override List<IDefence> CreateUnitDefences() => new();

        protected override List<IImmune> CreateUnitImmunes() => new();

        protected override List<IUnitLeveragesSource> CreateUnitLeveragesSources()
        {
            var allLSources = DictionaryStorage.GetInstance().AllLeveragesSources;

            return new List<IUnitLeveragesSource>()
            {
                new UnitLeveragesSource(allLSources["Flaming axe"], SkillPriority.PrimalPriority,
                    new LeverageHit(minValue: 50, maxValue: 55, cooldown: 8, LeverageType.Damage),
                    new TargetPeriodicDamageEffect(duration: 8, allLSources["Flaming axe"].AdditionalLeverage!.Class, cooldown: 14, "Воспламенение", minValue: 10, maxValue: 12)),

                new UnitLeveragesSource(allLSources["Flaming broadsword"], SkillPriority.SecondaryPriority,
                    new LeverageHit(minValue: 35, maxValue: 38, cooldown: 3, LeverageType.Damage),
                    new TargetPeriodicDamageEffect(duration: 3, allLSources["Flaming broadsword"].AdditionalLeverage!.Class, cooldown: 6, "Воспламенение", minValue: 5, maxValue: 8)),

                new UnitLeveragesSource(allLSources["Explosive roar"], SkillPriority.HighPriority,
                    new LeverageHit(minValue: 30, maxValue: 67, cooldown: 10, LeverageType.Damage)),

                new UnitLeveragesSource(allLSources["Shaft hit"], SkillPriority.MiddlePriority,
                    new LeverageHit(minValue: 13, maxValue: 18, cooldown: 4, LeverageType.Damage)),

                new UnitLeveragesSource(allLSources["Armoured body"], SkillPriority.SubsidiaryPriority,
                    new LeverageHit(minValue: 10, maxValue: 20, cooldown: 5, LeverageType.Damage)),

                new UnitLeveragesSource(allLSources["Hit with fire"], SkillPriority.BasePriority,
                    new LeverageHit(minValue: 5, maxValue: 8, cooldown: 3, LeverageType.Damage),
                    new TargetPeriodicDamageEffect(duration: 2, allLSources["Hit with fire"].AdditionalLeverage!.Class, cooldown: 6, "Воспламенение", minValue: 2, maxValue: 5))
            };
        }
    }
}
