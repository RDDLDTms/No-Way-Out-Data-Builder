using NWO_Abstractions;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Skills
{
    public class SkillValuesResultPart : ISkillResultPart
    {
        public double Value { get; private set; }

        public LeverageType LeverageType { get; }

        public SkillValuesResultPart(LeverageType leverageType, double value)
        {
            Value = value;
            LeverageType = leverageType;
        }

        public void UpdateValue(double newValue) 
        {
            Value = newValue; 
        }
    }
}
