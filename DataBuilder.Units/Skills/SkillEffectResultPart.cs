using NWO_Abstractions.Data.Effects;
using NWO_Abstractions.Effects;
using NWO_Abstractions.Leverages;
using NWO_Abstractions.Skills;

namespace DataBuilder.Skills
{
    public class SkillEffectResultPart : ISkillEffectResultPart
    {
        public IEffect Effect { get; }

        public IEffectData EffectData { get; }

        public LeverageType LeverageType { get; }

        public SkillEffectResultPart(IEffect effect, IEffectData effectData, LeverageType leverageType)
        {
            Effect = effect;
            EffectData = effectData;
            LeverageType = leverageType;
        }
    }
}
