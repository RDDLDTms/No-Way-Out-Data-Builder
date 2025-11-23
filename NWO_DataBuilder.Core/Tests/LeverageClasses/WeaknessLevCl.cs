using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageClasses
{
    public class WeaknessLevCl : LeverageClassBase
    {
        public override string Color => "#334221";

        public override string Genitive => "слабости";

        public override LeverageClassRestrictions Restrictions => LeverageClassRestrictions.NoRestrictions;

        public override string UniversalName => "Weakness";

        public override string RussianDisplayName => "Слабость";

        public override Description Description => new();

        public override Guid Id => new("A7386483-8D22-465F-9793-5B0FCE213A7A");
    }
}
