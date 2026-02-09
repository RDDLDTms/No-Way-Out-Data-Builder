namespace DataBuilder.BuilderObjects
{
    /// <summary>
    /// Объект, который может логгировать происходящее с собой
    /// </summary>
    public interface ILogObject
    {
        #region Outcoming
        /// <summary>
        /// Логгировать исходщий урон
        /// </summary>
        public void LogOutcomingDamage(string actorName, string targetName, double damage);

        /// <summary>
        /// Логгировать исходящее восстановление
        /// </summary>
        public void LogOutcomingRecovery(string actorName, string targetName, double recovery);

        /// <summary>
        /// Логгировать исходящее наложение эффекта
        /// </summary>
        public void LogOutcomingEffect(string actorName, string tragteName, string effectName);
        #endregion

        #region Incoming
        /// <summary>
        /// Логгировать входящий урон
        /// </summary>
        public void LogIncomingDamage();
        /// <summary>
        /// Логгировать входящее восстановление
        /// </summary>
        public void LogIncomingRecovery();
        /// <summary>
        /// Логгировать получение нового эффекта
        /// </summary>
        public void LogIncomingEffect();

        #endregion
    }
}
