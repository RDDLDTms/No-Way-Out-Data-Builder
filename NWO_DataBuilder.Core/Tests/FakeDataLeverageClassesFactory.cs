using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.Tests
{
    internal class FakeDataLeverageClassesFactory
    {
        internal static Dictionary<string, ILeverageClass> CreateLeverageClasses()
        {
            return new Dictionary<string, ILeverageClass>
            {
                { "Pressure", new LeverageClass("Давление", "Pressure", "#999999", "урона давлением", LeverageType.Damage, LeverageClassRestrictions.NoRestrictions) },
                { "Physics", new LeverageClass("Физика", "Physics", "#ca87e3", "физического урона", LeverageType.Damage, LeverageClassRestrictions.NoRestrictions)},
                { "Fire", new LeverageClass("Огонь", "Fire", "#ea9999", "огненного урона", LeverageType.NegativeEffectApplying, LeverageClassRestrictions.NoRestrictions) },
                { "Explosion", new LeverageClass("Взрыв", "Explosion", "#f6b26b", "взрывного урона", LeverageType.Damage, LeverageClassRestrictions.NoRestrictions) },
                { "Healing", new LeverageClass("Лечение", "Healing", "#a4c2f4", "исцеления", LeverageType.Recovery, LeverageClassRestrictions.OrganicAndAlive) },
                { "Neutralization", new LeverageClass("Нейтрализация", "Neutralization", "#efefef", "нейтрализации", LeverageType.NegativeEffectRemoval, LeverageClassRestrictions.NoRestrictions) },
                { "Bless", new LeverageClass("Благо","Bless", "#efefef", "единиц здоровья", LeverageType.PositiveEffectApplying, LeverageClassRestrictions.OrganicAndAlive) },
                { "Defence", new LeverageClass("Защита", "Defence", "565656", "уменьшения урона", LeverageType.PositiveEffectApplying, LeverageClassRestrictions.NoRestrictions) },
                { "Break", new LeverageClass("Пролом", "Break", "232323", "пролома", LeverageType.NegativeEffectApplying, LeverageClassRestrictions.NoRestrictions) },
                { "Gain", new LeverageClass("Усиление", "Gain", "ffddaa", "усиления", LeverageType.PositiveEffectApplying, LeverageClassRestrictions.NoRestrictions) },
                { "Weakness", new LeverageClass("Слабость", "Weakness", "334221", "слабости", LeverageType.NegativeEffectApplying, LeverageClassRestrictions.NoRestrictions) },
                { "Will", new LeverageClass("Воля", "Will", "#ffc0cb", "воли", LeverageType.NegativeEffectApplying, LeverageClassRestrictions.NoRestrictions) },
                { "DryingOut", new LeverageClass("Иссушение", "DryingOut", "#ffdbac", "иссушения", LeverageType.Damage, LeverageClassRestrictions.OrganicAndAlive) },
                { "Accommodation", new LeverageClass("Размещение", "Accommodation", "#800080", "размещения", LeverageType.Creation, LeverageClassRestrictions.NoRestrictions) },
                { "Destruction", new LeverageClass("Разрушение", "Destruction", "#fffdd0", "разрушения", LeverageType.Damage, LeverageClassRestrictions.NoRestrictions) },
                { "Energy", new LeverageClass("Энергия", "Energy", "#0000ff", "энергии", LeverageType.Damage, LeverageClassRestrictions.NoRestrictions) },
                { "Split", new LeverageClass("Расщепление", "Split", "#ff0000", "расщепления", LeverageType.Damage, LeverageClassRestrictions.NoRestrictions) }
            };
        }
    }
}
