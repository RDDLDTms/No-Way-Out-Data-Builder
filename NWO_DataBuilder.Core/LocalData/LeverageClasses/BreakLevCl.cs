using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageClasses
{
    public class BreakLevCl : LeverageClassBase
    {
        public override string Color => "#232323";

        public override string Genitive => "пролома";

        public override LeverageClassRestrictions Restrictions => LeverageClassRestrictions.NoRestrictions;

        public override string UniversalName => "Break";

        public override string RussianDisplayName => "Пролом";

        public override Description Description => new();

        public override Guid Id => new("A7386483-8D22-465F-9793-5B0FCE213A78");
    }
}
