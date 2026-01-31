using NWO_Abstractions.Effects;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Effects.ControlEffects
{
    public sealed class TargetControlEffectWithDuration : TargetControlEffect, IEffectWithDuration
    {
        public TargetControlEffectWithDuration(ILeverageClass leverageClass, string universalName) : base(leverageClass, universalName) { }

        public TargetControlEffectWithDuration(ILeverageClass leverageClass, string universalName, string russianName) : base(leverageClass, universalName, russianName) { }
        public event EffectFinishedByTimeHandler? OnEffectFinishedByTime;
        public event EffectTickHandler? OnEffectTick;

        public int TimeLeft { get; private set; }
        public override bool HasLifeTime => true;
        public int Duration { get; private set; }
        public Timer? EffectTimer { get; private set; }

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
