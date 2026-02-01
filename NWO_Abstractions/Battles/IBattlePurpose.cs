namespace NWO_Abstractions.Battles
{
    public interface IBattlePurpose
    {
        public string DisplayName { get; }

        public string Description { get; }

        public bool WatchDummy { get; }
    }
}
