using Avalonia.Controls;
using Avalonia.ReactiveUI;
using NWO_Abstractions;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;

namespace NWO_DataBuilder.DesktopUI.Views
{
    [SingleInstanceView]
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {   
                #region Названия кнопок

                this.OneWayBind(ViewModel, vm => vm.LeverageTypesButtonText, v => v.leverageTypesButton.Content)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.LeveragesButtonText, v => v.leveragesButton.Content)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.UnitsButtonText, v => v.unitsButton.Content)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.BuildingsButtonText, v => v.buildingsButton.Content)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.FactionsButtonText, v => v.factionsButton.Content)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.LevelsButtonText, v => v.levelsButton.Content)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.ResourcesButtonText, v => v.resourcesButton.Content)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.CraftItemsButtonText, v => v.craftItemsButton.Content)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.ShowFakeRager, v => v.fakeRagerButton.Content)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.BattleUnitVsDummy, v => v.battleUnitVsDummy.Content)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.BattleUnitVsUnit, v => v.battleUnitVsUnit.Content)
                    .DisposeWith(d);

                #endregion

                #region Другие привязки

                #endregion

                #region ReactiveCommands

                this.BindCommand(ViewModel, vm => vm.ShowBattleUnitVsDummyReactiveCommand, v => v.battleUnitVsDummy)
                    .DisposeWith(d);

                this.BindCommand(ViewModel, vm => vm.ShowBattleUnitVsUnitReactiveCommand, v => v.battleUnitVsUnit)
                    .DisposeWith(d);

                this.BindCommand(ViewModel, vm => vm.OpenLeverageTypesWindowCommand, v => v.leverageTypesButton)
                    .DisposeWith(d);

                this.BindCommand(ViewModel, vm => vm.ShowFakeRagerReactiveCommand, v => v.fakeRagerButton)
                    .DisposeWith(d);

                #endregion

                #region

                this.BindInteraction(ViewModel, vm => vm.EditLeverageTypesInteraction, context => EditLeverageTypes(context))
                    .DisposeWith(d);

                this.BindInteraction(ViewModel, vm => vm.ShowBattleUnitVsDummyInteraction, context => ShowBattleUnitVsDummy(context))
                    .DisposeWith(d);

                this.BindInteraction(ViewModel, vm => vm.ShowBattleUnitVsUnitInteraction, context => ShowBattleUnitVsUnit(context))
                    .DisposeWith(d);

                #endregion
            });
        }

        public async Task EditLeverageTypes(IInteractionContext<Dictionary<Guid, ILeverageClass>, Dictionary<Guid, ILeverageClass>> context)
        {
            LeverageTypesView leverageTypesView = new()
            {
                ViewModel = new(context.Input)
            };
            leverageTypesView.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            await leverageTypesView.ShowDialog(this);
            context.SetOutput(leverageTypesView.ViewModel.GetResult());
            return;
        }

        public async Task ShowBattleUnitVsDummy(IInteractionContext<Unit, Unit> context)
        {
            BattleUnitVsDummyView view = new()
            {
                ViewModel = new BattleUnitVsDummyViewModel(),
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            await view.ShowDialog(this);
            context.SetOutput(Unit.Default);
            return;
        }

        public async Task ShowBattleUnitVsUnit(IInteractionContext<Unit, Unit> context)
        {
            BattleUnitVsUnitView view = new()
            {
                ViewModel = new BattleUnitVsUnitViewModel(),
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            await view.ShowDialog(this);
            context.SetOutput(Unit.Default);
            return;
        }
    }
}
