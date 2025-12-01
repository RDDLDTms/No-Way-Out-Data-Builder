using NWO_Abstractions;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Effects
{
    public class IncreaseEffectBase : EffectBase, IPercentage
    {
        private int duration;
        private ILeverage leverage;
        private double cooldown;

        public int Percentage { get; }

        public IncreaseEffectBase(ILeverage leverage, int duration, double cooldown, int percentage) :
            base(leverage, duration, cooldown)
        {
            Percentage = percentage;
            EffectDisplayName = $"{leverage.RussianDisplayName} +{Percentage}%";
        }

        protected override void TimerCallback(object? state)
        {
            if (TargetForEffect is null)
                return;

            if (EffectImmuneFound())
                return;

            DecreaseCounterByOne();
        }
    }
}
