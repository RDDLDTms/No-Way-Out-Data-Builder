using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.LocalData.Leveragesources
{
    public class TouchLS : LeverageSourceBase
    {
        public override string UniversalName => "Touch";
        public override string RussianDisplayName => "Касание";
        public override string InstrumentalCase => "касанием";
        public override Description Description => new("Наносит урон в ближнем бою и восстанавливает здоровье дружественной цели", Language.Russian);
        public override Guid Id => new("49686B3C-A9B6-4A4E-8651-2ABAD42D06B6D");

        public TouchLS(ILeverage mainLeverage, ILeverage? additionalLeverage = null) : base(mainLeverage, additionalLeverage)
        {
        }
    }
}
