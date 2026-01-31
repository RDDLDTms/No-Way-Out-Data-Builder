using DataBuilder.BuilderObjects;
using NWO_Abstractions;
using NWO_Abstractions.Data.Effects;
using NWO_Abstractions.Effects;

namespace DataBuilder.Effects
{
    public class EffectsSetBase : IEffectsSet
    {
        public List<IEffect> PositiveEffects { get; set; } = new();
        public List<IEffect> NegativeEffects { get; set; } = new();
        public List<IEffect> OtherEffects { get; set; } = new();
        public Dictionary<Guid, IEffectData> EffectsData { get; set; } = new();

        public event EffectDelegate? OnPositiveEffectApplied;
        public event EffectDelegate? OnNegativeEffectApplied;
        public event EffectDelegate? OnOtherEffectApplied;
        public event EffectDelegate? OnPositiveEffectRemoved;
        public event EffectDelegate? OnNegativeEffectRemoved;
        public event EffectDelegate? OnOtherEffectRemoved;

        public static EffectsSetBase Default() => new();

        public void AddAndSpreadEffects(params IEffect[] effects)
        {
            foreach (var effect in effects)
            {
                switch(effect.Type)
                {
                    case EffectType.Negative:
                        NegativeEffects.Add(effect);
                        OnNegativeEffectApplied?.Invoke(effect);
                        break;
                    case EffectType.Positive:
                        PositiveEffects.Add(effect);
                        OnPositiveEffectApplied?.Invoke(effect);
                        break;
                    case EffectType.None:
                    default:
                        OtherEffects.Add(effect);
                        OnOtherEffectApplied?.Invoke(effect);
                        break;
                }
            }
        }

        public void AddEffectsData(params IEffectData[] data)
        {
            foreach (var effectData in data)
            {
                EffectsData[effectData.EffectId] = effectData;
            }
        }

        public void RemoveEffects(List<IEffect> effects) => effects.ForEach(RemoveEffect);
        public void RemoveEffects(List<Guid> effectIds) => effectIds.ForEach(RemoveEffect);

        public void RemoveEffect(Guid effectId)
        {
            var pEffect = PositiveEffects.FirstOrDefault(x => x.Id == effectId);
            if (pEffect != null)
            {
                PositiveEffects.Remove(pEffect);
                OnPositiveEffectRemoved?.Invoke(pEffect);
                EffectsData.Remove(effectId);
                return;
            }

            var nEffect = NegativeEffects.FirstOrDefault(x => x.Id == effectId);
            if (nEffect != null)
            {
                NegativeEffects.Remove(nEffect);
                OnNegativeEffectRemoved?.Invoke(nEffect);
                EffectsData.Remove(effectId);
                return;
            }

            var oEffect = OtherEffects.FirstOrDefault(x => x.Id == effectId);
            if (oEffect != null)
            {
                OtherEffects.Remove(oEffect);
                OnOtherEffectRemoved?.Invoke(oEffect);
                EffectsData.Remove(effectId);
                return;
            }
        }

        public void RemoveEffect(IEffect effect)
        {
            switch (effect.Type)
            {
                case EffectType.Positive:
                    PositiveEffects.Remove(effect);
                    EffectsData.Remove(effect.Id);
                    OnPositiveEffectRemoved?.Invoke(effect);
                    break;
                case EffectType.Negative:
                    NegativeEffects.Remove(effect);
                    EffectsData.Remove(effect.Id);
                    OnNegativeEffectRemoved?.Invoke(effect);
                    break;
                case EffectType.None:
                default:
                    OtherEffects.Remove(effect);
                    EffectsData.Remove(effect.Id);
                    OnOtherEffectRemoved?.Invoke(effect);
                    break;
            }
        }

        public void RefreshEffect(IEffect effect, IEffectData data)
        {
            if (effect is IEffectWithDuration effectWithDuration)
            {
                effectWithDuration.SetNewDuration(((IObjectWithDuration)data).Duration);
            }
        }
    }
}
