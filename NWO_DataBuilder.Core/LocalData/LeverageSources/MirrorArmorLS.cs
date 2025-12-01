using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions.Leverages;

namespace  NWO_DataBuilder.Core.LocalData.LeverageSources
{
    public class MirrorArmorLS : LeverageSourceBase
    {
        public override string UniversalName => "Mirror armor";
        public override string RussianDisplayName => "Зеркальный доспех";
        public override Description Description => new("Зеркальный доспех сокрушает цели по линии напротив себя", Language.Russian);
        public override Guid Id => new("49686B3C-A9B6-4A4E-8651-2ABAD42D06B74");

        public MirrorArmorLS(ILeverage mainLeverage, ILeverage? additionalLeverage = null) : base(mainLeverage, additionalLeverage)
        {
        }
    }
}
