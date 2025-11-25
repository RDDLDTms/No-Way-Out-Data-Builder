using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace  NWO_DataBuilder.Core.LocalData.LeverageSources
{
    public class ClaymoreOfLightLS : LeverageSourceBase
    {
        public override string UniversalName => "Claymore of light";
        public override string RussianDisplayName => "Клеймор света";
        public override string InstrumentalCase => "клеймором света";
        public override Description Description => new("Клеймор света рассекает цели энергетическим уроном с уничтожением и световыми ожогами", Language.Russian);
        public override Guid Id => new("49686B3C-A9B6-4A4E-8651-2ABAD42D06B75");

        public ClaymoreOfLightLS(ILeverage mainLeverage, ILeverage? additionalLeverage = null) : base(mainLeverage, additionalLeverage)
        {
        }
    }
}
