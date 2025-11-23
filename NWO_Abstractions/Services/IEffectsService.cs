namespace NWO_Abstractions.Services
{
    public interface IEffectsService
    {
        public IEffect[] GetEffectsByPercentage(IPercentageValues percentageValues);
    }
}
