using NWO_Abstractions;

namespace DataBuilder.Effects.IncreaseEffects
{
    public class IncreaseEffectBase : EffectBase, IPercentage
    {
        public int Percentage { get; }

        public IncreaseEffectBase(int duration, ILeverageClass effectClass, double cooldown, string effectName, int percentage) :
            base(duration, effectClass, cooldown, effectName)
        {
            Percentage = percentage;
            EffectDisplayName = $"{effectName} +{Percentage}%";
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
