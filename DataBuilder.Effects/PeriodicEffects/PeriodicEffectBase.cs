using NWO_Abstractions.Effects;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Effects.PeriodicEffects
{
    public class PeriodicEffectBase : EffectBase, IEffectWithDuration
    {
        public event EffectFinishedByTimeHandler? OnEffectFinishedByTime;
        public event EffectTickHandler? OnEffectTick;

        public int TimeLeft { get; protected set; }

        public override bool HasValues => true;
        public override bool HasLifeTime => true;
        public int Duration { get; protected set; }

        public Timer? EffectTimer { get; protected set; }

        public PeriodicEffectBase(EffectType type, ILeverageClass leverageClass, string effectUniversalName) 
            : base(type, leverageClass, effectUniversalName)
        {

        }

        public PeriodicEffectBase(EffectType type, ILeverageClass leverageClass, string effectUniversalName, string russianDisplayName) 
            : base(type, leverageClass, effectUniversalName, russianDisplayName)
        {

        }

        public void Start(double battleSpeed, int duration, int effectDelay = 0)
        {
            Duration = duration;
            TimeLeft = duration;
            EffectTimer = new Timer(TimerCallback, null, effectDelay, (int)Math.Round(1000 / battleSpeed));
        }

        protected virtual void TimerCallback(object? state)
        {
            TimeLeft-=1000;
            if (TimeLeft < 0)
                OnEffectEnds();
            else
                OnEffectTick?.Invoke(this);
        }

        protected virtual void OnEffectEnds()
        {
            OnEffectFinishedByTime?.Invoke(this);
            EffectTimer?.Dispose();
        }

        public void SetNewDuration(int newDuration)
        {
            Duration = newDuration;
            SetTimerToStart();
        }

        public void SetTimerToStart()
        {
            TimeLeft = Duration;
        }
    }
}
