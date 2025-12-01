using NWO_Abstractions.Leverages;

namespace NWO_Abstractions
{
    public delegate void EffectTimeHandler(IEffect sender, int newTime, string logMessage);
    public delegate void EffectEndHandler(IEffect sender, string logMessage);

    public interface IEffect
    {
        public event EffectTimeHandler OnEffectTick;
        public event EffectEndHandler OnEffectEnd;

        public ILeverageClass EffectClass { get; }

        public string EffectName { get; }

        public EffectCarrier Carrier { get; }

        public Guid Id { get; }

        public void Start(ITarget target, double battleSpeed, int effectDelay = 0);
    }
}
