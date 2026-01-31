using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_Abstractions.Skills;
using NWO_DataBuilder.Core.LocalData.LeverageSources;
using NWO_DataBuilder.Core.Models;
using NWO_DataBuilder.Core.Models.Leverages.LeverageData;

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
            var voiceOfHealer = allLSources[nameof(VoiceOfHealerLS)];
            var appealOfHealer = allLSources[nameof(AppealOfHealerLS)];
            var armouredBody = allLSources[nameof(ArmouredBodyLS)];
            var purifyingRitual = allLSources[nameof(PurifyingRitualLS)];
            return _leveragesSources = new()
            {
                new UnitLeveragesSource(voiceOfHealer, SkillPriority.PrimalPriority,
                    new InstantLeverageData(voiceOfHealer.MainLeverage.Id, minValue: 25, maxValue: 38, cooldown: 3000),
                    new PeriodicEffectCompleteData(voiceOfHealer.AdditionalLeverages![0].Effects[0].Id, Id, cooldown: 12000, duration: 6000, minValue: 5, maxValue: 9, defaultDelay : 1000, startDelay : 1000)),

                new UnitLeveragesSource(appealOfHealer, SkillPriority.MiddlePriority,
                    new InstantLeverageData(appealOfHealer.MainLeverage.Id, minValue: 15, maxValue: 20, cooldown: 5000)),

                new UnitLeveragesSource(allLSources[nameof(PurifyingRitualLS)], SkillPriority.SpecialSupportPriority,
                    new EffectRemovalData(purifyingRitual.MainLeverage.Id, cooldown: 8000)),

                new UnitLeveragesSource(armouredBody, SkillPriority.SubsidiaryPriority,
                    new InstantLeverageData(armouredBody.MainLeverage.Id, minValue: 10, maxValue: 20, cooldown: 7000))
            };
        }
    }
}
