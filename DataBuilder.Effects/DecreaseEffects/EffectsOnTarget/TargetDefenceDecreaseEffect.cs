using NWO_Abstractions;

namespace DataBuilder.Effects.DecreaseEffects.EffectsOnTarget
{
    public sealed class TargetDefenceDecreaseEffect : DecreaseEffectBase
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override EffectCarrier Carrier => EffectCarrier.Target;

        public TargetDefenceDecreaseEffect(int duration, ILeverageClass effectClass, double cooldown, string effectName, int percentage) :
            base(duration, effectClass, cooldown, effectName, percentage)
        {

        }
    }
}
