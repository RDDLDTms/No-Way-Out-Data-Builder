using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.Tests.LeverageSources
{
    public class StrikeWithFireLS : LeverageSourceBase
    {
        public override string UniversalName => "Strike with fire";
        public override string RussianDisplayName => "Удар с поджёгом";
        public override string InstrumentalCase => "ударом c поджёгом";
        public override Description Description => new("Физический удар c поджёгом цели", Language.Russian);
        public override Guid Id => new("49686B3C-A9B6-4A4E-8651-2ABAD42D06B69");

        public StrikeWithFireLS(ILeverage mainLeverage, ILeverage? additionalLeverage = null) : base(mainLeverage, additionalLeverage)
        {
        }
    }
}
