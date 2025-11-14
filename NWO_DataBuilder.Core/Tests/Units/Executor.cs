using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_DataBuilder.Core.Models;

namespace NWO_DataBuilder.Core.Tests.Units
{
    internal class Executor : UnitBase
    {
        public override AccessLevel AccessLevel => AccessLevel.Fifth;
        public override bool IsBase => false;

        public override int MaxHealth => 700;

        public override byte ImprovmentLevel => 0;

        public override List<Guid> Formula => new();

        public override Faction Faction => Faction.Unruly;

        public override string RussianDisplayName => "Вершитель";

        public override string UniversalName => "Executor";

        protected override List<IDefence> CreateUnitDefences() => new();

        protected override List<IImmune> CreateUnitImmunes() => new();

        protected override List<IUnitLeveragesSource> CreateUnitLeveragesSources()
        {
            var allLSources = DictionaryStorage.GetInstance().AllLeveragesSources;
            LeveragesSourcesCreated = true;
            return new List<IUnitLeveragesSource>()
            {
                new UnitLeveragesSource(allLSources["Claymore of light"], SkillPriority.PrimalPriority,
                    new LeverageHit(20, 40, 8, LeverageType.Damage),
                    new LeverageHit(7, 12, 8, LeverageType.Damage)),

                new UnitLeveragesSource(allLSources["Mirror armor"], SkillPriority.AdvancedPriority,
                    new LeverageHit(minValue: 10, maxValue: 20, cooldown: 7, LeverageType.Damage),
                    new LeverageHit(minValue: 5, maxValue: 10, cooldown: 7, LeverageType.Damage)),

                new UnitLeveragesSource(allLSources["Mirror shield"], SkillPriority.MiddlePriority,
                    new LeverageHit(minValue: 10, maxValue: 20, cooldown: 5, LeverageType.Damage))
            };
        }
    }
}
