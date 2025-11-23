using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages.Base;
using NWO_Abstractions;

namespace DataBuilder.Leverages
{
    public class Leverage : LeverageBase
    {
        public Leverage(Guid id, Description description, string universalName, string russianDisplayName, ILeverageClass lClass, LeverageTargetType lTargetType, LeverageHitPoint lHitPoint, 
            LeverageRangeType rangeType, LeverageTargeting targeting, params ILeverageOption[] options)
            : base (id, description, universalName, russianDisplayName, lClass, lTargetType, lHitPoint, rangeType, targeting, options)
        {

        }
    }
}
