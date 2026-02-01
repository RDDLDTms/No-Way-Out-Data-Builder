using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions.Leverages;

namespace  NWO_DataBuilder.Core.LocalData.LeverageSources
{
    public class PurifyingRitualLS : LeverageSourceBase
    {
        public override string UniversalName => "Purifying ritual";
        public override string RussianName => "Ритуал очищения";
        public override Description Description => new("Происходит ритуал очищения для снятия негативных эффектов по площади", Language.Russian);
        public override Guid StorageId => new("49686B3C-A9B6-4A4E-8651-2ABAD42D06B63");

        public PurifyingRitualLS(ILeverage mainLeverage, ILeverage? additionalLeverage = null) : base(mainLeverage, additionalLeverage)
        {
        }
    }
}
