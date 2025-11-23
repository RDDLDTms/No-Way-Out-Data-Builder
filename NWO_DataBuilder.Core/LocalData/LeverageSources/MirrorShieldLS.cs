using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace  NWO_DataBuilder.Core.LocalData.LeverageSources
{
    public class MirrorShieldLS : LeverageSourceBase
    {
        public override string UniversalName => "Mirror shield";
        public override string RussianDisplayName => "Зеркальный щит";
        public override string InstrumentalCase => "зеркальным щитом";
        public override Description Description => new("Зеркальный щит наносит урон противникам перед собой", Language.Russian);
        public override Guid Id => new("49686B3C-A9B6-4A4E-8651-2ABAD42D06B73");

        public MirrorShieldLS(ILeverage mainLeverage, ILeverage? additionalLeverage = null) : base(mainLeverage, additionalLeverage)
        {
        }
    }
}
