using NWO_Abstractions;

namespace DataBuilder.Effects
{
    public sealed class TargetPeriodicRecoveryEffect : EffectWithValuesBase
    {
        public override LeverageType Type => LeverageType.PositiveEffectApplying;
        public override EffectCarrier Carrier => EffectCarrier.Target;

        public TargetPeriodicRecoveryEffect(int duration, ILeverage leverage, double cooldown, int minValue, int maxValue) :
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
            value += value * GetTargetRecoveryPercentage() / 100;
            return value < 0 ? 0 : value;
        }

        protected override void TimerCallback(object? state)
        {
            if (TargetIsNull)
                return;

            if (EffectImmuneFound())
                return;

            string logMessage;

            // получаем начальное значение восстановления
            int recovering = GetValue();

            // пробрасываем урон в цель и на выходе получаем изменённое значение восстановления в зависимости от эффектов и защит
            recovering = TargetForEffect!.RecoverTarget(recovering);

            DecreaseCounterByOne();
            logMessage = BattleLogService.GetPeriodicRecoveringTextMessage(EffectDisplayName, recovering, EffectClass.Genitive, TargetForEffect.IsMech);
            OnTimerTick(logMessage);
        }
    }
}
