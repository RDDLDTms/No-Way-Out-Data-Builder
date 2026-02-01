using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Leverages;
using NWO_Abstractions.Leverages;
using NWO_DataBuilder.Core.Services;

namespace NWO_DataBuilder.Core.LocalImplementations.Services
{
    public class LocalLeverageService : ILeverageService
    {
        public ILeverage CreateLeverage(Guid id, Description description, string universalName, string russianDisplayName, ILeverageClass leverageType, LeverageTargetType leverageTargetType,
            LeverageHitPoint leverageHitPoint, LeverageRangeType leverageRangeType, LeverageTargeting leverageTargeting, params ILeverageOption[] leverageOptions)
        {
            return new Leverage(id, description, universalName, russianDisplayName, leverageType, leverageTargetType, leverageHitPoint, leverageRangeType, leverageTargeting, leverageOptions);
        }

        public ILeverageOption CreateLeverageOption(string russianName, string universalName)
        {
            return new LeverageOption(russianName, universalName);
        }

        public ILeverageClass CreateLeverageClass(string russianDisplayName, string universalName, string color, string genitive, LeverageType type, LeverageClassRestrictions restrictions)
        {
            return new LeverageClass(universalName, russianDisplayName, color, genitive, type, restrictions);
        }
    }
}
