using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_Abstractions.Skills;
using NWO_DataBuilder.Core.LocalData.LeverageSources;
using NWO_DataBuilder.Core.Models;
using NWO_DataBuilder.Core.Models.Leverages.LeverageData;

namespace NWO_DataBuilder.Core.Tests.Units
{
    internal sealed class Preacher : UnitBase
    {
        public override AccessLevel AccessLevel => AccessLevel.Third;
        public override bool IsBase => false;
        public override bool IsMech => false;
        public override bool IsOrganic => true;
        public override bool IsAlive => true;
        public override Faction Faction => Faction.Faith;
        public override string RussianDisplayName => "Проповедник";
        public override string UniversalName => "Preacher";
        public override double MaxHealth => 95;

        public override List<IUnitLeveragesSource> CreateLeveragesSources()
        {
            var allLSources = DictionaryStorage.GetInstance().AllLeveragesSources;
            LeveragesSourcesCreated = true;
            var wordOfPrecaher = allLSources[nameof(WordOfPreacherLS)];
            return _leveragesSources = new()
            {
                new UnitLeveragesSource(wordOfPrecaher, SkillPriority.MiddlePriority,
                    new NonPeriodicEffectDataWithDuration(wordOfPrecaher.MainLeverage.Effects[0].Id, cooldown: 3000, duration: 6000))
            };
        }
    }
}
