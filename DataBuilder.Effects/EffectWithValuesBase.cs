using DataBuilder.Effects.DecreaseEffects;
using DataBuilder.Effects.DecreaseEffects.EffectsOnTarget;
using DataBuilder.Effects.IncreaseEffects;
using DataBuilder.Effects.IncreaseEffects.EffectsOnTarget;
using NWO_Abstractions;

namespace DataBuilder.Effects
{
    public class EffectWithValuesBase : EffectBase, ILeverageValues
    {
        public int MinValue { get; }

        public int MaxValue { get; }

        public int SourcePercentage { get; private set; }

        public EffectWithValuesBase(int duration, ILeverageClass effectClass, double cooldown, string effectName, int minValue, int maxValue) 
            : base(duration, effectClass, cooldown, effectName)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            EffectDisplayName = effectName;
        }

        public void Start(ITarget target, double battleSpeed, int sourcePercentage, int effectDelay)
        {
            SourcePercentage = sourcePercentage;
            Start(target, battleSpeed, effectDelay);
        }

        public int GetValue()
        {
            // получаем случайное значение в границах
            int value = Random.Shared.Next(MinValue, MaxValue + 1);

            // добавляется доп проценты или убираем доп проценты в зависимости от момента создания эффекта
            value += value * SourcePercentage / 100;
            
            // добавляем доп проценты или убираем доп проценты в зависимости от эффектов на цели
            value += value * GetTargetPercentage() / 100;
            return value < 0 ? 0 : value;
        }

        protected int GetTargetPercentage()
        {
            return GetBasicPercentage() + GetClassPercentage();
        }

        private int GetBasicPercentage()
        {
            int damageIncreasePercent = 0;
            foreach (var nextDamageDecreaseEffect in TargetForEffect!.PositiveEffects.Where(x => x is TargetDefenceIncreaseEffect).Cast<TargetDefenceIncreaseEffect>())
            {
                damageIncreasePercent -= nextDamageDecreaseEffect.Percentage;
            }
            foreach (var nextDamageIncreaseEffect in TargetForEffect!.NegativeEffects.Where(x => x is TargetDefenceDecreaseEffect).Cast<TargetDefenceDecreaseEffect>())
            {
                damageIncreasePercent += nextDamageIncreaseEffect.Percentage;
            }
            return damageIncreasePercent;
        }

        private int GetClassPercentage() 
        {
            // TODO
            return 0;
        }
    }
}
