using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageOptions
{
    public class SlashingWeaponLevOpt : LeverageOptionBase
    {
        public override string UniversalName => "Slashing weapon";

        public override string RussianName => "Рубящее оружие";

        public override Description Description => new("Оружие разрубает цель или способно отрезать какие-то части от цели", Language.Russian);
    }
}
