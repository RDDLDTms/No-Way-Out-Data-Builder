using NWO_Abstractions;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Effects
{
    public sealed class TargetControlEffect : EffectBase
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override EffectCarrier Carrier => EffectCarrier.Target;

        public TargetControlEffect(ILeverage leverage, int duration, double cooldown) 
            : base(leverage, duration, cooldown)
        {

        }

        protected override void TimerCallback(object? state)
        {
            if (TargetForEffect is null)
                return;

            string logMessage;
            if (TargetForEffect.Immunes.Any(x => x.ImmuneClass == EffectClass))
            {
                EffectCounter = 0;
                logMessage = $"\"Эффект {EffectName}\" снят иммунитетом к классу {EffectClass.RussianDisplayName}";
                OnTimerTick(logMessage);
                return;
            }

            EffectCounter--;
            if (EffectCounter <= 0)
            {
                OnEffectEnds(string.Empty);
            }
        }
    }
}
