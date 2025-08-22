using Avalonia.ReactiveUI;
using NWO_DataBuilder.Core.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace NWO_DataBuilder.DesktopUI.Views
{
    public partial class LeverageTypesView : ReactiveWindow<LeverageTypesViewModel>
    {
        public LeverageTypesView()
        {
            InitializeComponent();
            this.WhenActivated(d =>
            {
                this.OneWayBind(ViewModel, vm => vm.LeverageTypes, v => v.leverageTypesListBox.ItemsSource)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.AddLeverageTypeButtonText, v => v.addLeverageTypeButton.Content)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.DeleteLeverageTypeButtonText, v => v.deleteLeverageTypeButton.Content)
                    .DisposeWith(d);

               /* this.Bind(ViewModel, vm => vm.LeverageTypeName, v => v.leverageNameTextBox.Text)
                    .DisposeWith(d);

                this.Bind(ViewModel, vm => vm.LeverageTypeDescription, v => v.leverageDescriptionTextBox.Text)
                    .DisposeWith(d);*/

                this.BindCommand(ViewModel, vm => vm.AddLeverageTypeCommand, v => v.addLeverageTypeButton)
                    .DisposeWith(d);

                this.BindCommand(ViewModel, vm => vm.DeleteLeverageTypeCommand, v => v.deleteLeverageTypeButton)
                    .DisposeWith(d);
            });
        }
    }
}
