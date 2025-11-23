using NWO_Abstractions.Battles;

namespace BataBuilder.Items
{
    public class RecoverOneTargetPurpose : IBattlePurpose
    {
        public string RussianDisplayName => "Восстановить одну цель";

        public string Description => "Требуется восстановить здорвье одной цели до максимума.";
    }
}
