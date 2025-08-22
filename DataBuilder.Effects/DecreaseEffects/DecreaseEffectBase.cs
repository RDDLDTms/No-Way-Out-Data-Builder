using NWO_Abstractions;

namespace DataBuilder.Effects.DecreaseEffects
{
    public class DecreaseEffectBase : EffectBase, IPercentage
    {
        public int Percentage { get; }

        public DecreaseEffectBase(int duration, ILeverageClass effectClass, double cooldown, string effectName, int percentage) : 
            base(duration, effectClass, cooldown, effectName)
        {
            Percentage = percentage;
            EffectDisplayName = $"{effectName} -{Percentage}%";
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
