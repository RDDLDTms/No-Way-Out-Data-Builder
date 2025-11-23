using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageClasses
{
    public class AccommodationLevCl : LeverageClassBase
    {
        public override string Color => "#800080";

        public override string Genitive => "размещения";

        public override LeverageClassRestrictions Restrictions => LeverageClassRestrictions.NoRestrictions;

        public override string UniversalName => "Accommodation";

        public override string RussianDisplayName => "Размещение";

        public override Description Description => new();

        public override Guid Id => new("A7386483-8D22-465F-9793-5B0FCE213A7D");
    }
}
