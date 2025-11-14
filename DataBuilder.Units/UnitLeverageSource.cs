using NWO_Abstractions;

namespace DataBuilder.Units
{
    public class UnitLeveragesSource : IUnitLeveragesSource
    {
        public ILeveragesSource LeveragesSource { get; private set; }

        public SkillPriority LeveragesPriority { get; private set; }

        public ILeverageData MainData { get; } 

        public ILeverageData? AdditionalData { get; }

        public UnitLeveragesSource(ILeveragesSource leveragesSource, SkillPriority leveragePriority, ILeverageData mainData, ILeverageData? additionalData = null) 
        { 
            LeveragesSource = leveragesSource;
            MainData = mainData;
            LeveragesPriority = leveragePriority;
            AdditionalData = additionalData;
        }
    }
}
