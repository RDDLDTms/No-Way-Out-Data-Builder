using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Models;
using NWO_DataBuilder.Core.Support;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;

namespace NWO_DataBuilder.Core.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IActivatableViewModel
    {          
        public MainWindowViewModel()
        {
            _collections = new();
            DictionaryStorage.GetInstance().LoadDictionaries();
            DictionaryStorage.GetInstance().CreateUnitsFromData();
            OpenLeverageTypesWindowCommand = ReactiveCommand.CreateFromTask(EditLeverageTypes, null, RxApp.MainThreadScheduler);
            ShowBattleUnitVsUnitReactiveCommand = ReactiveCommand.CreateFromTask(ShowBattleUnitVsUnit, null, RxApp.MainThreadScheduler);
            ShowBattleUnitVsDummyReactiveCommand = ReactiveCommand.CreateFromTask(ShowBattleUnitVsDummy, null, RxApp.MainThreadScheduler);
        }

        private async Task ShowBattleUnitVsDummy() => await ShowBattleUnitVsDummyInteraction.Handle(Unit.Default);

        private async Task ShowBattleUnitVsUnit() => await ShowBattleUnitVsUnitInteraction.Handle(Unit.Default);

        public async Task EditLeverageTypes()
        {
            if (_collections is not null && _collections.LeverageTypes is not null)
            {
                _collections.LeverageTypes = await EditLeverageTypesInteraction!.Handle(_collections.LeverageTypes);           
            }
        }

        #region Названия кнопок

        public string BuildingsButtonText => "Здания";
        public string CraftItemsButtonText => "Создаваемые вещи";
        public string FactionsButtonText => "Фракции";
        public string LevelsButtonText => "Уровни";
        public string LeveragesButtonText => "Воздействия";
        public string LeverageTypesButtonText => "Типы воздействий";
        public string ResourcesButtonText => "Добываемые ресурсы";
        public string UnitsButtonText => "Юниты";
        public string ShowFakeRager => "Покажи муляж яростня!";
        public string BattleUnitVsDummy => "Один юнит, один манекен";
        public string BattleUnitVsUnit => "Юнит против юнита";

        #endregion

        public ReactiveCommand<Unit, Unit> ShowBattleUnitVsUnitReactiveCommand { get; set; }

        public ReactiveCommand<Unit, Unit>? ShowBattleUnitVsDummyReactiveCommand { get; set; }

        public ReactiveCommand<Unit, Unit>? OpenLeverageTypesWindowCommand { get; set; }

        public ReactiveCommand<Unit, Unit>? ShowFakeRagerReactiveCommand { get; set; }

        public Interaction<Dictionary<Guid, ILeverageClass>, Dictionary<Guid, ILeverageClass>> EditLeverageTypesInteraction = new();

        public Interaction<Dictionary<Guid, Faction>, Dictionary<Guid, Faction>>? EditFactionsInteraction = new();

        public Interaction<Unit, Unit> ShowBattleUnitVsDummyInteraction = new();

        public Interaction<Unit, Unit> ShowBattleUnitVsUnitInteraction = new();

        public ViewModelActivator Activator { get; } = new();

        private readonly Collections _collections;
    }
}