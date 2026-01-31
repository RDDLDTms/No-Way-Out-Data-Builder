using NWO_Abstractions.Battles;

namespace BataBuilder.Items
{
    public class RecoverOneOtherTargetPurpose : IBattlePurpose
    {
        public string RussianDisplayName => "Восстановить одну цель (не себя)";

        public string Description => "Требуется восстановить здоровье одной цели (не себя) до максимума.";

        public bool WatchDummy => true;
    }
}
