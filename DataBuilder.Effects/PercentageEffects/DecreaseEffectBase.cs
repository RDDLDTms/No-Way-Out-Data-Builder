using NWO_Abstractions.Effects;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Effects.PercentageEffects
{
    public class DecreaseEffectBase : PercentageEffectBase
    {
        public override EffectPercentageType PercentageType => EffectPercentageType.Decrease;

        public DecreaseEffectBase(EffectType type, ILeverageClass leverageClass, string universalName) :
            base(type, leverageClass, universalName)
        {
        }

        public DecreaseEffectBase(EffectType type, ILeverageClass leverageClass, string universalName, string russainName) :
            base(type, leverageClass, universalName, russainName)
        {
        }
    }
}
