using Avalonia.Controls;
using Avalonia.ReactiveUI;
using NWO_DataBuilder.Core.ViewModels;
using NWO_Support;
using ReactiveUI;
using System;
using System.Reactive.Disposables;

namespace NWO_DataBuilder.DesktopUI.Views
{
    public partial class BattleUnitVsDummyView : ReactiveWindow<BattleUnitVsDummyViewModel>
    {
        public BattleUnitVsDummyView()
        {
            InitializeComponent();

            battleMessages.Items.CollectionChanged += Items_CollectionChanged;
            immortalDummyCheckBox.IsCheckedChanged += ImmortalDummyCheckBox_IsCheckedChanged;

            this.WhenActivated(d =>
            {
                this.OneWayBind(ViewModel, vm => vm.StartStopButtonText, v => v.startStopBattleButton.Content)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.BattleTimeText, v => v.battleTimeLabel.Content)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.BattleSpeedText, v => v.battleSpeedLabel.Content)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.TotalDamageText, v => v.totalDamageLabel.Content)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.TotalRecoverText, v => v.totalRecoverLabel.Content)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.Health, v => v.dummyHealthLabel.Content)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.BattleStarted, v => v.immortalDummyCheckBox.IsEnabled, x => !x)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.MaxHealth, v => v.dummyHealthProgressBar.Maximum)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.AllUnits, v => v.unitComboBox.ItemsSource)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.AllPurposes, v => v.purposeComboBox.ItemsSource)
                    .DisposeWith(d);

                this.BindCommand(ViewModel, vm => vm.StartStopRagerBattleReactiveCommand, v => v.startStopBattleButton)
                    .DisposeWith(d);

                #region Другие привязки

                this.OneWayBind(ViewModel, vm => vm.IsImmortal, v => v.dummyHealthProgressBar.IsVisible, x => !x)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.MessagesList, v => v.battleMessages.ItemsSource)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.DummyNegativeEffects, v => v.dummyNegativeEffects.ItemsSource)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.DummyPositiveEffects, v => v.dummyPositiveEffects.ItemsSource)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.UnitNegativeEffects, v => v.unitNegativeEffects.ItemsSource)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.UnitPositiveEffects, v => v.unitPositiveEffects.ItemsSource)
                    .DisposeWith(d);

                this.Bind(ViewModel, vm => vm.IsImmortal, v => v.immortalDummyCheckBox.IsChecked)
                    .DisposeWith(d);

                this.Bind(ViewModel, vm => vm.SelectedUnit, v => v.unitComboBox.SelectedItem)
                    .DisposeWith(d);

                this.Bind(ViewModel, vm => vm.SelectedPurpose, v => v.purposeComboBox.SelectedItem)
                    .DisposeWith(d);

                this.Bind(ViewModel, vm => vm.MaxHealth, v => v.maxDummyHealthNUD.Value, x => Convert.ToDecimal(x), x => Convert.ToInt32(x))
                    .DisposeWith(d);

                this.Bind(ViewModel, vm => vm.StartHealth, v => v.startDummyHealthNUD.Value, x => Convert.ToDecimal(x), x => Convert.ToInt32(x))
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.Health, v => v.dummyHealthProgressBar.Value)
                    .DisposeWith(d);

                this.Bind(ViewModel, vm => vm.BattleSpeed, v => v.battleSpeedNUD.Value, x => Convert.ToDecimal(x), x => Convert.ToDouble(x))
                    .DisposeWith(d);

                this.Bind(ViewModel, vm => vm.BattleTimeHours, v => v.battleTimeHoursNUD.Value, x => Convert.ToDecimal(x), x => Convert.ToInt32(x))
                    .DisposeWith(d);

                this.Bind(ViewModel, vm => vm.BattleTimeMinutes, v => v.battleTimeMinutesNUD.Value, x => Convert.ToDecimal(x), x => Convert.ToInt32(x))
                    .DisposeWith(d);

                this.Bind(ViewModel, vm => vm.BattleTimeSeconds, v => v.battleTimeSecondsNUD.Value, x => Convert.ToDecimal(x), x => Convert.ToInt32(x))
                    .DisposeWith(d);

                #endregion

                #region Dummy Settings

                this.Bind(ViewModel, vm => vm.DamageForDummyDecrease, v => v.damageForDummyDecreaseOn.Value, x => Convert.ToDecimal(x), x => Convert.ToInt32(x))
                    .DisposeWith(d);

                this.Bind(ViewModel, vm => vm.DamageForDummyIncrease, v => v.damageForDummyIncreaseOn.Value, x => Convert.ToDecimal(x), x => Convert.ToInt32(x))
                    .DisposeWith(d);

                this.Bind(ViewModel, vm => vm.RecoveryForDummyDecrease, v => v.recoverForDummyDecreaseOn.Value, x => Convert.ToDecimal(x), x => Convert.ToInt32(x))
                    .DisposeWith(d);

                this.Bind(ViewModel, vm => vm.RecoveryForDummyIncrease, v => v.recoverForDummyIncreaseOn.Value, x => Convert.ToDecimal(x), x => Convert.ToInt32(x))
                    .DisposeWith(d);

                this.Bind(ViewModel, vm => vm.AllLeveragesForDummyDecrease, v => v.allLeveragesForDummyDecreaseOn.Value, x => Convert.ToDecimal(x), x => Convert.ToInt32(x))
                    .DisposeWith(d);

                this.Bind(ViewModel, vm => vm.AllLeveragesForDummyIncrease, v => v.allLeveragesForDummyIncreaseOn.Value, x => Convert.ToDecimal(x), x => Convert.ToInt32(x))
                    .DisposeWith(d);

                #endregion

                #region UnitSettings

                this.Bind(ViewModel, vm => vm.UnitLeveragesIncreasePercent, v => v.unitLeveragesIncreaseOn.Value, x => Convert.ToDecimal(x), x => Convert.ToInt32(x))
                    .DisposeWith(d);

                this.Bind(ViewModel, vm => vm.UnitLeveragesDecreasePercent, v => v.unitLeveragesDecreaseOn.Value, x => Convert.ToDecimal(x), x => Convert.ToInt32(x))
                    .DisposeWith(d);

                this.Bind(ViewModel, vm => vm.UnitDamageIncreasePercent, v => v.unitDamageIncreaseOn.Value, x => Convert.ToDecimal(x), x => Convert.ToInt32(x))
                    .DisposeWith(d);

                this.Bind(ViewModel, vm => vm.UnitDamageDecreasePercent, v => v.unitDamageDecreaseOn.Value, x => Convert.ToDecimal(x), x => Convert.ToInt32(x))
                    .DisposeWith(d);

                this.Bind(ViewModel, vm => vm.UnitRecoveryIncreasePercent, v => v.unitRecoveryIncreaseOn.Value, x => Convert.ToDecimal(x), x => Convert.ToInt32(x))
                    .DisposeWith(d);

                this.Bind(ViewModel, vm => vm.UnitRecoveryDecreasePercent, v => v.unitRecoveryDecreaseOn.Value, x => Convert.ToDecimal(x), x => Convert.ToInt32(x))
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.SelectedUnit.MaxHealth, v => v.unitMaxHealth.Content)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.SelectedUnit.UniversalName, v => v.unitUniversalName.Content)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.SelectedUnit.Faction, v => v.unitFaction.Content, x => EnumHelper.GetDescription(x))
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.SelectedUnit.AccessLevel, v => v.unitLevel.Content, x => Convert.ToInt32(x))
                    .DisposeWith(d);   
                
                this.OneWayBind(ViewModel, vm => vm.SelectedUnit.IsMech, v => v.unitIsMech.Content, x => x ? "Да" : "Нет")
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.SelectedUnit.IsOrganic, v => v.unitIsOrganic.Content, x => x ? "Да" : "Нет")
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.SelectedUnit.IsAlive, v => v.unitIsAlive.Content, x => x ? "Да" : "Нет")
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.SelectedUnit.IsBase, v => v.unitIsBase.Content, x => x ? "Да" : "Нет")
                    .DisposeWith(d);

                #endregion

            });
        }

        private void ImmortalDummyCheckBox_IsCheckedChanged(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            dummyHealthHeaderLabel.IsVisible = dummyHealthLabel.IsVisible = immortalDummyCheckBox.IsChecked is false;
        }

        private void Items_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (battleMessages.Scroll is ScrollViewer scrollViever)
            {
                scrollViever.ScrollToEnd();
            }
        }
    }
}
