using NWO_Abstractions.Battles;

namespace BataBuilder.Items
{
    public class DestroyOneTargetPurpose : IBattlePurpose
    {
        public string DisplayName => "Уничтожить одну цель";

        public string Description => "Требуется опустить здоровье одной цели до нуля.";

        public bool WatchDummy => true;
    }
}
