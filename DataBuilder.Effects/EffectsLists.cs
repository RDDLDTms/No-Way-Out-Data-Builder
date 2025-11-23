using NWO_Abstractions;

namespace DataBuilder.Effects
{
    public class EffectsLists : IEffectsLists
    {
        public List<IEffect> PositiveEffects { get; set; } = new();
        public List<IEffect> NegativeEffects { get; set; } = new();

        public static EffectsLists Default() => new();

        public void AddAndSpreadEffects(params IEffect[] effects)
        {
            PositiveEffects.AddRange(effects.Where(x => (x as IncreaseEffectBase) is not null));
            NegativeEffects.AddRange(effects.Where(x => (x as DecreaseEffectBase) is not null));
        }
    }
}
