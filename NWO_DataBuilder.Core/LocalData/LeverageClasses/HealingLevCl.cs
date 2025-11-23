using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageClasses
{
    public class HealingLevCl : LeverageClassBase
    {
        public override string Color => "#a4c2f4";

        public override string Genitive => "лечения";

        public override LeverageClassRestrictions Restrictions => LeverageClassRestrictions.OrganicAndAlive;

        public override string UniversalName => "Healing";

        public override string RussianDisplayName => "Лечение";

        public override Description Description => new();

        public override Guid Id => new("A7386483-8D22-465F-9793-5B0FCE213A74");
    }
}
