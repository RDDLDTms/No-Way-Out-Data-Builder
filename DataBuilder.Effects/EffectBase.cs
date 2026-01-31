using NWO_Abstractions.Effects;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Effects
{
    public class EffectBase : IEffect
    {
        public Guid Id { get; }

        public EffectType Type { get; }

        public ILeverageClass LeverageClass { get; }

        public virtual EffectCarrier Carrier { get; protected set; }

        public string UniversalName { get; } = string.Empty;

        public string RussianName { get; } = string.Empty;

        public string DisplayName { get; set; }

        public virtual bool IsRemovable { get; }

        public virtual bool HasLifeTime { get; }

        public virtual bool HasPoints { get; }

        public virtual bool HasValues { get; }

        public virtual bool HasPercentage { get; }

        public EffectBase(EffectType type, ILeverageClass leverageClass, string universalName, string russianName) 
            : this(type, leverageClass, universalName)
        {
            RussianName = russianName;
            DisplayName = string.IsNullOrWhiteSpace(RussianName) ? UniversalName : RussianName;
        }

        public EffectBase(EffectType type, ILeverageClass leverageClass, string universalName)
        {
            Id = Guid.NewGuid();
            Type = type;
            UniversalName = universalName;
            DisplayName = UniversalName;
            LeverageClass = leverageClass;
        }   
    }
}
