using NWO_Abstractions;

namespace DataBuilder.Units
{
    public class SkillResultPart : ISkillResultPart
    {

        public SkillResultPart(int? value, LeverageType leverageType)
        {
            Value = value;
            LeverageType = leverageType;
        }

        public SkillResultPart(IEffect? effectForTargets, LeverageType leverageType)
        {
            EffectForTargets = effectForTargets;
            LeverageType = leverageType;
        }

        public SkillResultPart(IEffect? effectForTargets, IEffect? effectForActor, LeverageType leverageType) : this(effectForTargets, leverageType)
        {
            EffectForTargets = effectForTargets;
            EffectForActor = effectForActor;
        }

        public IEffect? EffectForTargets { get; }

        public IEffect? EffectForActor { get; }

        public int? Value { get; set; }

        public LeverageType LeverageType { get; }
    }
}
