using NWO_Abstractions.Battles;

namespace NWO_Abstractions
{
    public delegate void NewIntValue(int newValue);
    public delegate void NewDoubleValue(double newValue);
    public delegate void NewUnitLogMessage(string logMessage);
    public delegate void EffectDelegate(IEffect Effect);

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
        public event NewIntValue OnTargetDamaged;
        /// <summary>
        /// Цель получила новое восстановление
        /// </summary>
        public event NewIntValue OnTargetRecovered;
        /// <summary>
        /// Изменилось здоровье цели
        /// </summary>
        public event NewDoubleValue OnHealthChanged;

        /// <summary>
        /// На цель был наложен новый положительный эффект
        /// </summary>
        public event EffectDelegate OnPositiveEffectApplied;
        /// <summary>
        /// На цель был наложен новый отрицательный эффект
        /// </summary>
        public event EffectDelegate OnNegativeEffectApplied;
        /// <summary>
        /// С цели был убран положительный эффект
        /// </summary>
        public event EffectDelegate OnPositiveEffectRemoved;
        /// <summary>
        /// С цели был убран отрицательный эффект
        /// </summary>
        public event EffectDelegate OnNegativeEffectRemoved;

        /// <summary>
        /// Начальные проценты увеличения/уменьшения воздейтвий
        /// </summary>
        public IPercentageValues StartPercentageValues { get; }

        /// <summary>
        /// Эффекты на цели
        /// </summary>
        public IEffectsLists Effects { get; }

        public List<IDefence> Defences { get; }

        public List<IImmune> Immunes { get; }

        /// <summary>
        /// Нанести урон цели
        /// </summary>
        /// <returns></returns>
        public int DamageTarget(int value);

        /// <summary>
        /// Вылечить цель
        /// </summary>
        /// <returns></returns>
        public int RecoverTarget(int value);

        /// <summary>
        /// Применить положительный эффект к цели
        /// </summary>
        /// <returns></returns>
        public void ApplyPositiveEffect(IEffect effect, int percentage = 0);

        /// <summary>
        /// Снять положительный эффект с цели
        /// </summary>
        /// <returns></returns>
        public void RemovePositiveEffect(IEffect effect);

        /// <summary>
        /// Применить отрицательный эффект к цели
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        public void ApplyNegativeEffect(IEffect effect, int percentage = 0);

        /// <summary>
        /// Снять отрицательный эффект с цели
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        public void RemoveNegativeEffect(IEffect effect);

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
