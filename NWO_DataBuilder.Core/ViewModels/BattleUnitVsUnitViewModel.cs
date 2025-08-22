using NWO_Abstractions;
using ReactiveUI;

namespace NWO_DataBuilder.Core.ViewModels
{
    public class BattleUnitVsUnitViewModel : ViewModelBase, IActivatableViewModel
    {
        public BattleUnitVsUnitViewModel(List<IUnit> units) 
        { 
        }

        public ViewModelActivator Activator => new();
    }
}
