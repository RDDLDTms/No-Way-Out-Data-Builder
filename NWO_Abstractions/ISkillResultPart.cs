namespace NWO_Abstractions
{
    public interface ISkillResultPart
    {
        public IEffect? EffectForTargets { get; }

        public IEffect? EffectForActor { get; }

        public int? Value { get; set; }

        public LeverageType LeverageType { get; }
    }
}
