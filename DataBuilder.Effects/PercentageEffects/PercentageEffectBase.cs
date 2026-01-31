using NWO_Abstractions.Effects;
using NWO_Abstractions.Leverages;
using System.Text;

namespace DataBuilder.Effects
{
    public class PercentageEffectBase : EffectBase, IPercentageEffect
    {
        public override bool HasValues => false;

        public override bool HasPercentage => true;

        public virtual EffectPercentageType PercentageType { get; }

        public char SuffixChar => PercentageType is EffectPercentageType.Increase ? '+' : '-';

        public bool SuffixAdded { get; private set; } = false;

        public PercentageEffectBase(EffectType type, ILeverageClass leverageClass, string universalName) 
            : base(type, leverageClass, universalName) {}

        public PercentageEffectBase(EffectType type, ILeverageClass leverageClass, string universalName, string russianName) 
            : base(type, leverageClass, universalName, russianName) { }

        public void SetPercentageSuffix(double percentage)
        {
            if (SuffixAdded)
                RefreshPercentageSuffix(percentage);
            else
                AddPercentageSuffix(percentage);
        }

        private void AddPercentageSuffix(double percentage)
        {
            DisplayName = $"{DisplayName} {SuffixChar}{percentage}%";
            SuffixAdded = true;
        }

        private void RefreshPercentageSuffix(double percentage)
        {
            var dnWords = DisplayName.Split(' ');
            StringBuilder sb = new();
            for (int i = 0; i < dnWords.Length - 1; i++)
                sb.Append($"{dnWords[i]} ");
            DisplayName = $"{sb}{SuffixChar}{percentage}%";
        }
    }
}