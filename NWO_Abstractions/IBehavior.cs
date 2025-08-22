namespace NWO_Abstractions
{
    public interface IBehavior
    {
        public Task Enable(double battleSpeed, int globalCooldown);
    }
}
