using DataBuilder.BuilderObjects;
using Newtonsoft.Json;
using NWO_Abstractions;
using System.Collections.ObjectModel;

namespace DataBuilder.Data.Loader
{
    public class JSONLoader : IDataLoader
    {
        public async Task<ObservableCollection<ILeverageClass>> LoadLeverageTypesAsync()
        {
            ObservableCollection<ILeverageClass> leverageTypes = new();
            await LoadAsync(nameof(leverageTypes), leverageTypes);
            return leverageTypes;
        }

        private static async Task LoadAsync<T>(string directoryName, ObservableCollection<T> list) where T: IBaseBuilderObject
        {
            if (Directory.Exists(directoryName) is false)
            {
                return;
            }

            var files = Directory.GetFiles(directoryName, "*.json");
            foreach (var nextfile in files)
            {
                var file = await File.ReadAllTextAsync(nextfile);
                if (file is not null)
                {
                    var obj = JsonConvert.DeserializeObject<T>(file);
                    if (obj is not null)
                    {
                        list.Add(obj);
                    }
                }
            }
        }
    }
}