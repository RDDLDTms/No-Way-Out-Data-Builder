using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageClasses
{
    public class PhysicsLevCl : LeverageClassBase
    {
        public override string Color => "#ca87e3";

        public override string Genitive => "физики";

        public override LeverageClassRestrictions Restrictions => LeverageClassRestrictions.NoRestrictions;

        public override string UniversalName => "Physics";

        public override string RussianDisplayName => "Физика";

        public override Description Description => new();

        public override Guid Id => new("A7386483-8D22-465F-9793-5B0FCE213A71");
    }
}
