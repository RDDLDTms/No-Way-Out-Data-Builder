using DataBuilder.Leverages;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.Tests
{
    internal class FakeDataLeverageOptionsFactory
    {
        internal static Dictionary<string, ILeverageOption> CreateLeverageOptions()
        {
            var leverageOptions = new Dictionary<string, ILeverageOption>()
            {
                { "Elemental", new LeverageOption("Стихийное", "Elemental", "Воздействие одной из стихий") },
                { "Slashing weapon", new LeverageOption("Рубящее оружие", "Slashing weapon", "Оружие разрубает цель или способно отрезать какие-то части") },
                { "Word", new LeverageOption("Слово", "Word", "Произнессённое юнитом слово") },
                { "Spell", new LeverageOption("Заклинание", "Spell", "Использованное заклинание") },
                { "Choosing area", new LeverageOption("Выбор зоны применения", "Choosing area", "Требуется выбрать зону применения умения") }
            };
            return leverageOptions;
        }
    }
}
