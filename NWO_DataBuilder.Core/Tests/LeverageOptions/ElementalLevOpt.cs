using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageOptions
{
    public class ElementalLevOpt : LeverageOptionBase
    {
        public override string UniversalName => "Elemental";

        public override string RussianDisplayName => "Стихийное";

        public override Description Description => new("Стихийное воздествие", Language.Russian);
    }
}
