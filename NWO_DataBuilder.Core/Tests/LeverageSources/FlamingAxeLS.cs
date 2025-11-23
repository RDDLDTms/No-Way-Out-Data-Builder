using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.Tests.LeverageSources
{
    public class FlamingAxeLS : LeverageSourceBase
    {
        public override string UniversalName => "Flaming axe";
        public override string RussianDisplayName => "Пылающий двуручный топор";
        public override string InstrumentalCase => "пылающим двуручным топором";
        public override Description Description => new("Убийственный рассекающий огромный огненный топор", Language.Russian);
        public override Guid Id => new("49686B3C-A9B6-4A4E-8651-2ABAD42D06B68");

        public FlamingAxeLS(ILeverage mainLeverage, ILeverage? additionalLeverage = null) : base(mainLeverage, additionalLeverage)
        {
        }
    }
}
