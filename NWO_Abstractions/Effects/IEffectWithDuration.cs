using DataBuilder.BuilderObjects;

namespace NWO_Abstractions.Effects
{
    public delegate void EffectTickHandler(IEffectWithDuration senderEffect);
    public delegate void EffectFinishedByTimeHandler(IEffectWithDuration senderEffect);

    /// <summary>
    /// Эффект, имеющий время действия
    /// </summary>
    public interface IEffectWithDuration : IEffect, IObjectWithDuration
    {
        public Timer? EffectTimer { get; }
        public event EffectTickHandler? OnEffectTick;
        public event EffectFinishedByTimeHandler? OnEffectFinishedByTime;

        public void Start(double battleSpeed, int duration, int effectDelay = 0);

        public void SetNewDuration(int newDuration);

        public void SetTimerToStart();
    }
}
