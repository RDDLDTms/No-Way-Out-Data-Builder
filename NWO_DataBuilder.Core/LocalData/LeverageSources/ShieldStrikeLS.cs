using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions.Leverages;

namespace  NWO_DataBuilder.Core.LocalData.LeverageSources
{
    public class ShieldStrikeLS : LeverageSourceBase
    {
        public override string UniversalName => "Shield strike";
        public override string RussianName => "Удар щитом";
        public override Description Description => new("Наносит сокрушительный удар щитом по цели", Language.Russian);
        public override Guid StorageId => new("49686B3C-A9B6-4A4E-8651-2ABAD42D06B72");

        public ShieldStrikeLS(ILeverage mainLeverage, ILeverage? additionalLeverage = null) : base(mainLeverage, additionalLeverage)
        {
        }
    }
}
