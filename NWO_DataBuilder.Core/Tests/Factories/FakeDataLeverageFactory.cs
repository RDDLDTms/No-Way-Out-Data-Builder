using NWO_Abstractions;
using NWO_DataBuilder.Core.Models;
using NWO_DataBuilder.Core.Tests.LeverageClasses;
using NWO_DataBuilder.Core.Tests.LeverageOptions;
using NWO_DataBuilder.Core.Tests.Leverages;

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
                { nameof(AppealOfHealerLev), new AppealOfHealerLev(lClasses[nameof(HealingLevCl)], lOptions[nameof(WordLevOpt)] )},
                { nameof(ArmouredBodyLev), new ArmouredBodyLev(lClasses[nameof(PressureLevCl)])},
                { nameof(BarrierLev), new BarrierLev(lClasses[nameof(AccommodationLevCl)], lOptions[nameof(ChoosingAreaLevOpt)] )},
                { nameof(BlessLev), new BlessLev(lClasses[nameof(HealingLevCl)], lOptions[nameof(InstantSpellLevOpt)] )},
                { nameof(BreakLev), new BreakLev(lClasses[nameof(BreakLevCl)] )},
                { nameof(ClaymoreOfLightAddLev), new ClaymoreOfLightAddLev(lClasses[nameof(SplittingLevCl)]) },
                { nameof(ClaymoreOfLightLev), new ClaymoreOfLightLev(lClasses[nameof(EnergyLevCl)], lOptions[nameof(SlashingWeaponLevOpt)] )},
                { nameof(DefenceLev), new DefenceLev(lClasses[nameof(DefenceLevCl)], lOptions[nameof(InstantSpellLevOpt)] )},
                { nameof(DespondencyLev), new DespondencyLev(lClasses[nameof(DespondencyLevCl)] )},
                { nameof(ExplosiveRoarLev), new ExplosiveRoarLev(lClasses[nameof(ExplosionLevCl)], lOptions[nameof(WordLevOpt)])},
                { nameof(FlamingAxeAddLev), new FlamingAxeAddLev(lClasses[nameof(FireLevCl)], lOptions[nameof(ElementalLevOpt)] )},
                { nameof(FlamingAxeLev), new FlamingAxeLev(lClasses[nameof(PhysicsLevCl)], lOptions[nameof(SlashingWeaponLevOpt)] )},
                { nameof(FlamingBroadswordAddLev), new FlamingBroadswordAddLev(lClasses[nameof(FireLevCl)], lOptions[nameof(ElementalLevOpt)] )},
                { nameof(FlamingBroadswordLev), new FlamingBroadswordLev(lClasses[nameof(PhysicsLevCl)], lOptions[nameof(SlashingWeaponLevOpt)] )},
                { nameof(GainLev), new GainLev(lClasses[nameof(GainLevCl)]) },
                { nameof(InsanityLev), new InsanityLev(lClasses[nameof(WillLevCl)] )},
                { nameof(MirrorArmorAddLev), new MirrorArmorAddLev(lClasses[nameof(DesctructionLevCl)])},
                { nameof(MirrorArmorLev), new MirrorArmorLev(lClasses[nameof(PressureLevCl)])},
                { nameof(MirrorShieldAddLev), new MirrorShieldAddLev(lClasses[nameof(DesctructionLevCl)])},
                { nameof(MirrorShieldLev), new MirrorShieldLev(lClasses[nameof(PhysicsLevCl)])},
                { nameof(PurifyingLev), new PurifyingLev(lClasses[nameof(NeutralizationLevCl)] )},
                { nameof(PurifyingRitualLev), new PurifyingRitualLev(lClasses[nameof(NeutralizationLevCl)], lOptions[nameof(LongSpellLevOpt)] )},
                { nameof(ShaftStrikeLev), new ShaftStrikeLev(lClasses[nameof(PhysicsLevCl)]) },
                { nameof(ShieldStrikeLev), new ShieldStrikeLev(lClasses[nameof(PhysicsLevCl)]) },
                { nameof(ShineLev), new ShineLev(lClasses[nameof(ShineLevCl)]) },
                { nameof(StrikeWithFireAddLev), new StrikeWithFireAddLev(lClasses[nameof(FireLevCl)], lOptions[nameof(ElementalLevOpt)])},
                { nameof(StrikeWithFireLev), new StrikeWithFireLev(lClasses[nameof(PhysicsLevCl)])},
                { nameof(TouchLev), new TouchLev(lClasses[nameof(DryingOutLevCl)])},
                { nameof(TouchAddLev), new TouchAddLev(lClasses[nameof(HealingLevCl)]) },
                { nameof(ViscousSphereLev), new ViscousSphereLev(lClasses[nameof(DefenceLevCl)])},
                { nameof(VoiceOfHealerAddLev), new VoiceOfHealerAddLev(lClasses[nameof(HealingLevCl)], lOptions[nameof(InstantSpellLevOpt)] )},
                { nameof(VoiceOfHealerLev), new VoiceOfHealerLev(lClasses[nameof(HealingLevCl)], lOptions[nameof(WordLevOpt)] )},
                { nameof(WeaknessLev), new WeaknessLev(lClasses[nameof(WeaknessLevCl)]) },
                { nameof(WordOfHealerLev), new WordOfHealerLev(lClasses[nameof(HealingLevCl)], lOptions[nameof(WordLevOpt)] )},
                { nameof(WordOfPreacherLev), new WordOfPreacherLev(lClasses[nameof(WillLevCl)], lOptions[nameof(ChoosingAreaLevOpt)], lOptions[nameof(WordLevOpt)] )},
                { nameof(WoundsLev), new WoundsLev(lClasses[nameof(WoundsLevCl)])},
                { nameof(ZealtoryLev), new ZealtoryLev(lClasses[nameof(ZealtoryLevCl)]) }
            };
            return allLeverages;
        }
    }
}
