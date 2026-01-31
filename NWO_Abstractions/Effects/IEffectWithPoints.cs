namespace NWO_Abstractions.Effects
{
    /// <summary>
    /// Эффект с очками
    /// </summary>
    internal interface IEffectWithPoints
    {
        /// <summary>
        /// Максимальное количество очков для эффекта
        /// </summary>
        public int MaxPoints { get; }

        /// <summary>
        /// Текушщее количество очков для эффекта
        /// </summary>
        public int Points { get; }

        /// <summary>
        /// Увеличить количество очков эффекта
        /// </summary>
        /// <param name="points">На сколько увеличить</param>
        public void InrecrasePoints(int points);

        /// <summary>
        /// Уменьшить количество очков эффекта
        /// </summary>
        /// <param name="points">на сколько уменьшить</param>
        public void DecreasePoints(int points);
    }
}
