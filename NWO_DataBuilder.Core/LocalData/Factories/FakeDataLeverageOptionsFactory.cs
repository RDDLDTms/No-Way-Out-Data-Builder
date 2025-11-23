using NWO_Abstractions;
using NWO_DataBuilder.Core.Tests.LeverageOptions;

namespace NWO_DataBuilder.Core.Tests
{
    internal class FakeDataLeverageOptionsFactory
    {
        internal static Dictionary<string, ILeverageOption> CreateLeverageOptions()
        {
            var leverageOptions = new Dictionary<string, ILeverageOption>()
            {
                { nameof(ChoosingAreaLevOpt), new ChoosingAreaLevOpt() },
                { nameof(ElementalLevOpt), new ElementalLevOpt() },
                { nameof(InstantSpellLevOpt), new InstantSpellLevOpt() },
                { nameof(LongSpellLevOpt), new LongSpellLevOpt() },
                { nameof(SlashingWeaponLevOpt), new SlashingWeaponLevOpt() },
                { nameof(WordLevOpt), new WordLevOpt() }
            };
            return leverageOptions;
        }
    }
}
