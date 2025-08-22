using NWO_Abstractions;

namespace DataBuilder.Effects.PeriodicEffects.EffectsOnTarget
{
    public sealed class TargetPeriodicDamageEffect : EffectWithValuesBase
    {
        public override LeverageType Type => LeverageType.NegativeEffectApplying;
        public override EffectCarrier Carrier => EffectCarrier.Target;

        public TargetPeriodicDamageEffect(int duration, ILeverageClass effectClass, double cooldown, string effectName, int minValue, int maxValue) :
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
