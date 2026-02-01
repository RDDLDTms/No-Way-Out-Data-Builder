using NWO_Abstractions.Leverages;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Reactive;

namespace NWO_DataBuilder.Core.ViewModels
{
    public class LeverageTypesViewModel
    {
        public ObservableCollection<ILeverageClass> LeverageTypes { get; set; }

        public LeverageTypesViewModel(Dictionary<Guid, ILeverageClass> leverageTypes)
        {
            LeverageTypes = new();
            foreach (var leverageType in leverageTypes)
            {
                LeverageTypes.Add(leverageType.Value);
            }

            AddLeverageTypeCommand = ReactiveCommand.CreateFromTask(AddLeverageType, null, RxApp.MainThreadScheduler);
            DeleteLeverageTypeCommand = ReactiveCommand.CreateFromTask(DeleteLeverageType, null, RxApp.MainThreadScheduler);
        }

        public async Task AddLeverageType()
        {
            /*LeverageType newLeverageType = new(LeverageTypeUniversalName, LeverageTypeRussianDescription, LeverageTypeRussianDisplayName, Color, GuidGenerator.GetGuid(LeverageTypes.Select(x => x.Id).ToList()));
            LeverageTypes.Add(newLeverageType);*/
        }

        public async Task DeleteLeverageType()
        {
            LeverageTypes.RemoveAt(SelectedIndex);
        }

        public Dictionary<Guid, ILeverageClass> GetResult()
        {
            Dictionary<Guid, ILeverageClass> result = new();
            foreach (var nextLeverageType in LeverageTypes)
            {
                result.Add(nextLeverageType.StorageId, nextLeverageType);
            }
            return result;
        }

        public string AddLeverageTypeButtonText = "Добавить тип воздействия";
        public string DeleteLeverageTypeButtonText = "Удалить тип воздействия";

        [Reactive] public string LeverageTypeUniversalName { get; set; }

        [Reactive] public string LeverageTypeRussianDisplayName { get; set; }

        [Reactive] public string LeverageTypeRussianDescription { get; set; }

        [Reactive] public string Color { get; set; }

        [Reactive] public int SelectedIndex { get; set; }

        public ReactiveCommand<Unit, Unit> AddLeverageTypeCommand { get; set; }

        public ReactiveCommand<Unit, Unit> DeleteLeverageTypeCommand { get; set; }
    }
}

