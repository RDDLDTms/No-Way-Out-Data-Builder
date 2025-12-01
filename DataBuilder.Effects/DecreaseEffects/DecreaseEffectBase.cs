using NWO_Abstractions;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Effects
{
    public class DecreaseEffectBase : EffectBase, IPercentage
    {
        public int Percentage { get; }

        public DecreaseEffectBase(ILeverage leverage, int duration, double cooldown, int percentage) : 
            base(leverage, duration, cooldown)
        {
            Percentage = percentage;
            EffectDisplayName = $"{leverage.RussianDisplayName} -{Percentage}%";
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
