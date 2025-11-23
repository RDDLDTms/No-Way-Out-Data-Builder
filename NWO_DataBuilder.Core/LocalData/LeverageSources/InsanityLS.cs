using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace  NWO_DataBuilder.Core.LocalData.LeverageSources
{
    public class InsanityLS: LeverageSourceBase
    {
        public override string UniversalName => "Insanity";
        public override string RussianDisplayName => "Помешательство";
        public override string InstrumentalCase => "помешательством";
        public override Description Description => new("Накладывает негативный эффект дестабилизирующий цель", Language.Russian);
        public override Guid Id => new("49686B3C-A9B6-4A4E-8651-2ABAD42D06B6E");

        public InsanityLS(ILeverage mainLeverage, ILeverage? additionalLeverage = null) : base(mainLeverage, additionalLeverage)
        {
        }
    }
}
