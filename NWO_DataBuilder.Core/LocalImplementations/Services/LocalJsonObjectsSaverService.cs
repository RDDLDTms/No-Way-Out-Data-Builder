using Newtonsoft.Json;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.LocalImplementations.Services
{
    public class LocalJsonObjectsSaverService : IObjectsSaverService
    {
        SemaphoreSlim semaphoreSlim = new(1, 1);
        public async Task SaveObjects(List<IGeneralObject> objectsToSave, string typeName)
        {
            string json = JsonConvert.SerializeObject(objectsToSave);
            semaphoreSlim.Wait(500);
            await File.WriteAllTextAsync($"{typeName}.json", json);
            semaphoreSlim.Release();
        }
    }
}
