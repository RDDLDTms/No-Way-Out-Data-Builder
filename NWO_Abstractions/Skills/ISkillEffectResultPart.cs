using NWO_Abstractions.Data.Effects;
using NWO_Abstractions.Effects;

namespace NWO_Abstractions.Skills
{
    public interface ISkillEffectResultPart : ISkillResultPart
    {
        public IEffect Effect { get; }

        public IEffectData EffectData { get; }
    }
}
