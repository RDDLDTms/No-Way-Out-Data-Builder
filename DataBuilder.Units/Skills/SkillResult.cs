using NWO_Abstractions;

namespace DataBuilder.Skills
{
    public class SkillResult : ISkillResult
    {
        public SkillResult(ISkillResultPart mainPart, ISkillResultPart[]? additionalParts) : this(mainPart)
        {
            AdditionalParts = additionalParts;
        }

        public SkillResult(ISkillResultPart mainPart)
        {
            MainPart = mainPart;
        }

        public ISkillResultPart? MainPart { get; set; }

        public ISkillResultPart[]? AdditionalParts { get; }
    }
}
