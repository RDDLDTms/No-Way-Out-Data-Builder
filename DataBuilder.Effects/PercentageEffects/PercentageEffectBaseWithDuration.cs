using NWO_Abstractions.Effects;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Effects.PercentageEffects
{
    public class PercentageEffectBaseWithDuration : PercentageEffectBase, IEffectWithDuration
    {
        public PercentageEffectBaseWithDuration(EffectType type, ILeverageClass leverageClass, string universalName)
            : base(type, leverageClass, universalName) { }

        public PercentageEffectBaseWithDuration(EffectType type, ILeverageClass leverageClass, string universalName, string russianName)
            : base(type, leverageClass, universalName, russianName) { }

        public event EffectFinishedByTimeHandler? OnEffectFinishedByTime;
        public event EffectTickHandler? OnEffectTick;

        public int TimeLeft { get; protected set; }
        public override bool HasLifeTime => true;
        public int Duration { get; protected set; }
        public Timer? EffectTimer { get; protected set; }

        public void Start(double battleSpeed, int duration, int effectDelay = 0)
        {
            Duration = duration;
            TimeLeft = duration;
            EffectTimer = new Timer(TimerCallback, null, effectDelay, (int)Math.Round(1000 / battleSpeed));
        }

        private void TimerCallback(object? state)
        {
            TimeLeft -= 1000;
            if (TimeLeft < 0)
                OnEffectEnds();
            else
                OnEffectTick?.Invoke(this);
        }

        private void OnEffectEnds()
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
