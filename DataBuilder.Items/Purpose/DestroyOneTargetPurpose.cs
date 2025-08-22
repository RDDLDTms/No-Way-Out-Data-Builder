using NWO_Abstractions;

namespace BataBuilder.Items
{
    public class DestroyOneTargetPurpose : IPurpose
    {
        public string RussianDisplayName => "Уничтожить одну цель";

        public string Description => "Требуется опустить здоровье одной цели до нуля.";
    }
}
