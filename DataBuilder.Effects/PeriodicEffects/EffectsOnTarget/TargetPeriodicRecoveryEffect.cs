using DataBuilder.Effects.PeriodicEffects;
using NWO_Abstractions.Effects;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Effects
{
    public sealed class TargetPeriodicRecoveryEffect : PeriodicEffectBase
    {
        public override EffectCarrier Carrier => EffectCarrier.Target;

        public TargetPeriodicRecoveryEffect(ILeverageClass leverageClass, string effectUniversalName, string russianDisplayName) :
            base(EffectType.Positive, leverageClass, effectUniversalName, russianDisplayName)
        {

        }
    }
}
