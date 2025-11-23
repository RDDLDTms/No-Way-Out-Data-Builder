using NWO_Abstractions;
using NWO_Abstractions.Services;
using Splat;

namespace DataBuilder.Effects
{
    public class EffectBase : ILeverageEffect
    {
        public event EffectTimeHandler? OnEffectTick;
        public event EffectEndHandler? OnEffectEnd;

        public Guid Id { get; }

        public virtual EffectCarrier Carrier { get; protected set; }

        public virtual LeverageType Type { get; protected set; }

        public ILeverageClass EffectClass { get; }

        public int Duration { get; }

        public string EffectName { get; }

        public string EffectDisplayName { get; protected set; } = string.Empty;

        public double Cooldown { get; }

        public Timer? EffectTimer { get; protected set; }

        public int EffectCounter { get; protected set; }

        public ITarget? TargetForEffect { get; protected set; }

        protected bool TargetIsNull => TargetForEffect is null;

        protected IBattleLogService BattleLogService { get; }

        public EffectBase(int duration, ILeverage leverage, double cooldown)
        {
            Duration = duration;
            EffectClass = leverage.Class;
            Cooldown = cooldown;
            EffectName = leverage.UniversalName;
            if (string.IsNullOrWhiteSpace(EffectDisplayName))
                EffectDisplayName = leverage.RussianDisplayName;
            Id = Guid.NewGuid();
            BattleLogService = Locator.Current.GetService<IBattleLogService>()!;
        }

        public virtual void Start(ITarget target, double battleSpeed, int effectDelay = 0)
        {
            TargetForEffect = target;
            EffectCounter = Duration;
            EffectTimer = new Timer(TimerCallback, null, effectDelay, (int)Math.Round(1000 / battleSpeed));
        }

        protected virtual void TimerCallback(object? state)
        {

        }

        protected void OnTimerTick(string logMessage)
        {
            OnEffectTick?.Invoke(this, EffectCounter, logMessage);
        }

        protected void OnEffectEnds(string logMessage)
        {
            OnEffectEnd?.Invoke(this, logMessage);
            EffectTimer?.Dispose();
        }

        protected bool EffectImmuneFound()
        {
            string logMessage;
            if (TargetForEffect!.Immunes.Any(x => x.ImmuneClass == EffectClass))
            {
                EffectCounter = 0;
                logMessage = BattleLogService.GetEffectImmuneFoundMessage(EffectDisplayName, EffectClass.RussianDisplayName);
                OnTimerTick(logMessage);
                return true;
            }
            return false;
        }

        protected void DecreaseCounterByOne()
        {
            EffectCounter--;
            if (EffectCounter == 0)
            {
                OnEffectEnds(string.Empty);
            }
            if (EffectCounter >= 0)
            { 
                OnTimerTick(string.Empty);
            }
        }
    }
}
