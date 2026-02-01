using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageClasses
{
    public class ExplosionLevCl : LeverageClassBase
    {
        public override string Color => "#f6b26b";

        public override string Genitive => "взрыва";

        public override LeverageClassRestrictions Restrictions => LeverageClassRestrictions.NoRestrictions;

        public override string UniversalName => "Explosion";

        public override string RussianName => "Взрыв";

        public override Description Description => new();

        public override Guid StorageId => new("A7386483-8D22-465F-9793-5B0FCE213A73");
    }
}
