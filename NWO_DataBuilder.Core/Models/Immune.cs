using NWO_Abstractions;
using NWO_Abstractions.Leverages;

namespace NWO_DataBuilder.Core.Models
{
    public class Immune : IImmune
    {   
        public ILeverageClass ImmuneClass { get; }
        public Immune(ILeverageClass leverageClass)
        {
            ImmuneClass = leverageClass;
        }
    }
}
