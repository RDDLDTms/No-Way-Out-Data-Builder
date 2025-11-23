using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageClasses
{
    public class WoundsLevCl : LeverageClassBase
    {
        public override string Color => "#565656";

        public override string Genitive => "ран";

        public override LeverageClassRestrictions Restrictions => LeverageClassRestrictions.NoRestrictions;

        public override string UniversalName => "Wounds";

        public override string RussianDisplayName => "Раны";

        public override Description Description => new();

        public override Guid Id => new("A7386483-8D22-465F-9793-5B0FCE213A13");
    }
}
