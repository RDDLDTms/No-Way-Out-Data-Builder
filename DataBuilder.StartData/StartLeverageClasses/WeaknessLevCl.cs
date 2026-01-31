using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace DataBuilder.StartData
{
    public class WeaknessLevCl : LeverageClassBase
    {
        public override string Color => "#334221";

        public override string Genitive => "слабости";

        public override LeverageClassRestrictions Restrictions => LeverageClassRestrictions.NoRestrictions;

        public override string UniversalName => StartEffectsUniversalNames.Weakness;

        public override string RussianDisplayName => StartEffectsUniversalNames.Weakness;

        public override Description Description => new();

        public override Guid Id => new("A7386483-8D22-465F-9793-5B0FCE213A7A");
    }
}
