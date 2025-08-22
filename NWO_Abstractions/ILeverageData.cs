namespace NWO_Abstractions
{
    public interface ILeverageData
    {
        public double Cooldown { get; }

        public LeverageType Type { get; }
    }
}
