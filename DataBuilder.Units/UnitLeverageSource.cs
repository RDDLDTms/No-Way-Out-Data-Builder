using NWO_Abstractions;
using NWO_Abstractions.Leverages;
using NWO_Abstractions.Leverages.LeverageData;
using NWO_Abstractions.Skills;

namespace DataBuilder.Units
{
    public class UnitLeveragesSource : IUnitLeveragesSource
    {
        public ILeveragesSource LeveragesSource { get; private set; }

        public SkillPriority SkillPriority { get; private set; }

        public ILeverageData MainLeverageData { get; } 

        public ILeverageData[]? AdditionalLeveragesData { get; }

        public UnitLeveragesSource(ILeveragesSource leveragesSource, SkillPriority skillPriority, ILeverageData mainLeverageData, params ILeverageData[]? additionalLeveragesData) 
        { 
            LeveragesSource = leveragesSource;
            SkillPriority = skillPriority;
            MainLeverageData = mainLeverageData;
            if (additionalLeveragesData != null && additionalLeveragesData.Length > 0)
                AdditionalLeveragesData = additionalLeveragesData;
        }
    }
}
