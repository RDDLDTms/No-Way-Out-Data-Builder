using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageClasses
{
    public class EnergyLevCl : LeverageClassBase
    {
        public override string Color => "#0000ff";

        public override string Genitive => "энергии";

        public override LeverageClassRestrictions Restrictions => LeverageClassRestrictions.NoRestrictions;

        public override string UniversalName => "Energy";

        public override string RussianDisplayName => "Энергия";

        public override Description Description => new();

        public override Guid Id => new("A7386483-8D22-465F-9793-5B0FCE213A7F");
    }
}
