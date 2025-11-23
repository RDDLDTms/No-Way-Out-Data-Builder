using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageClasses
{
    public class PressureLevCl : LeverageClassBase
    {
        public override string Color => "#999999";

        public override string Genitive => "давления";

        public override LeverageClassRestrictions Restrictions => LeverageClassRestrictions.NoRestrictions;

        public override string UniversalName => "Pressure";

        public override string RussianDisplayName => "Давление";

        public override Description Description => new();

        public override Guid Id => new("A7386483-8D22-465F-9793-5B0FCE213A70");
    }
}
