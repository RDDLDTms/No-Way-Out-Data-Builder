using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace  NWO_DataBuilder.Core.LocalData.LeverageSources
{
    public class AppealOfHealerLS : LeverageSourceBase
    {
        public override string UniversalName => "Appeal of healer";
        public override string RussianDisplayName => "Воззвание лекаря";
        public override string InstrumentalCase => "воззванием лекаря";
        public override Description Description => new("Воззвание лекаря исцеляет все цели вокруг", Language.Russian);
        public override Guid Id => new("49686B3C-A9B6-4A4E-8651-2ABAD42D06B71");

        public AppealOfHealerLS(ILeverage mainLeverage, ILeverage? additionalLeverage = null) : base(mainLeverage, additionalLeverage)
        {
        }
    }
}
