using DataBuilder.Effects.PeriodicEffects;
using NWO_Abstractions.Effects;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Effects
{
    public class TargetPeriodicDamageEffect : PeriodicEffectBase
    { 
        public override EffectCarrier Carrier => EffectCarrier.Target;

        public TargetPeriodicDamageEffect(ILeverageClass leverageClass, string effectUniversalName, string russianDisplayName) :
            base(EffectType.Negative, leverageClass, effectUniversalName, russianDisplayName)
        {

        }
    }
}
