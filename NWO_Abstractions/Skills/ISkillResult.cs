namespace NWO_Abstractions
{
    public interface ISkillResult
    {
        public ISkillResultPart? MainPart { get; set; }

        public ISkillResultPart[]? AdditionalParts { get; }
    }
}
