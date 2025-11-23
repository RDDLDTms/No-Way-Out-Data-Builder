using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.Tests.LeverageSources
{
    public class FlamingBroadswordLS : LeverageSourceBase
    {
        public override string UniversalName => "Flaming broadsword";
        public override string RussianDisplayName => "Пылающий палаш";
        public override string InstrumentalCase => "пылающим палашом";
        public override Description Description => new("Огромный огненный рассекающий палаш", Language.Russian);
        public override Guid Id => new("49686B3C-A9B6-4A4E-8651-2ABAD42D06B67");

        public FlamingBroadswordLS(ILeverage mainLeverage, ILeverage? additionalLeverage = null) : base(mainLeverage, additionalLeverage)
        {
        }
    }
}
