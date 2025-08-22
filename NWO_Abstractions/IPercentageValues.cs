namespace NWO_Abstractions
{
    public interface IPercentageValues
    {
        /// <summary>
        /// Процент увеличения всех воздействий
        /// </summary>
        public int AllLeveragesIncrease { get; set; }

        /// <summary>
        /// Процент уменьшения всех воздействий
        /// </summary>
        public int AllLeveragesDecrease { get; set; }

        /// <summary>
        /// Процент увеличения исходящего восстановления
        /// </summary>
        public int RecoveryIncrease { get; set; }

        /// <summary>
        /// Процент уменьшения восстановления
        /// </summary>
        public int RecoveryDecrease { get; set; }

        /// <summary>
        /// Процент увеличения урона
        /// </summary>
        public int DamageIncrease { get; set; }

        /// <summary>
        /// Процент уменьшения урона
        /// </summary>
        public int DamageDecrease { get; set; }

        /// <summary>
        /// Полный процент увеличения восстановления
        /// </summary>
        public int TotalRecoveryIncrease => RecoveryIncrease + AllLeveragesIncrease;

        /// <summary>
        /// Полный процент увеличения урона
        /// </summary>
        public int TotalDamageIncrease => DamageIncrease + AllLeveragesIncrease;

        /// <summary>
        /// Полный процент уменьшения восстановления
        /// </summary>
        public int TotalRecoveryDecrease => RecoveryDecrease + AllLeveragesDecrease;

        /// <summary>
        /// Полный процент уменьшения урона
        /// </summary>
        public int TotalDamageDecrease => DamageDecrease + AllLeveragesDecrease;

    }
}
