using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_Abstractions.Skills;
using NWO_DataBuilder.Core.LocalData.LeverageSources;
using NWO_DataBuilder.Core.Models;
using NWO_DataBuilder.Core.Models.Leverages.LeverageData;

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
        public override string RussianName => "Вершитель";
        public override string UniversalName => "Executor";

        public override List<IUnitLeveragesSource> CreateLeveragesSources()
        {
            var allLSources = DictionaryStorage.GetInstance().AllLeveragesSources;
            LeveragesSourcesCreated = true;
            var claymoreOfLight = allLSources[nameof(ClaymoreOfLightLS)];
            var mirrorArmor = allLSources[nameof(MirrorArmorLS)];
            var mirrorShield = allLSources[nameof(MirrorShieldLS)];
            var shieldStrike = allLSources[nameof(ShieldStrikeLS)];
            return _leveragesSources = new()
            {
                new UnitLeveragesSource(claymoreOfLight, SkillPriority.PrimalPriority,
                    new InstantLeverageData(claymoreOfLight.MainLeverage.StorageId, minValue:44, maxValue:66, cooldown:8000),
                    new InstantLeverageData(claymoreOfLight.AdditionalLeverages![0].StorageId, minValue:11, maxValue:22, cooldown:8000)),

                new UnitLeveragesSource(mirrorArmor, SkillPriority.HighPriority,
                    new InstantLeverageData(mirrorArmor.MainLeverage.StorageId, minValue: 20, maxValue: 30, cooldown: 7000),
                    new InstantLeverageData(mirrorArmor.AdditionalLeverages![0].StorageId, minValue: 22, maxValue: 33, cooldown: 4000)),

                new UnitLeveragesSource(mirrorShield, SkillPriority.AdvancedPriority,
                    new InstantLeverageData(mirrorShield.MainLeverage.StorageId, minValue: 13, maxValue: 21, cooldown: 7000),
                    new InstantLeverageData(mirrorShield.AdditionalLeverages![0].StorageId, minValue: 22, maxValue: 33, cooldown: 6000)),

                new UnitLeveragesSource(shieldStrike, SkillPriority.MiddlePriority,
                    new InstantLeverageData(shieldStrike.MainLeverage.StorageId, minValue: 13, maxValue: 16, cooldown: 7000))
            };
        }
    }
}
