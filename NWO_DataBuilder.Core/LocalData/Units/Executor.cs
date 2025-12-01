using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_DataBuilder.Core.Models;
using  NWO_DataBuilder.Core.LocalData.LeverageSources;

namespace NWO_DataBuilder.Core.Tests.Units
{
    internal sealed class Executor : UnitBase
    {
        public override AccessLevel AccessLevel => AccessLevel.Fifth;
        public override bool IsBase => false;
        public override bool IsMech => false;
        public override bool IsOrganic => true;
        public override bool IsAlive => true;
        public override double MaxHealth => 700;
        public override Faction Faction => Faction.Unruly;
        public override string RussianDisplayName => "Вершитель";
        public override string UniversalName => "Executor";

        public override List<IUnitLeveragesSource> CreateLeveragesSources()
        {
            var allLSources = DictionaryStorage.GetInstance().AllLeveragesSources;
            LeveragesSourcesCreated = true;
            return _leveragesSources = new()
            {
                new UnitLeveragesSource(allLSources[nameof(ClaymoreOfLightLS)], SkillPriority.PrimalPriority,
                    new LeverageInstantStrike(minValue:44, maxValue:66, cooldown:8),
                    new LeverageInstantStrike(minValue:11, maxValue:22, cooldown:8)),

                new UnitLeveragesSource(allLSources[nameof(MirrorArmorLS)], SkillPriority.HighPriority,
                    new LeverageInstantStrike(minValue: 20, maxValue: 30, cooldown: 7),
                    new LeverageInstantStrike(minValue: 22, maxValue: 33, cooldown: 4)),

                new UnitLeveragesSource(allLSources[nameof(MirrorShieldLS)], SkillPriority.AdvancedPriority,
                    new LeverageInstantStrike(minValue: 13, maxValue: 21, cooldown: 7),
                    new LeverageInstantStrike(minValue: 22, maxValue: 33, cooldown: 6)),

                new UnitLeveragesSource(allLSources[nameof(ShieldStrikeLS)], SkillPriority.MiddlePriority,
                    new LeverageInstantStrike(minValue: 13, maxValue: 16, cooldown: 7))
            };
        }
    }
}
