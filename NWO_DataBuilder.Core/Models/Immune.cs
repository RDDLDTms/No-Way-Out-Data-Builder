using NWO_Abstractions;

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
