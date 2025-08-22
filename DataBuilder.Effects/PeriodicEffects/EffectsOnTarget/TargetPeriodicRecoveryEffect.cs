using NWO_Abstractions;

namespace DataBuilder.Effects.PeriodicEffects.EffectsOnTarget
{
    public sealed class TargetPeriodicRecoveryEffect : EffectWithValuesBase
    {
        public override LeverageType Type => LeverageType.PositiveEffectApplying;
        public override EffectCarrier Carrier => EffectCarrier.Target;

        public TargetPeriodicRecoveryEffect(int duration, ILeverageClass effectClass, double cooldown, string effectName, int minValue, int maxValue) :
            base(duration, effectClass, cooldown, effectName, minValue, maxValue)
        {

        }

        protected override void TimerCallback(object? state)
        {
            if (TargetIsNull)
                return;

            if (EffectImmuneFound())
                return;

            string logMessage;

            // получаем начальное значение восстановления
            int recover = GetValue();

            // пробрасываем урон в цель и на выходе получаем изменённое значение восстановления в зависимости от эффектов и защит
            recover = TargetForEffect!.RecoverTarget(recover);

            DecreaseCounterByOne();
            logMessage = $"\"{EffectName}\" восстанавливает {recover} {EffectClass.Genitive}";
            OnTimerTick(logMessage);
        }
    }
}
