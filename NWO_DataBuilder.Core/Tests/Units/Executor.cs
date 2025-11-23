using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_DataBuilder.Core.Models;
using NWO_DataBuilder.Core.Tests.LeverageSources;

namespace NWO_DataBuilder.Core.Tests.Units
{
    internal sealed class Executor : UnitBase
    {
        public override AccessLevel AccessLevel => AccessLevel.Fifth;
        public override bool IsBase => false;
        public override double MaxHealth => 700;
        public override Faction Faction => Faction.Unruly;
        public override string RussianDisplayName => "Вершитель";
        public override string UniversalName => "Executor";

        public override List<IUnitLeveragesSource> CreateLeveragesSources()
        {
            var allLSources = DictionaryStorage.GetInstance().AllLeveragesSources;
            LeveragesSourcesCreated = true;
            return _leveragesSources = new List<IUnitLeveragesSource>()
            {
                new UnitLeveragesSource(allLSources[nameof(ClaymoreOfLightLS)], SkillPriority.PrimalPriority,
                    new LeverageHit(20, 40, 8, LeverageType.Damage),
                    new LeverageHit(7, 12, 8, LeverageType.Damage)),

                new UnitLeveragesSource(allLSources[nameof(MirrorArmorLS)], SkillPriority.HighPriority,
                    new LeverageHit(minValue: 10, maxValue: 20, cooldown: 7, LeverageType.Damage),
                    new LeverageHit(minValue: 3, maxValue: 6, cooldown: 4, LeverageType.Damage)),

                new UnitLeveragesSource(allLSources[nameof(MirrorShieldLS)], SkillPriority.AdvancedPriority,
                    new LeverageHit(minValue: 7, maxValue: 15, cooldown: 7, LeverageType.Damage),
                    new LeverageHit(minValue: 5, maxValue: 8, cooldown: 6, LeverageType.Damage)),

                new UnitLeveragesSource(allLSources[nameof(ShieldStrikeLS)], SkillPriority.MiddlePriority,
                    new LeverageHit(minValue: 5, maxValue: 8, cooldown: 7, LeverageType.Damage))
            };
        }
    }
}
