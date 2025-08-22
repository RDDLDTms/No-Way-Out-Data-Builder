using DataBuilder.Leverages;
using NWO_Abstractions;

namespace NWO_Battles
{
    public class UnitVsImmortalDummyBattle : OneUnitVsOneDummyBattle
    { 
        public UnitVsImmortalDummyBattle(IUnit unit, double battleSpeed, int battleTime, int startHealth, int maxHealth, 
            IPurpose purpose, IPercentageValues dummyValues, IPercentageValues unitValues) : 
            base(unit, battleSpeed, battleTime, true, startHealth, maxHealth, purpose, "Бой с бессмертным манекеном", "Battle with immortal dummy",
                dummyValues, unitValues)
        {

        }
    }
}
