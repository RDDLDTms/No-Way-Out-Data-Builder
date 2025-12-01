using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions.Leverages;

namespace  NWO_DataBuilder.Core.LocalData.LeverageSources
{
    public class ArmouredBodyLS : LeverageSourceBase
    {
        public override string UniversalName => "Armoured body";
        public override string RussianDisplayName => "Тело в доспехах";
        public override Description Description => new("Тело в доспехах давит другую цель", Language.Russian);
        public override Guid Id => new("49686B3C-A9B6-4A4E-8651-2ABAD42D06B6A");

        public ArmouredBodyLS(ILeverage mainLeverage, ILeverage? additionalLeverage = null) : base(mainLeverage, additionalLeverage)
        {
        }
    }
}
