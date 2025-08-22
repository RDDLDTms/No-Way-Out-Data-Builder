using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions;
using ReactiveUI;

namespace NWO_DataBuilder.Core.ViewModels
{
    public class UnitViewModel : ViewModelBase, IActivatableViewModel
    {
        public UnitViewModel(IUnit unitToShow) 
        { 
        
        }

        string UnitUniversalName { get; }

        string UnitRussanDisplayName { get; }

        string UnitDescription { get; }

        Faction Faction { get; }

        bool IsBase {  get; }

        AccessLevel AccessLevel { get; }

        public ViewModelActivator Activator { get; } = new();
    }
}
