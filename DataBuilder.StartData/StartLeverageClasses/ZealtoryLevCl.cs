using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace DataBuilder.StartData
{
    public class ZealtoryLevCl : LeverageClassBase
    {
        public override string Color => "#434343";

        public override string Genitive => "фанатизма";

        public override LeverageClassRestrictions Restrictions => LeverageClassRestrictions.NoRestrictions;

        public override string UniversalName => StartEffectsUniversalNames.Zealtory;

        public override string RussianDisplayName => StartEffectsRussianNames.Zealtory;

        public override Description Description => new();

        public override Guid Id => new("A7386483-8D22-465F-9793-5B0FCE213A11");
    }
}
