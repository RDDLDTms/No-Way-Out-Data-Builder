using NWO_Abstractions.Battles;
using NWO_Abstractions.Effects;
using NWO_Abstractions.Skills;

namespace NWO_Abstractions
{
    public delegate void NewIntValue(int newValue);
    public delegate void NewDoubleValue(double newValue);
    public delegate void EffectPeriodicTick(IEffect effect, double value);
    public delegate void EffectDelegate(IEffect Effect);
    public delegate void EffectWithDurationDelegateFinished(IEffectWithDuration effect, EffectFinishReason finishReason);

    /// <summary>
    /// Цель
    /// </summary>
    public interface ITarget : IHealthChangingObject, IUniversalObject, ITeamMember
    {
        /// <summary>
        /// Идентификатор цели
        /// </summary>
        public Guid TargetId { get; }

        /// <summary>
        /// Цель получила новый урон
        /// </summary>
        public event NewDoubleValue OnTargetDamaged;
        /// <summary>
        /// Цель получила новое восстановление
        /// </summary>
        public event NewDoubleValue OnTargetRecovered;
        /// <summary>
        /// Изменилось здоровье цели
        /// </summary>
        public event NewDoubleValue OnHealthChanged;

        /// <summary>
        /// Начальные проценты увеличения/уменьшения воздейтвий
        /// </summary>
        public IPercentageValues StartPercentageValues { get; }

        /// <summary>
        /// Набор эффектов цели
        /// </summary>
        public IEffectsSet Effects { get; }

        /// <summary>
        /// Защиты цели
        /// </summary>
        public List<IDefence> Defences { get; }

        /// <summary>
        /// Иммунитеты цели
        /// </summary>
        public List<IImmune> Immunes { get; }

        /// <summary>
        /// Нанести цели урон
        /// </summary>
        /// <param name="value">Сколько урона отправлено цели из источника</param>
        /// <returns>Сколько урона цель реально получила</returns>
        public double DamageTarget(double value);

        /// <summary>
        /// Восстановить цель
        /// </summary>
        /// <param name="value">Сколько восстановления отправлено цели из источника</param>
        /// <returns>Сколько восстановления реально получено целью</returns>
        public double RecoverTarget(double value);

        /// <summary>
        /// Применить эффект к цели
        /// </summary>
        /// <param name="effectResultPart">Результат выполнения умения</param>
        public void ApplyEffect(ISkillEffectResultPart effectResultPart);

        /// <summary>
        /// Снять эффекты с цели
        /// </summary>
        /// <returns></returns>
        public void RemoveEffects(List<IEffect> effects);

        /// <summary>
        /// Присоединиться к битве
        /// </summary>
        public void JoinBattle(IBattleModelling battle, int teamNumber, int globalCooldown);

        /// <summary>
        /// Покинуть битву
        /// </summary>
        public void LeaveBattle();
    }
}
