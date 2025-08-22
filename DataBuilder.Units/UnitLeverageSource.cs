using NWO_Abstractions;

namespace DataBuilder.Units
{
    public class UnitLeveragesSource : IUnitLeveragesSource
    {
        public ILeveragesSource LeveragesSource { get; private set; }

        public LeveragesPriority LeveragesPriority { get; private set; }

        public ILeverageData MainData { get; } 

        public ILeverageData? AdditionalData { get; }

        public UnitLeveragesSource(ILeveragesSource leveragesSource, LeveragesPriority leveragePriority, ILeverageData mainData, ILeverageData? additionalData) 
        { 
            LeveragesSource = leveragesSource;
            MainData = mainData;
            LeveragesPriority = leveragePriority;
            AdditionalData = additionalData;
        }
    }
}
