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
                    new LeverageHit(minValue: 25, maxValue: 38, cooldown: 3, LeverageType.Recovery),
                    new TargetPeriodicRecoveryEffect(duration: 6, allLSources[nameof(VoiceOfHealerLS)].AdditionalLeverage!, cooldown: 12, minValue: 5, maxValue: 9)),

                new UnitLeveragesSource(allLSources[nameof(AppealOfHealerLS)], SkillPriority.MiddlePriority,
                    new LeverageHit(minValue: 15, maxValue: 20, cooldown: 5, LeverageType.Recovery)),

                new UnitLeveragesSource(allLSources[nameof(PurifyingRitualLS)], SkillPriority.SpecialSupportPriority,
                    new LeverageEffectsRemoval(cooldown: 8, LeverageType.NegativeEffectRemoval)),

                new UnitLeveragesSource(allLSources[nameof(ArmouredBodyLS)], SkillPriority.SubsidiaryPriority,
                    new LeverageHit(minValue: 10, maxValue: 20, cooldown: 7, LeverageType.Damage))
            };
        }
    }
}
