using NWO_Abstractions;

namespace DataBuilder.Units
{
    public class SkillResult : ISkillResult
    {
        public SkillResult(ISkillResultPart mainPart, ISkillResultPart additionalPart, SkillPriority leveragesPriority) : this(mainPart, leveragesPriority)
        {
            AdditionalPart = additionalPart;
        }

        public SkillResult(ISkillResultPart mainPart, SkillPriority leveragesPriority) : this(leveragesPriority)
        {
            MainPart = mainPart;
        }

        private SkillResult(SkillPriority leveragesPriority)
        {
            Priority = leveragesPriority;
        }

        public SkillPriority Priority { get; }

        public ISkillResultPart? MainPart { get; }

        public ISkillResultPart? AdditionalPart { get; }
    }
}
