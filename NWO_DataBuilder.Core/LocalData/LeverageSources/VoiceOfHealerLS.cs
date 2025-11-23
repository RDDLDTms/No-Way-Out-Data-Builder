using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.LocalData.Leveragesources
{
    public class VoiceOfHealerLS : LeverageSourceBase
    {
        public override string UniversalName => "Voice of healer";
        public override string RussianDisplayName => "Глас лекаря";
        public override string InstrumentalCase => "гласом лекаря";
        public override Description Description => new("Глас лекаря исцеляет цель и добавляет периодическое восстановление", Language.Russian);
        public override Guid Id => new("49686B3C-A9B6-4A4E-8651-2ABAD42D06B64");

        public VoiceOfHealerLS(ILeverage mainLeverage, ILeverage? additionalLeverage = null) : base(mainLeverage, additionalLeverage)
        {
        }
    }
}
