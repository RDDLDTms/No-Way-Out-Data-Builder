using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions.Leverages;

namespace  NWO_DataBuilder.Core.LocalData.LeverageSources
{
    public class ViscousSphereLS : LeverageSourceBase
    {
        public override string UniversalName => "Viscous sphere";
        public override string RussianName => "Вязкая сфера";
        public override Description Description => new("Накладывает на дружескую цель защитную вязкую сферу", Language.Russian);
        public override Guid StorageId => new("49686B3C-A9B6-4A4E-8651-2ABAD42D06B70");

        public ViscousSphereLS(ILeverage mainLeverage, ILeverage? additionalLeverage = null) : base(mainLeverage, additionalLeverage)
        {
        }
    }
}
