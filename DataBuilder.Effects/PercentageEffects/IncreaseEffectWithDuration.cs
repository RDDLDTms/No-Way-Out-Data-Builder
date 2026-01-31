using NWO_Abstractions.Effects;
using NWO_Abstractions.Leverages;
using System.Text;

namespace DataBuilder.Effects.PercentageEffects
{
    public sealed class IncreaseEffectWithDuration : PercentageEffectBaseWithDuration
    {
        public override EffectPercentageType PercentageType => EffectPercentageType.Increase;

        public IncreaseEffectWithDuration(EffectType type, ILeverageClass leverageClass, string universalName) :
            base(type, leverageClass, universalName)
        {

        }

        public IncreaseEffectWithDuration(EffectType type, ILeverageClass leverageClass, string universalName, string russainName) :
            base(type, leverageClass, universalName, russainName)
        {

        }
    }
}
