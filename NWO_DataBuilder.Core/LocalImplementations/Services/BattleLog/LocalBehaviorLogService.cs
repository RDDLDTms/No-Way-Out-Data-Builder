using DataBuilder.Units.Behaviors;
using NWO_Abstractions;
using NWO_Abstractions.Services.BattleLog;

namespace NWO_DataBuilder.Core.LocalImplementations.Services.BattleLog
{
    public class LocalBehaviorLogService : IBehaviorLogService
    {
        public string GetUnitBehaviorChangeMessage(string unitName, IBehavior behavior) =>
            behavior switch
            {
                BattleBehavior => $"{unitName} вступает в битву!",
                PeacefulStandingBehavior => $"{unitName} мирно останавливается",
                PeacefulWalkingBehavior => $"{unitName} мирно перемещается",
                _ => $"{unitName} вышел из под контроля! (неизвестный тип поведения)",
            };

        public string GetUnitWaitingSkillCooldownsMessage(string unitName) => $"{unitName} ожидает откатов умений";
    }
}
