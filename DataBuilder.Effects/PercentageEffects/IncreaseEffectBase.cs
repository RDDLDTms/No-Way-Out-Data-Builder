using NWO_Abstractions.Effects;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Effects.PercentageEffects
{
    public class IncreaseEffectBase : PercentageEffectBase
    {
        public override EffectPercentageType PercentageType => EffectPercentageType.Increase;

        public IncreaseEffectBase(EffectType type, ILeverageClass leverageClass, string universalName) :
            base(type, leverageClass, universalName)
        {
        }

        public IncreaseEffectBase(EffectType type, ILeverageClass leverageClass, string universalName, string russainName) :
            base(type, leverageClass, universalName, russainName)
        {
        }
    }
}
