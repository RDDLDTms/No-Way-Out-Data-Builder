using NWO_Abstractions.Effects;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Effects.ControlEffects
{
    public class TargetControlEffect : EffectBase
    {
        public override EffectCarrier Carrier => EffectCarrier.Target;

        public TargetControlEffect(ILeverageClass leverageClass, string effectUniversalName)
            : base(EffectType.Negative, leverageClass, effectUniversalName)
        {
        }

        public TargetControlEffect(ILeverageClass leverageClass, string effectUniversalName, string russianDisplayName)
            : base(EffectType.Negative, leverageClass, effectUniversalName, russianDisplayName)
        {
        }

    }
}
