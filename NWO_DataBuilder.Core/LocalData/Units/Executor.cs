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
                    new LeverageHit(44, 66, 8, LeverageType.Damage),
                    new LeverageHit(11, 22, 8, LeverageType.Damage)),

                new UnitLeveragesSource(allLSources[nameof(MirrorArmorLS)], SkillPriority.HighPriority,
                    new LeverageHit(minValue: 20, maxValue: 30, cooldown: 7, LeverageType.Damage),
                    new LeverageHit(minValue: 22, maxValue: 33, cooldown: 4, LeverageType.Damage)),

                new UnitLeveragesSource(allLSources[nameof(MirrorShieldLS)], SkillPriority.AdvancedPriority,
                    new LeverageHit(minValue: 13, maxValue: 21, cooldown: 7, LeverageType.Damage),
                    new LeverageHit(minValue: 22, maxValue: 33, cooldown: 6, LeverageType.Damage)),

                new UnitLeveragesSource(allLSources[nameof(ShieldStrikeLS)], SkillPriority.MiddlePriority,
                    new LeverageHit(minValue: 13, maxValue: 16, cooldown: 7, LeverageType.Damage))
            };
        }
    }
}
