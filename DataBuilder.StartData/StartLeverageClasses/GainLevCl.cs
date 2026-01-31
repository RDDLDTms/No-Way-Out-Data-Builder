using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace DataBuilder.StartData
{
    public class GainLevCl : LeverageClassBase
    {
        public override string Color => "#ffddaa";

        public override string Genitive => "усиления";

        public override LeverageClassRestrictions Restrictions => LeverageClassRestrictions.NoRestrictions;

        public override string UniversalName => StartEffectsUniversalNames.Gain;

        public override string RussianDisplayName => StartEffectsRussianNames.Gain;

        public override Description Description => new();

        public override Guid Id => new("A7386483-8D22-465F-9793-5B0FCE213A79");
    }
}
