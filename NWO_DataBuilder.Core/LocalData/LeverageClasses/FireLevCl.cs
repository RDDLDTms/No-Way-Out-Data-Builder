using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageClasses
{
    public class FireLevCl : LeverageClassBase
    {
        public override string Color => "#ea9999";

        public override string Genitive => "огня";

        public override LeverageClassRestrictions Restrictions => LeverageClassRestrictions.NoRestrictions;

        public override string UniversalName => "Fire";

        public override string RussianName => "Огонь";

        public override Description Description => new();

        public override Guid StorageId => new("A7386483-8D22-465F-9793-5B0FCE213A72");
    }
}
