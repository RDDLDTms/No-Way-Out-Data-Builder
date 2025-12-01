using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Effects;
using DataBuilder.Leverages;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_DataBuilder.Core.Models;
using  NWO_DataBuilder.Core.LocalData.LeverageSources;

namespace NWO_DataBuilder.Core.Tests.Units
{
    internal sealed class Caller : UnitBase
    {
        public override AccessLevel AccessLevel => AccessLevel.Fourth;
        public override bool IsBase => false;
        public override bool IsMech => false;
        public override bool IsOrganic => true;
        public override bool IsAlive => true;
        public override double MaxHealth => 250;
        public override Faction Faction => Faction.Faith;
        public override string RussianDisplayName => "Взывающий";
        public override string UniversalName => "Caller";

        public override List<IUnitLeveragesSource> CreateLeveragesSources()
        {
            var allLSources = DictionaryStorage.GetInstance().AllLeveragesSources;
            LeveragesSourcesCreated = true;
            return _leveragesSources = new()
            {
                new UnitLeveragesSource(allLSources[nameof(VoiceOfHealerLS)], SkillPriority.PrimalPriority,
                    new LeverageInstantStrike(minValue: 25, maxValue: 38, cooldown: 3),
                    new TargetPeriodicRecoveryEffect(allLSources[nameof(VoiceOfHealerLS)].AdditionalLeverages![0], duration: 6, cooldown: 12, minValue: 5, maxValue: 9)),

                new UnitLeveragesSource(allLSources[nameof(AppealOfHealerLS)], SkillPriority.MiddlePriority,
                    new LeverageInstantStrike(minValue: 15, maxValue: 20, cooldown: 5)),

                new UnitLeveragesSource(allLSources[nameof(PurifyingRitualLS)], SkillPriority.SpecialSupportPriority,
                    new LeverageNegativeEffectsRemoval(cooldown: 8)),

                new UnitLeveragesSource(allLSources[nameof(ArmouredBodyLS)], SkillPriority.SubsidiaryPriority,
                    new LeverageInstantStrike(minValue: 10, maxValue: 20, cooldown: 7))
            };
        }
    }
}
