namespace NWO_Abstractions.Battles
{
    public interface IBattleSettings
    {
        public double BattleSpeed { get; set; }

        public int BattleTime { get; set; }

        IBattlePurpose BattlePurpose { get; set; }
    }
}
