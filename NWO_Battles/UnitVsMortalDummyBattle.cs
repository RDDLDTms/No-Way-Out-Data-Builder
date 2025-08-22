using DataBuilder.Leverages;
using NWO_Abstractions;

namespace NWO_Battles
{
    public class UnitVsMortalDummyBattle : OneUnitVsOneDummyBattle
    {
        public UnitVsMortalDummyBattle(IUnit unit, double battleSpeed, int battleTime, int startHealth, int maxHealth, 
            IPurpose purpose, IPercentageValues dummyValues, IPercentageValues unitValues) : 
            base(unit, battleSpeed, battleTime, false, startHealth, maxHealth, purpose, "Бой со смертным манекеном", "Battle with mortal dummy",
                dummyValues, unitValues) 
        {

        }
    }
}
