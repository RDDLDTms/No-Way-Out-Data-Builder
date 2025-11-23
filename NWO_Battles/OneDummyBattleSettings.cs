using DataBuilder.Units;
using NWO_Abstractions.Battles;

namespace NWO_Battles
{
    public class OneDummyBattleSettings : IBattleSettings
    {
        public double BattleSpeed { get; set; }
        public int BattleTime { get; set; }
        public IBattlePurpose BattlePurpose { get; set; }
        public Dummy Dummy { get; set; }
        public Unit Unit { get; set; }

        public OneDummyBattleSettings()
        {

        }
    }
}
