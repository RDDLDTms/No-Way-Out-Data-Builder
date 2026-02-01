using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace DataBuilder.StartData
{
    public class BreakLevCl : LeverageClassBase
    {
        public override string Color => "#232323";

        public override string Genitive => "пролома";

        public override LeverageClassRestrictions Restrictions => LeverageClassRestrictions.NoRestrictions;

        public override string UniversalName => StartEffectsUniversalNames.Break;

        public override string RussianName => StartEffectsRussianNames.Break;

        public override Description Description => new();

        public override Guid StorageId => new("A7386483-8D22-465F-9793-5B0FCE213A78");
    }
}
