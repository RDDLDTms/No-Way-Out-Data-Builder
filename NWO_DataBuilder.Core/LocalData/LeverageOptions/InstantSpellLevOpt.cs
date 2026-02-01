using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageOptions
{
    public class InstantSpellLevOpt : LeverageOptionBase
    {
        public override string UniversalName => "Instant spell";

        public override string RussianName => "Мгновенное заклинание";

        public override Description Description => new("Заклинание, мгновенно срабатывающее при произнесении", Language.Russian);
    }
}
