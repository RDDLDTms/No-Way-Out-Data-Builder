using NWO_Abstractions;
using NWO_Abstractions.Effects;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Skills
{
    public class SkillEffectRemovingResultPart : ISkillResultPart
    {
        public LeverageType LeverageType { get; }

        public List<IEffect> Effects { get; set; } = new();
    }
}
