namespace NWO_Abstractions
{
    public interface IDummySettings : IObjectWithHealth, IUniversalObject
    {
        public bool IsImmortal { get; }

        public double StartHealth { get; }

        public IPercentageValues StartPercentage { get; }
    }
}
