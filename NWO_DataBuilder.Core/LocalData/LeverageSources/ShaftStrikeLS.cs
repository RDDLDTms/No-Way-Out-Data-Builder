using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions.Leverages;

namespace  NWO_DataBuilder.Core.LocalData.LeverageSources
{
    public class ShaftStrikeLS : LeverageSourceBase
    {
        public override string UniversalName => "Shaft strike";
        public override string RussianName => "Удар древком";
        public override Description Description => new("Удар древком двуручного топора", Language.Russian);
        public override Guid StorageId => new("49686B3C-A9B6-4A4E-8651-2ABAD42D06B66");

        public ShaftStrikeLS(ILeverage mainLeverage, ILeverage? additionalLeverage = null) : base(mainLeverage, additionalLeverage)
        {
        }
    }
}
