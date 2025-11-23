using NWO_Abstractions;

namespace DataBuilder.Effects
{
    public class DecreaseEffectBase : EffectBase, IPercentage
    {
        public int Percentage { get; }

        public DecreaseEffectBase(int duration, ILeverage leverage, double cooldown, int percentage) : 
            base(duration, leverage, cooldown)
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
