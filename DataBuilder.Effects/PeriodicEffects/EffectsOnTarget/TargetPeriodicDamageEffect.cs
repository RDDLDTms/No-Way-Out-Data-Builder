using NWO_Abstractions;

namespace DataBuilder.Effects
{
    public sealed class TargetPeriodicDamageEffect : EffectWithValuesBase
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override EffectCarrier Carrier => EffectCarrier.Target;

        public TargetPeriodicDamageEffect(int duration, ILeverage leverage, double cooldown, int minValue, int maxValue) :
            base(duration, leverage, cooldown, minValue, maxValue)
        {

        }

        public override int GetValue()
        {
            // получаем случайное значение в границах
            int value = Random.Shared.Next(MinValue, MaxValue + 1);

            // добавляется доп проценты или убираем доп проценты в зависимости от момента создания эффекта
            value += value * SourcePercentage / 100;

            // добавляем доп проценты или убираем доп проценты в зависимости от эффектов на цели
            value += value * GetTargetDamagePercentage() / 100;
            return value < 0 ? 0 : value;
        }

        protected override void TimerCallback(object? state)
        {
            if (TargetIsNull)
                return;

            if (EffectImmuneFound())
                return;

            string logMessage;

            // получаем начальное значение урона
            int damage = GetValue();

            // пробрасываем урон в цель и на выходе получаем изменённое значение урона в зависимости от эффектов и защит
            damage = TargetForEffect!.DamageTarget(damage);

            DecreaseCounterByOne();
            logMessage = $"\"{EffectName}\" наносит {damage} {EffectClass.Genitive}";
            OnTimerTick(logMessage);
        }
    }
}
