using DataBuilder.BuilderObjects.Primal;
using NWO_Abstractions;

namespace NWO_DataBuilder.Core.Services
{
    public interface ILeverageService
    {
        public ILeverage CreateLeverage(string universalName, string russianDisplayName, ILeverageClass leverageClass, LeverageTargetType leverageTargetType,
            LeverageHitPoint leverageHitPoint, LeverageRangeType leverageRangeType, LeverageTargeting leverageTargeting, List<ILeverageOption> leverageOptions);

        public ILeverageOption CreateLeverageOption(string russianDisplayName, string universalName, string russianDescription);

        public ILeverageClass CreateLeverageClass(string russianDisplayName, string universalName, string color, string genitive, LeverageType type, LeverageClassRestrictions restrictions);
    }
}
