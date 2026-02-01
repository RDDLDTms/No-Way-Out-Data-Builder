using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageClasses
{
    public class SplittingLevCl : LeverageClassBase
    {
        public override string Color => "#ff0000";

        public override string Genitive => "расщепления";

        public override LeverageClassRestrictions Restrictions => LeverageClassRestrictions.NoRestrictions;

        public override string UniversalName => "Splitting";

        public override string RussianName => "Расщепление";

        public override Description Description => new();

        public override Guid StorageId => new("A7386483-8D22-465F-9793-5B0FCE213A780");
    }
}
