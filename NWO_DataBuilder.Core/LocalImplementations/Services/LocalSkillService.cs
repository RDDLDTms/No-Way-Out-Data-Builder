using DataBuilder.Skills;
using NWO_Abstractions;
using NWO_Abstractions.Services;
using NWO_Abstractions.Skills;

namespace NWO_DataBuilder.Core.LocalImplementations.Services
{
    public class LocalSkillService : ISkillService
    {
        public ISkill CreateSkill(IUnitLeveragesSource source, SkillPriority skillPriority) => new Skill(source, skillPriority);  
    }
}
