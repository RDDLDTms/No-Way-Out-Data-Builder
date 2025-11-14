using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Effects;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_DataBuilder.Core.Models;

namespace NWO_DataBuilder.Core.Tests.Units
{
    internal class Preacher : UnitBase
    {
        public override AccessLevel AccessLevel => AccessLevel.Third;

        public override bool IsBase => false;

        public override byte ImprovmentLevel => 0;

        public override List<Guid> Formula => new();

        public override Faction Faction => Faction.Faith;

        public override string RussianDisplayName => "Проповедник";

        public override string UniversalName => "Preacher";

        public override int MaxHealth => 95;

        protected override List<IDefence> CreateUnitDefences() => new();

        protected override List<IImmune> CreateUnitImmunes() => new();

        protected override List<IUnitLeveragesSource> CreateUnitLeveragesSources()
        {
            var allLSources = DictionaryStorage.GetInstance().AllLeveragesSources;
            LeveragesSourcesCreated = true;
            return new List<IUnitLeveragesSource>()
            {
                new UnitLeveragesSource(allLSources["Word of preacher"], SkillPriority.MiddlePriority,
                    new TargetControlEffect(3, allLSources["Word of preacher"].MainLeverage.Class, 6, "Переманивание"))
            };
        }
    }
}
