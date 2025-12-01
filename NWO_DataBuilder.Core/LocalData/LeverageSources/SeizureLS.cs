using DataBuilder.BuilderObjects.Primal;
using DataBuilder.BuilderObjects;
using DataBuilder.Leverages.Base;
using NWO_Abstractions.Leverages;

namespace  NWO_DataBuilder.Core.LocalData.LeverageSources
{
    public class SeizureLS : LeverageSourceBase
    {
        public override string UniversalName => "Seizure";
        public override string RussianDisplayName => "Изъятие";
        public override Description Description => new("Изымает жизнь из цели в ближнем бою", Language.Russian);
        public override Guid Id => new("49686B3C-A9B6-4A4E-8651-2ABAD42D06B78");

        public SeizureLS(ILeverage mainLeverage, ILeverage? additionalLeverage = null) : base(mainLeverage, additionalLeverage)
        {
        }
    }
}
