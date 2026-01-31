using NWO_Abstractions.Data.Effects;

namespace NWO_Abstractions.Effects
{
    /// <summary>
    /// Списки положительных и отрицательных эффектов
    /// </summary>
    public interface IEffectsSet
    {
        /// <summary>
        /// В набор добавлен положительный эффект
        /// </summary>
        public event EffectDelegate OnPositiveEffectApplied;
        /// <summary>
        /// В набор добавлен новый отрицательный эффект
        /// </summary>
        public event EffectDelegate OnNegativeEffectApplied;
        /// <summary>
        /// В набор добавлен новый эффект не положительного и не отрицательного типа
        /// </summary>
        public event EffectDelegate OnOtherEffectApplied;

        /// <summary>
        /// Из набора убран положительный эффект
        /// </summary>
        public event EffectDelegate OnPositiveEffectRemoved;
        /// <summary>
        /// Из набора убран отрицательный эффект
        /// </summary>
        public event EffectDelegate OnNegativeEffectRemoved;
        /// <summary>
        /// Из набора был снят эффект не положительного и не отрицательного типа
        /// </summary>
        public event EffectDelegate OnOtherEffectRemoved;
        /// <summary>
        /// Данные для эффектов
        /// </summary>
        public Dictionary<Guid, IEffectData> EffectsData { get; }

        /// <summary>
        /// Список положительных эффектов
        /// </summary>
        public List<IEffect> PositiveEffects { get; set; }

        /// <summary>
        /// Список отрицательных эффектов
        /// </summary>
        public List<IEffect> NegativeEffects { get; set; }

        /// <summary>
        /// Список прочих эффектов (пока все остальные сюда)
        /// </summary>
        public List<IEffect> OtherEffects { get; set; }

        /// <summary>
        /// Очистить все стартовые эффекты
        /// </summary>
        public void Clear()
        {
            PositiveEffects.Clear();
            NegativeEffects.Clear();
            OtherEffects.Clear();
            EffectsData.Clear();
        }

        /// <summary>
        /// Добавить список эффектов и разделить их на положительные и отрицательные
        /// </summary>
        /// <param name="effects">Эффекты</param>
        public void AddAndSpreadEffects(params IEffect[] effects);

        /// <summary>
        /// Добавить данные для эффектов
        /// </summary>
        /// <param name="data">Данные для эффектов</param>
        public void AddEffectsData(params IEffectData[] data);

        /// <summary>
        /// Убрать эффект из набора (по id)
        /// </summary>
        /// <param name="effectId">Идентификатор эффекта</param>
        public void RemoveEffect(Guid effectId);

        /// <summary>
        /// Убрать эффект из набора
        /// </summary>
        /// <param name="effect">Эффект</param>
        public void RemoveEffect(IEffect effect);

        /// <summary>
        /// Убрать список эффектов
        /// </summary>
        /// <param name="effects">Список эффектов</param>
        public void RemoveEffects(List<IEffect> effects);

        /// <summary>
        /// Убрать список эффектов (по id)
        /// </summary>
        /// <param name="effectIds">Список идентификаторов эффектов</param>
        public void RemoveEffects(List<Guid> effectIds);

        /// <summary>
        /// Есть ли эффект от конкретного отправителя в наборе
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        public bool Contains(IEffect effect, Guid effectSenderId) =>
            (PositiveEffects.Contains(effect) || NegativeEffects.Contains(effect) || OtherEffects.Contains(effect))
            && EffectsData.Any(x => x.Key == effect.Id && x.Value.SenderId == effectSenderId);

        /// <summary>
        /// Обновить существующий эффект
        /// </summary>
        /// <param name="effect">Эффект для обновления</param>
        /// <param name="data">Данные для обновления</param>
        public void RefreshEffect(IEffect effect, IEffectData data);

        /// <summary>
        /// Получить процент для эффекта, у которого он есть
        /// </summary>
        /// <param name="effect">Эффект из списка</param>
        /// <returns>Процент</returns>
        public double TryGetPercentage(IEffect effect) => ((IPercentageEffectData)EffectsData[effect.Id]).Percentage;
        //TODO сделать получения процента безопасным, либо возвращать null

        /// <summary>
        /// Получить эффекты в зависимости от типа
        /// </summary>
        /// <typeparam name="T">Тип эффектов</typeparam>
        /// <param name="type">Тип эффектов</param>
        /// <returns>Эффекты определенных типов</returns>
        public IEnumerable<T> GetEffects<T>(EffectType type) where T : IEffect =>
            type switch
            {
                EffectType.Positive => PositiveEffects.Where(x => x is T).Cast<T>(),
                EffectType.Negative => NegativeEffects.Where(x => x is T).Cast<T>(),
                _ => OtherEffects.Where(x => x is T).Cast<T>(),
            };
    }
}
