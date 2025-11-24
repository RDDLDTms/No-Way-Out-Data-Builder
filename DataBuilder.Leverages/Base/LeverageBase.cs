using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions;

namespace DataBuilder.Leverages.Base
{
    public class LeverageBase : ILeverage
    {
        public List<ILeverageOption> Options { get; } = new();

        public ILeverageClass Class { get; } 

        public virtual LeverageType Type { get; private set; } = LeverageType.None;

        public virtual LeverageTargetType TargetType { get; private set; } = LeverageTargetType.None;

        public virtual LeverageHitPoint HitPoint { get; private set; } = LeverageHitPoint.None;

        public virtual LeverageRangeType RangeType { get; private set; } = LeverageRangeType.None;

        public virtual LeverageTargeting Targeting { get; private set; } = LeverageTargeting.None;

        public virtual string UniversalName { get; private set; } = string.Empty;

        public virtual string RussianDisplayName { get; private set; } = string.Empty;

        public Description Description { get; private set; } = new();

        public Guid Id { get; private set; } = Guid.Empty;

        public LeverageBase(Guid id, Description description, string universalName, string russianDisplayName, ILeverageClass lClass, LeverageTargetType ltargetType, LeverageHitPoint lHitPoint,
            LeverageRangeType rangeType, LeverageTargeting targeting, params ILeverageOption[] options) : this(lClass, options)
        {
            Id = id;
            Description = description;
            UniversalName = universalName;
            RussianDisplayName = russianDisplayName;
            Class = lClass;
            TargetType = ltargetType;
            HitPoint = lHitPoint;
            RangeType = rangeType;
            Targeting = targeting;       
        }

        public LeverageBase(ILeverageClass lClass, params ILeverageOption[] lOptions) : this(lClass)
        {
            Options = [.. lOptions];
        }

        public LeverageBase(ILeverageClass lClass, ILeverageOption lOption) : this(lClass)
        {
            Options = [lOption];
        }

        public LeverageBase(ILeverageClass lClass)
        {
            Class = lClass;
        }
    }
}
