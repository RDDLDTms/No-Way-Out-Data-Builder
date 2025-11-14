using DataBuilder.Leverages;
using NWO_Abstractions;
using NWO_DataBuilder.Core.Models;

namespace NWO_DataBuilder.Core.Tests
{
    internal class FakeDataLeverageSourcesFactory
    {
        internal static Dictionary<string, ILeveragesSource> CreateLeverageSources()
        {
            var leverages = DictionaryStorage.GetInstance().AllLeverages;
            Dictionary<string, ILeveragesSource> allLeveragesSources = new()
            {
                { "Word of healer", new FakeLeveragesSource(leverages["Word of healer"], null,
                    "Word of healer", "Слово лекаря", "Слово лекаря исцеляет цель", "словом лекаря") },

                { "Bless", new FakeLeveragesSource(leverages["Bless"], null,
                    "Bless", "Благо", "Накладывает эффект периодического исцеления", "периодическим исцелением") },

                { "Defence", new FakeLeveragesSource(leverages["Defence"], null,
                    "Defence", "Защита", "Накладывает эффект защиты", string.Empty) },

                { "Purifying ritual", new FakeLeveragesSource(leverages["Purifying ritual"], null,
                    "Purifying ritual", "Ритуал очищения", "Снимает негативные эффекты с юнитов в области", "ритуалом очищения")},

                { "Voice of healer", new FakeLeveragesSource(leverages["Voice of healer"], leverages["Voice of healer additional"],
                    "Voice of healer", "Глас лекаря", "Глас лекаря исцеляет цель и добавляет периодическое восстановление", "гласом лекаря")},

                { "Explosive roar", new FakeLeveragesSource(leverages["Explosive roar"], null,
                    "Explosive roar", "Взрывной рык", "Ужасающий рык, взрывающий всё вокруг", "взрывным рыком")},

                { "Shaft hit", new FakeLeveragesSource(leverages["Shaft hit"], null,
                    "Shaft hit", "Удар древком", "Удар древком двуручного топора", "ударом древка топора")},

                { "Flaming broadsword", new FakeLeveragesSource(leverages["Flaming broadsword"], leverages["Flaming broadsword additional"],
                    "Flaming broadsword", "Пылающий палаш", "Огромный огненный рассекающий палаш", "пылающим палашом")},

                { "Flaming axe", new FakeLeveragesSource(leverages["Flaming axe"], leverages["Flaming axe additional"],
                    "Flaming axe", "Пылающий двуручный топор", "Убийственный рассекающий огромный огненный топор", "пылающим двуручным топором")},

                { "Hit with fire", new FakeLeveragesSource(leverages["Hit with fire"], leverages["Hit with fire additional"],
                    "Hit with fire", "Удар с поджогом", "Физический удар юнита c поджогом по цели", "ударом c поджогом") },

                { "Armoured body", new FakeLeveragesSource(leverages["Armoured body"], null,
                    "Armoured body", "Тело в доспехах", "Тело в доспехах давит другую цель", "телом в доспехах")},

                { "Word of preacher", new FakeLeveragesSource(leverages["Word of preacher"], null,
                    "Word of preacher", "Слово проповедника", "Слово проповедника накладывает негативный эффект", "словом проповедника")},

                { "Purifying", new FakeLeveragesSource(leverages["Purifying"], null,
                    "Purifying", "Очищение", "Накладывает позитивный эффект в пределах видимости", "очищением")},

                { "Touch", new FakeLeveragesSource(leverages["Touch"], leverages["Touch additional"],
                    "Touch", "Касание", "Наносит урон в ближнем бою", "касанием")},

                { "Insanity", new FakeLeveragesSource(leverages["Insanity"], null,
                    "Insanity", "Помешательство", "Накладывает негативный эффект", "помешательством")},

                { "Barrier", new FakeLeveragesSource(leverages["Barrier"], null,
                    "Barrier", "Барьер", "Создаёт", "барьером")},

                { "Viscous sphere", new FakeLeveragesSource(leverages["Viscous sphere"], null,
                    "Viscous Sphere", "Вязкая сфера", "Накладывает позитивный эффект", "вязкой сферой")},

                { "Mirror shield", new FakeLeveragesSource(leverages["Mirror shield"], null,
                    "Mirror shield", "Зеркальный щит", "Зеркальный щит наносит физический урон", "зеркальным щитом")},

                { "Mirror armor", new FakeLeveragesSource(leverages["Mirror armor"], leverages["Mirror armor additional"],
                    "Mirror armor", "Зеркальный доспех", "Зеркальный доспех давит другую цель", "зеркальным доспехом")},

                { "Claymore of light", new FakeLeveragesSource(leverages["Claymore of light"], leverages["Claymore of light additional"],
                    "Claymore of light", "Клеймор света", "Клеймор света наносит энергетический урон", "клеймором света")},

                { "Appeal of healer", new FakeLeveragesSource(leverages["Appeal of healer"], null, 
                    "Appeal of healer", "Воззвание лекаря", "Воззвание лекаря исцеляет все цели вокруг", "воззванием лекаря") },
            };
            return allLeveragesSources;
        }
    }
}
