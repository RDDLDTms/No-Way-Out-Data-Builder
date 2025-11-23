using NWO_Abstractions;
using NWO_DataBuilder.Core.Tests.LeverageClasses;

namespace NWO_DataBuilder.Core.Tests
{
    internal class FakeDataLeverageClassesFactory
    {
        internal static Dictionary<string, ILeverageClass> CreateLeverageClasses()
        {
            return new Dictionary<string, ILeverageClass>
            {
                { nameof(AccommodationLevCl), new AccommodationLevCl() },
                { nameof(BreakLevCl), new BreakLevCl() },
                { nameof(DefenceLevCl), new DefenceLevCl() },
                { nameof(DesctructionLevCl), new DesctructionLevCl() },
                { nameof(DespondencyLevCl), new DespondencyLevCl() },
                { nameof(DryingOutLevCl), new DryingOutLevCl() },
                { nameof(EnergyLevCl), new EnergyLevCl() },
                { nameof(ExplosionLevCl), new ExplosionLevCl() },
                { nameof(FireLevCl), new FireLevCl() },
                { nameof(GainLevCl), new GainLevCl() },
                { nameof(HealingLevCl), new HealingLevCl() },
                { nameof(NeutralizationLevCl), new NeutralizationLevCl() },
                { nameof(PhysicsLevCl), new PhysicsLevCl() },
                { nameof(PressureLevCl), new PressureLevCl() },
                { nameof(ShineLevCl), new ShineLevCl() },
                { nameof(SplittingLevCl), new SplittingLevCl() },
                { nameof(WeaknessLevCl), new WeaknessLevCl() },
                { nameof(WillLevCl), new WillLevCl() },
                { nameof(WoundsLevCl), new WoundsLevCl() },
                { nameof(ZealtoryLevCl), new ZealtoryLevCl() }
            };
        }
    }
}
