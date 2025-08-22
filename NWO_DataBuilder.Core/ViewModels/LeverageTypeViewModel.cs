using DataBuilder.Leverages;

namespace NWO_DataBuilder.Core.ViewModels
{
    public class LeverageTypeViewModel
    {
        public LeverageTypeViewModel(LeverageClass leverageType)
        {
            Model = leverageType;
        }

        public LeverageClass Model { get; }
    }
}
