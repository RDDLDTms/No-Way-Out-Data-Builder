using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageClasses
{
    public class DryingOutLevCl : LeverageClassBase
    {
        public override string Color => "#ffdbac";

        public override string Genitive => "иссушения";

        public override LeverageClassRestrictions Restrictions => LeverageClassRestrictions.OrganicAndAlive;

        public override string UniversalName => "Drying out";

        public override string RussianDisplayName => "Иссушение";

        public override Description Description => new();

        public override Guid Id => new("A7386483-8D22-465F-9793-5B0FCE213A7C");
    }
}
