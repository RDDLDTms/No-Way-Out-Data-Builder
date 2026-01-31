namespace NWO_Abstractions.Effects
{
    public interface IPercentageEffect
    {
        EffectPercentageType PercentageType { get; }

        char SuffixChar { get; }

        public bool SuffixAdded { get; }

        public void SetPercentageSuffix(double percentage);
    }
}
