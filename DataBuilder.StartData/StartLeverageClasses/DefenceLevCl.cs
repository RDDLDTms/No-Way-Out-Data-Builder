using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace DataBuilder.StartData
{
    public class DefenceLevCl : LeverageClassBase
    {
        public override string Color => "#565656";

        public override string Genitive => "защиты";

        public override LeverageClassRestrictions Restrictions => LeverageClassRestrictions.NoRestrictions;

        public override string UniversalName => StartEffectsUniversalNames.Defence;

        public override string RussianName => StartEffectsRussianNames.Defence;

        public override Description Description => new();

        public override Guid StorageId => new("A7386483-8D22-465F-9793-5B0FCE213A77");
    }
}
