using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_Abstractions.Skills;
using NWO_DataBuilder.Core.LocalData.LeverageSources;
using NWO_DataBuilder.Core.Models;
using NWO_DataBuilder.Core.Models.Leverages.LeverageData;
using NWO_DataBuilder.Core.Tests.LeverageClasses;

namespace NWO_DataBuilder.Core.Tests
{
    internal sealed class Monk : UnitBase
    {
        public override AccessLevel AccessLevel => AccessLevel.Second;
        public override bool IsBase => false;
        public override bool IsMech => false;
        public override bool IsOrganic => true;
        public override bool IsAlive => true;
        public override double MaxHealth => 70;
        public override Faction Faction => Faction.Faith;
        public override string RussianDisplayName => "Монах";
        public override string UniversalName => "Monk";

        public override List<IUnitLeveragesSource> CreateLeveragesSources()
        {
            var allLSources = DictionaryStorage.GetInstance().AllLeveragesSources;
            var bless = allLSources[nameof(BlessLS)];
            var defence = allLSources[nameof(DefenceLS)];
            var purifyingRitual = allLSources[nameof(PurifyingRitualLS)];
            var wordOfHealer = allLSources[nameof(WordOfHealerLS)];
            LeveragesSourcesCreated = true;
            return _leveragesSources = new()
            {
                new UnitLeveragesSource(defence, SkillPriority.HighPriority,
                    new PercentageEffectCompleteData(defence.MainLeverage.Effects[0].Id, Id, cooldown: 10000, duration: 7000, percentage: 30)),

                new UnitLeveragesSource(wordOfHealer, SkillPriority.AdvancedPriority,
                    new InstantLeverageData(wordOfHealer.MainLeverage.Id, minValue: 20, maxValue: 27, cooldown: 6000)),

                new UnitLeveragesSource(bless, SkillPriority.MiddlePriority,
                    new PeriodicEffectCompleteData(bless.MainLeverage.Effects[0].Id, Id, cooldown: 8000, duration: 6000, minValue: 4, maxValue: 7, defaultDelay: 1000, startDelay : 0)),

                new UnitLeveragesSource(purifyingRitual, SkillPriority.SpecialSupportPriority,
                    new EffectRemovalData(purifyingRitual.MainLeverage.Id, cooldown: 10000))
            };
        }

        public override List<IDefence> CreateDefences()
        {
            var lClasses = DictionaryStorage.GetInstance().AllLeverageClasses;
            DefencesCreated = true;
            return _defences = new()
            {
                new Defence(lClasses[nameof(WillLevCl)], 50)
            };
        }
    }
}
