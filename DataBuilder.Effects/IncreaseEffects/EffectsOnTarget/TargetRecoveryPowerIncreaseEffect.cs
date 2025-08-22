using NWO_Abstractions;

namespace DataBuilder.Effects.IncreaseEffects.EffectsOnTarget
{
    public class TargetRecoveryPowerIncreaseEffect : IncreaseEffectBase
    {
        public override LeverageType Type => LeverageType.PositiveEffectApplying;
        public override EffectCarrier Carrier => EffectCarrier.Target;

        public TargetRecoveryPowerIncreaseEffect(int duration, ILeverageClass effectClass, double cooldown, string effectName, int percentage) :
            base(duration, effectClass, cooldown, effectName, percentage)
        {

        }
    }
}
