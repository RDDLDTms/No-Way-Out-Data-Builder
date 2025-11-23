namespace NWO_Abstractions
{
    public interface ISkillResult
    {
        public ISkillResultPart? MainPart { get; }

        public ISkillResultPart? AdditionalPart { get; }

        public SkillPriority Priority { get; }
    }
}
