using NWO_Abstractions;

namespace DataBuilder.Units
{
    public class SkillResult : ISkillResult
    {
        public SkillResult(ISkillResultPart mainPart, ISkillResultPart additionalPart, LeveragesPriority leveragesPriority) : this(mainPart, leveragesPriority)
        {
            AdditionalPart = additionalPart;
        }

        public SkillResult(ISkillResultPart mainPart, LeveragesPriority leveragesPriority) : this(leveragesPriority)
        {
            MainPart = mainPart;
        }

        private SkillResult(LeveragesPriority leveragesPriority)
        {
            Priority = leveragesPriority;
        }

        public LeveragesPriority Priority { get; }

        public ISkillResultPart? MainPart { get; }

        public ISkillResultPart? AdditionalPart { get; }
    }
}
