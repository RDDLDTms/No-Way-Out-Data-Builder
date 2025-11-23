using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.Tests.LeverageSources
{
    public class ExplosiveRoarLS : LeverageSourceBase
    {
        public override string UniversalName => "Explosive roar";
        public override string RussianDisplayName => "Взрывной рык";
        public override string InstrumentalCase => "взрывным рыком";
        public override Description Description => new("Ужасающий рык, взрывающий всё вокруг", Language.Russian);
        public override Guid Id => new("49686B3C-A9B6-4A4E-8651-2ABAD42D06B65");

        public ExplosiveRoarLS(ILeverage mainLeverage, ILeverage? additionalLeverage = null) : base(mainLeverage, additionalLeverage)
        {
        }
    }
}
