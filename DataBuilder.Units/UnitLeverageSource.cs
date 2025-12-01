using NWO_Abstractions;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Units
{
    public class UnitLeveragesSource : IUnitLeveragesSource
    {
        public ILeveragesSource LeveragesSource { get; private set; }

        public SkillPriority LeveragesPriority { get; private set; }

        public ITypefulLeverage MainLeverageData { get; } 

        public ITypefulLeverage[]? AdditionalLeveragesData { get; }

        public UnitLeveragesSource(ILeveragesSource leveragesSource, SkillPriority leveragePriority, ITypefulLeverage mainLeverageData, params ITypefulLeverage[]? additionalLeveragesData) 
        { 
            LeveragesSource = leveragesSource;
            LeveragesPriority = leveragePriority;
            MainLeverageData = mainLeverageData;
            AdditionalLeveragesData = additionalLeveragesData;
        }
    }
}
