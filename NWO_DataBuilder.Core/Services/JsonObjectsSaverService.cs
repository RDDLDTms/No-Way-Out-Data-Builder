using Newtonsoft.Json;

namespace NWO_Abstractions
{
    public class JsonObjectsSaverService : IObjectsSaverService
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
