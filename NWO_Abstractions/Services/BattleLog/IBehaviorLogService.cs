namespace NWO_Abstractions.Services.BattleLog
{
    public interface IBehaviorLogService
    {
        /// <summary>
        /// Получить сообщение об изменении поведения юнита на новое
        /// </summary>
        /// <param name="unitName">Имя юнита</param>
        /// <param name="behavior">Новое поведение</param>
        /// <returns></returns>
        public string GetUnitBehaviorChangeMessage(string unitName, IBehavior behavior);

        /// <summary>
        /// Получить сообщение об ожидании откатов умений юнитом
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns>Сообщение для лога</returns>
        public string GetUnitWaitingSkillCooldownsMessage(string unitName);
    }
}
