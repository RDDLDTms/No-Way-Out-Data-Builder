using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.Tests.LeverageSources
{
    public class WordOfHealerLS : LeverageSourceBase
    {
        public override string UniversalName => "Word of healer";
        public override string RussianDisplayName => "Слово лекаря";
        public override string InstrumentalCase => "словом лекаря";
        public override Description Description => new("Слово лекаря исцеляет цель", Language.Russian);
        public override Guid Id => new("49686B3C-A9B6-4A4E-8651-2ABAD42D06B60");

        public WordOfHealerLS(ILeverage mainLeverage, ILeverage? additionalLeverage = null) : base(mainLeverage, additionalLeverage)
        {
        }
    }
}
