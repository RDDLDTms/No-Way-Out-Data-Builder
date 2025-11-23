using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.Tests.LeverageSources
{
    public class PurifyingLS : LeverageSourceBase
    {
        public override string UniversalName => "Purifying";
        public override string RussianDisplayName => "Очищение";
        public override string InstrumentalCase => "очищением";
        public override Description Description => new("Снимает негативный эффект с цели", Language.Russian);
        public override Guid Id => new("49686B3C-A9B6-4A4E-8651-2ABAD42D06B6C");

        public PurifyingLS(ILeverage mainLeverage, ILeverage? additionalLeverage = null) : base(mainLeverage, additionalLeverage)
        {
        }
    }
}
