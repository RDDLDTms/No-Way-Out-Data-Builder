using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageOptions
{
    public class LongSpellLevOpt : LeverageOptionBase
    {
        public override string UniversalName => "Long spell";

        public override string RussianDisplayName => "Длинное заклинание";

        public override Description Description => new("Заклинание, произнесение которого требует времени", Language.Russian);
    }
}
