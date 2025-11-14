using DataBuilder.BuilderObjects;
using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions;

namespace DataBuilder.Leverages
{
    public class Leverage : ILeverage
    {
        public List<ILeverageOption> Options { get; private set; }
        public ILeverageClass Class { get; private set; }
        public LeverageTargetType TargetType { get; private set; }
        public LeverageHitPoint HitPoint { get; private set; }

        public string UniversalName { get; private set; }

        public string RussianDisplayName { get; private set; }

        public Guid Id { get; private set; }

        public LeverageRangeType RangeType { get; private set; }

        public IDescription Description => throw new NotImplementedException();

        public LeverageTargeting Targeting { get; }

        public Leverage(string universalName, string russianDisplayName, ILeverageClass leverageClass, LeverageTargetType leverageTargetType, LeverageHitPoint leverageHitPoint, LeverageRangeType rangeType, LeverageTargeting targeting, List<ILeverageOption> leverageOptions)
        {
            RussianDisplayName = russianDisplayName;
            UniversalName = universalName;
            Class = leverageClass;
            TargetType = leverageTargetType;
            HitPoint = leverageHitPoint;
            Options = leverageOptions;
            RangeType = rangeType;
            Id = Guid.NewGuid();
            Targeting = targeting;
        }
    }
}
