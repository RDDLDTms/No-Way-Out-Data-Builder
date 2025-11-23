using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace  NWO_DataBuilder.Core.LocalData.LeverageSources
{
    public class WordOfPreacherLS : LeverageSourceBase
    {
        public override string UniversalName => "Word of preacher";
        public override string RussianDisplayName => "Слово проповедника";
        public override string InstrumentalCase => "словом проповедника";
        public override Description Description => new("Слово проповедника накладывает негативный эффект безумия", Language.Russian);
        public override Guid Id => new("49686B3C-A9B6-4A4E-8651-2ABAD42D06B6B");

        public WordOfPreacherLS(ILeverage mainLeverage, ILeverage? additionalLeverage = null) : base(mainLeverage, additionalLeverage)
        {
        }
    }
}
