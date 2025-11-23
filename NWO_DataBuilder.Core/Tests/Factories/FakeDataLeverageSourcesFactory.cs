using NWO_Abstractions;
using NWO_DataBuilder.Core.Models;
using NWO_DataBuilder.Core.Tests.Leverages;
using NWO_DataBuilder.Core.Tests.LeverageSources;

namespace NWO_DataBuilder.Core.Tests
{
    internal class FakeDataLeverageSourcesFactory
    {
        internal static Dictionary<string, ILeveragesSource> CreateLeverageSources()
        {
            var leverages = DictionaryStorage.GetInstance().AllLeverages;
            Dictionary<string, ILeveragesSource> allLeveragesSources = new()
            {
                { nameof(AppealOfHealerLS), new AppealOfHealerLS(leverages[nameof(AppealOfHealerLev)]) },
                { nameof(ArmouredBodyLS), new ArmouredBodyLS(leverages[nameof(ArmouredBodyLev)]) },
                { nameof(BarrirerLS), new BarrirerLS(leverages[nameof(BarrierLev)]) },
                { nameof(BlessLS), new BlessLS(leverages[nameof(BlessLev)]) },
                { nameof(ClaymoreOfLightLS), new ClaymoreOfLightLS(leverages[nameof(ClaymoreOfLightLev)], leverages[nameof(ClaymoreOfLightAddLev)]) },
                { nameof(DefenceLS), new DefenceLS(leverages[nameof(DefenceLev)]) },
                { nameof(ExplosiveRoarLS), new ExplosiveRoarLS(leverages[nameof(ExplosiveRoarLev)]) },
                { nameof(FlamingAxeLS), new FlamingAxeLS(leverages[nameof(FlamingAxeLev)], leverages[nameof(FlamingAxeAddLev)]) },
                { nameof(FlamingBroadswordLS), new FlamingBroadswordLS(leverages[nameof(FlamingBroadswordLev)], leverages[nameof(FlamingBroadswordAddLev)]) },
                { nameof(InsanityLS), new InsanityLS(leverages[nameof(InsanityLev)]) },
                { nameof(MirrorArmorLS), new MirrorArmorLS(leverages[nameof(MirrorArmorLev)], leverages[nameof(MirrorArmorAddLev)]) },
                { nameof(MirrorShieldLS), new MirrorShieldLS(leverages[nameof(MirrorShieldLev)], leverages[nameof(MirrorShieldAddLev)]) },
                { nameof(PurifyingLS), new PurifyingLS(leverages[nameof(PurifyingLev)]) },
                { nameof(PurifyingRitualLS), new PurifyingRitualLS(leverages[nameof(PurifyingRitualLev)]) },
                { nameof(ShaftStrikeLS), new ShaftStrikeLS(leverages[nameof(ShaftStrikeLev)]) },
                { nameof(ShieldStrikeLS), new ShieldStrikeLS(leverages[nameof(ShieldStrikeLev)]) },
                { nameof(StrikeWithFireLS), new StrikeWithFireLS(leverages[nameof(StrikeWithFireLev)], leverages[nameof(StrikeWithFireAddLev)]) },
                { nameof(TouchLS), new TouchLS(leverages[nameof(TouchLev)], leverages[nameof(TouchAddLev)]) },
                { nameof(ViscousSphereLS), new ViscousSphereLS(leverages[nameof(ViscousSphereLev)]) },
                { nameof(VoiceOfHealerLS), new VoiceOfHealerLS(leverages[nameof(VoiceOfHealerLev)], leverages[nameof(VoiceOfHealerAddLev)]) },
                { nameof(WordOfHealerLS), new WordOfHealerLS(leverages[nameof(WordOfHealerLev)]) },
                { nameof(WordOfPreacherLS), new WordOfPreacherLS(leverages[nameof(WordOfPreacherLev)]) },
            };
            return allLeveragesSources;
        }
    }
}
