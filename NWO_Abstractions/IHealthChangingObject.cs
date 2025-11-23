namespace NWO_Abstractions
{
    public interface IHealthChangingObject : IObjectWithHealth
    {
        public double Health { get; set; }

        public double HealthPercent => Math.Round(Health / MaxHealth, 2);

        public bool CanIncreaseHealth => Health < MaxHealth && Health > 0;

        public bool CanDecreaseHealth => Health <= MaxHealth && Health > 0;

        public void IncreaseHealth(double value)
        {
            Health = Health + value > MaxHealth ? MaxHealth : Health + value;
        }

        public void DecreaseHealth(double value)
        {
            Health = Health - value < 0 ? 0 : Health - value;
        }
    }
}
