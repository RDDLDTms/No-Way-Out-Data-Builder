using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;

namespace NWO_DataBuilder.Core.Tests.LeverageOptions
{
    public class WordLevOpt : LeverageOptionBase
    {
        public override string UniversalName => "Word";

        public override string RussianDisplayName => "Слово";

        public override Description Description => new("Произнесённое слово", Language.Russian);
    }
}
