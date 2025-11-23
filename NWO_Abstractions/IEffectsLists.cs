namespace NWO_Abstractions
{
    public interface IEffectsLists
    {        
        /// <summary>
        /// Список положительных эффектов
        /// </summary>
        public List<IEffect> PositiveEffects { get; set; }

        /// <summary>
        /// Список отрицательных эффектов
        /// </summary>
        public List<IEffect> NegativeEffects { get; set; }

        /// <summary>
        /// Очистить все стартовые эффекты
        /// </summary>
        public void Clear()
        {
            PositiveEffects.Clear();
            NegativeEffects.Clear();
        }

        /// <summary>
        /// Добавить список эффектов и разделить их на положительные и отрицательные
        /// </summary>
        public void AddAndSpreadEffects(params IEffect[] effects);
    }
}
