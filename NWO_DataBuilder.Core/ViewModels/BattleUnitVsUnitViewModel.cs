using ReactiveUI;

namespace NWO_DataBuilder.Core.ViewModels
{
    public class BattleUnitVsUnitViewModel : ViewModelBase, IActivatableViewModel
    {
        public BattleUnitVsUnitViewModel() 
        { 
        }

        public ViewModelActivator Activator => new();
    }
}
