using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Effects;
using DataBuilder.Leverages;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_DataBuilder.Core.Models;
using NWO_DataBuilder.Core.Tests.LeverageClasses;
using  NWO_DataBuilder.Core.LocalData.LeverageSources;

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
            LeveragesSourcesCreated = true;
            return _leveragesSources = new()
            {
                new UnitLeveragesSource(defence, SkillPriority.HighPriority,
                    new TargetDefenceIncreaseEffect(duration: 7, defence.MainLeverage, cooldown: 10, percentage: 30)),

                new UnitLeveragesSource(allLSources[nameof(WordOfHealerLS)], SkillPriority.AdvancedPriority, 
                    new LeverageHit(minValue: 20, maxValue: 27, cooldown: 6, LeverageType.Recovery)),

                new UnitLeveragesSource(bless, SkillPriority.MiddlePriority, 
                    new TargetPeriodicRecoveryEffect(duration: 6, bless.MainLeverage, cooldown: 8, minValue: 4, maxValue: 7)),

                new UnitLeveragesSource(allLSources[nameof(PurifyingRitualLS)], SkillPriority.SpecialSupportPriority,
                    new LeverageEffectsRemoval(cooldown: 10, LeverageType.NegativeEffectRemoval))
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
