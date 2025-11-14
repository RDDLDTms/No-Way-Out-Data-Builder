using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages;
using NWO_Abstractions;
using NWO_DataBuilder.Core.Models;

namespace NWO_DataBuilder.Core.Tests
{
    internal class FakeDataLeverageFactory
    {
        internal static Dictionary<string, ILeverage> CreateLeverages()
        {
            var lClasses = DictionaryStorage.GetInstance().AllLeverageClasses;
            var lOptions = DictionaryStorage.GetInstance().AllLeverageOptions;
            Dictionary<string, ILeverage> allLeverages = new()
            {
                //Class = Will
                { "Word of preacher", new Leverage("Word of preacher", "Слово проповедника", lClasses["Will"], LeverageTargetType.Enemies, LeverageHitPoint.Vision,
                    LeverageRangeType.Range, LeverageTargeting.Place, new List<ILeverageOption>(){ lOptions["Choosing area"], lOptions["Word"] })},

                { "Insanity", new Leverage("Insanity", "Помешательство", lClasses["Will"], LeverageTargetType.Enemies, LeverageHitPoint.Vision,
                    LeverageRangeType.Range, LeverageTargeting.Many, new List<ILeverageOption>(){})},

                //Class = Accommodation
                { "Barrier", new Leverage("Barrier", "Барьер", lClasses["Accommodation"],LeverageTargetType.Neutral, LeverageHitPoint.Vision,
                    LeverageRangeType.Range, LeverageTargeting.Place, new List<ILeverageOption>(){ lOptions["Choosing area"] })},

                //Class = Neutralization
                { "Purifying", new Leverage("Purifying", "Очищение", lClasses["Neutralization"], LeverageTargetType.Alias, LeverageHitPoint.Vision,
                    LeverageRangeType.Range, LeverageTargeting.Single, new List<ILeverageOption>(){ lOptions["Spell"] })},

                { "Purifying ritual", new Leverage("Purifying ritual", "Ритуал очищения", lClasses["Neutralization"], LeverageTargetType.Alias, LeverageHitPoint.SpaceAroundTheHit,
                    LeverageRangeType.Range, LeverageTargeting.Place, new List<ILeverageOption>(){ lOptions["Spell"], lOptions["Choosing area"] })},

                //Class = Healing
                { "Word of healer", new Leverage("Word of healer", "Слово лекаря", lClasses["Healing"], LeverageTargetType.Alias, LeverageHitPoint.Vision,
                    LeverageRangeType.Range, LeverageTargeting.Single, new List<ILeverageOption>(){ lOptions["Word"] })},

                { "Appeal of healer", new Leverage("Appeal of healer", "Воззвание лекаря", lClasses["Healing"], LeverageTargetType.Alias, LeverageHitPoint.SpaceAroundUnit,
                     LeverageRangeType.Range, LeverageTargeting.Place, new List<ILeverageOption>(){ lOptions["Word"] })},

                { "Voice of healer", new Leverage("Voice of healer", "Глас лекаря", lClasses["Healing"], LeverageTargetType.Alias, LeverageHitPoint.Vision,
                    LeverageRangeType.Range, LeverageTargeting.Single, new List<ILeverageOption>(){ lOptions["Word"] })},

                { "Touch additional", new Leverage("Touch additional", "Касание дополнительно", lClasses["Healing"], LeverageTargetType.Alias, LeverageHitPoint.Vision,
                    LeverageRangeType.Range, LeverageTargeting.Single, new List<ILeverageOption>())},

                //Class = Bless
                { "Bless", new Leverage("Bless", "Благо", lClasses["Bless"], LeverageTargetType.Alias, LeverageHitPoint.Vision,
                    LeverageRangeType.Range, LeverageTargeting.Single, new List<ILeverageOption>(){ lOptions["Spell"] })},

                 { "Voice of healer additional", new Leverage("Voice of healer additional", "Глас лекаря дополнительно", lClasses["Bless"], LeverageTargetType.Alias, LeverageHitPoint.Vision,
                    LeverageRangeType.Range, LeverageTargeting.Single, new List<ILeverageOption>(){ lOptions["Spell"] })},

                //Class = Defence
                { "Defence", new Leverage("Defence", "Защита", lClasses["Defence"], LeverageTargetType.Alias, LeverageHitPoint.Vision,
                    LeverageRangeType.Range, LeverageTargeting.Single, new List<ILeverageOption>(){ lOptions["Spell"] })},

                { "Viscous sphere", new Leverage("Viscous sphere", "Вязкая сфера", lClasses["Defence"], LeverageTargetType.Alias, LeverageHitPoint.Vision,
                    LeverageRangeType.Range, LeverageTargeting.Single, new List<ILeverageOption>())},

                //Class = Pressure
                { "Mirror armor", new Leverage("Mirror armor", "Зеркальный доспех", lClasses["Pressure"], LeverageTargetType.Enemies, LeverageHitPoint.FrontLine,
                    LeverageRangeType.Melee, LeverageTargeting.Many, new List<ILeverageOption>())},

                { "Armoured body", new Leverage("Armoured body", "Тело в доспехах", lClasses["Pressure"], LeverageTargetType.Enemies, LeverageHitPoint.FrontLine,
                    LeverageRangeType.Melee, LeverageTargeting.Many, new List<ILeverageOption>())},

                //Class = Destruction
                { "Mirror armor additional", new Leverage("Mirror armor additional", "Зеркальный доспех дополнительно", lClasses["Destruction"], LeverageTargetType.Enemies, LeverageHitPoint.FrontLine,
                    LeverageRangeType.Melee, LeverageTargeting.Many, new List<ILeverageOption>())},

                //Class = Physics
                { "Mirror shield", new Leverage("Mirror shield", "Зеркальный щит", lClasses["Physics"], LeverageTargetType.Enemies, LeverageHitPoint.FrontLine,
                    LeverageRangeType.Melee, LeverageTargeting.Many, new List<ILeverageOption>()) },

                { "Shaft hit", new Leverage("Shaft hit", "Удар древком", lClasses["Physics"], LeverageTargetType.Enemies, LeverageHitPoint.Vision,
                    LeverageRangeType.Melee, LeverageTargeting.Single, new List<ILeverageOption>()) },

                { "Flaming axe", new Leverage("Flaming axe", "Пылающий топор", lClasses["Physics"], LeverageTargetType.Enemies, LeverageHitPoint.FrontHemisphere,
                    LeverageRangeType.Melee, LeverageTargeting.Many,  new List<ILeverageOption>(){ lOptions["Slashing weapon"] })},

                { "Flaming broadsword", new Leverage("Flaming broadsword", "Пылающий палаш", lClasses["Physics"], LeverageTargetType.Enemies, LeverageHitPoint.Vision,
                    LeverageRangeType.Melee, LeverageTargeting.Single,  new List<ILeverageOption>(){ lOptions["Slashing weapon"] })},

                { "Hit with fire", new Leverage("Hit with fire", "Удар с поджёгом", lClasses["Physics"], LeverageTargetType.Enemies, LeverageHitPoint.Vision,
                    LeverageRangeType.Melee, LeverageTargeting.Single,  new List<ILeverageOption>())},

                //Class = Fire
                { "Flaming axe additional", new Leverage("Flaming axe additional", "Пылающий топор дополнительно", lClasses["Fire"], LeverageTargetType.Enemies, LeverageHitPoint.FrontHemisphere,
                    LeverageRangeType.Melee, LeverageTargeting.Many,  new List<ILeverageOption>(){ lOptions["Elemental"] })},

                { "Flaming broadsword additional", new Leverage("Flaming broadsword additional", "Пылающий палаш дополнительно", lClasses["Fire"], LeverageTargetType.Enemies, LeverageHitPoint.Vision,
                    LeverageRangeType.Melee, LeverageTargeting.Single,  new List<ILeverageOption>(){ lOptions["Elemental"] })},

                { "Hit with fire additional", new Leverage("Hit with fire additional", "Удар с поджёгом дополнительно", lClasses["Fire"], LeverageTargetType.Enemies, LeverageHitPoint.Vision,
                    LeverageRangeType.Melee, LeverageTargeting.Single,  new List<ILeverageOption>(){ lOptions["Elemental"] })},

                //Class = Explosion
                { "Explosive roar", new Leverage("Explosive roar", "Взрывной рык", lClasses["Explosion"], LeverageTargetType.Enemies, LeverageHitPoint.SpaceAroundUnit,
                    LeverageRangeType.Range, LeverageTargeting.Many, new List<ILeverageOption>(){ lOptions["Word"] })},

                //Class = Energy
                { "Claymore of light", new Leverage("Claymore of light", "Клеймор света", lClasses["Energy"], LeverageTargetType.Enemies, LeverageHitPoint.Vision,
                    LeverageRangeType.Range, LeverageTargeting.Single, new List<ILeverageOption>(){ lOptions["Slashing weapon"] })},

                //Class = Split
                { "Claymore of light additional", new Leverage("Claymore of light additional", "Клеймор света дополнительно", lClasses["Split"], LeverageTargetType.Enemies, LeverageHitPoint.Vision,
                    LeverageRangeType.Range, LeverageTargeting.Single, new List<ILeverageOption>())},

                //Class = DryingOut
                { "Touch", new Leverage("Touch", "Касание", lClasses["DryingOut"], LeverageTargetType.Enemies, LeverageHitPoint.Vision,
                     LeverageRangeType.Melee, LeverageTargeting.Single, new List<ILeverageOption>())},
            };
            return allLeverages;
        }
    }
}
