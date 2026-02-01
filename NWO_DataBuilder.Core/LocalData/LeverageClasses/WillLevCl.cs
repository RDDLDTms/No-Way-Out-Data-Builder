using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageClasses
{
    public class WillLevCl : LeverageClassBase
    {
        public override string Color => "#ffc0cb";

        public override string Genitive => "воли";

        public override LeverageClassRestrictions Restrictions => LeverageClassRestrictions.NoRestrictions;

        public override string UniversalName => "Will";

        public override string RussianName => "Воля";

        public override Description Description => new();

        public override Guid StorageId => new("A7386483-8D22-465F-9793-5B0FCE213A7B");
    }
}
