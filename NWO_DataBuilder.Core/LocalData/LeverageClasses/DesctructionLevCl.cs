using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageClasses
{
    internal class DesctructionLevCl : LeverageClassBase
    {
        public override string Color => "#fffdd0";

        public override string Genitive => "разрушения";

        public override LeverageClassRestrictions Restrictions => LeverageClassRestrictions.NoRestrictions;

        public override string UniversalName => "Destruction";

        public override string RussianName => "Разрушение";

        public override Description Description => new();

        public override Guid StorageId => new("A7386483-8D22-465F-9793-5B0FCE213A7E");
    }
}
