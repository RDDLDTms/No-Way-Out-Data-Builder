using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageClasses
{
    public class NeutralizationLevCl : LeverageClassBase
    {
        public override string Color => "#efefef";

        public override string Genitive => "нейтрализации";

        public override LeverageClassRestrictions Restrictions => LeverageClassRestrictions.NoRestrictions;

        public override string UniversalName => "Neutralization";

        public override string RussianDisplayName => "Нейтрализация";

        public override Description Description => new();

        public override Guid Id => new("A7386483-8D22-465F-9793-5B0FCE213A75");
    }
}
