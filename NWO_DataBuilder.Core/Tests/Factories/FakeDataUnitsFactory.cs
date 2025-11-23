using NWO_Abstractions;
using NWO_DataBuilder.Core.Tests.Units;

namespace NWO_DataBuilder.Core.Tests
{
    internal class FakeDataUnitsFactory
    {
        internal static Dictionary<string, IUnitData> CreateUnitsData()
        {
            return new Dictionary<string, IUnitData>()
            {
                { nameof(Caller), new Caller() },
                { nameof(ChaosSower), new ChaosSower() },
                { nameof(Executor), new Executor() },
                { nameof(Monk), new Monk() },
                { nameof(Preacher), new Preacher() },
                { nameof(Rager), new Rager() },
            };
        }
    }
}
