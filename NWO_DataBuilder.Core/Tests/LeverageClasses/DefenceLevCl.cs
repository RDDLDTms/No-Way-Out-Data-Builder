using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageClasses
{
    public class DefenceLevCl : LeverageClassBase
    {
        public override string Color => "#565656";

        public override string Genitive => "защиты";

        public override LeverageClassRestrictions Restrictions => LeverageClassRestrictions.NoRestrictions;

        public override string UniversalName => "Defence";

        public override string RussianDisplayName => "Защита";

        public override Description Description => new();

        public override Guid Id => new("A7386483-8D22-465F-9793-5B0FCE213A77");
    }
}
