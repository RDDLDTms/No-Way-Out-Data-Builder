using NWO_Abstractions;
using NWO_Abstractions.Leverages;

namespace NWO_DataBuilder.Core.Models
{
    public class Defence : IDefence
    {
        public ILeverageClass DefenceClass { get; }

        public double DefencePercent { get; }

        public Defence(ILeverageClass defenceClass, double defencePercent)
        {
            DefenceClass = defenceClass;
            DefencePercent = defencePercent;
        }
    }
}
