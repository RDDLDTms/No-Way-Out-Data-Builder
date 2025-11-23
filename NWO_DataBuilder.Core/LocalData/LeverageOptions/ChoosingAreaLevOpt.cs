using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageOptions
{
    public class ChoosingAreaLevOpt : LeverageOptionBase
    {
        public override string UniversalName => "Choosing area";

        public override string RussianDisplayName => "Выбор области";

        public override Description Description => new("нужен выбор области применения воздействия", Language.Russian);
    }
}
