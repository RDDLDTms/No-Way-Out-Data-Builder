using NWO_Abstractions;
using NWO_Abstractions.Enums;
using NWO_Support;

namespace NWO_Battles
{
    public class BattleMessage : IBattleMessage
    {
        public string TextMessage { get; } = string.Empty;

        public string Time => $"{GetText(DateTime.Now.TimeOfDay.Hours)}:{GetText(DateTime.Now.TimeOfDay.Minutes)}:{GetText(DateTime.Now.TimeOfDay.Seconds)}";

        public byte[]? Icon { get; } = null;

        public BattleMessageCategory Category { get; } = BattleMessageCategory.Unknown;

        public BattleMessage(string text)
        {
            TextMessage = text;
        }

        public BattleMessage(string text, BattleMessageCategory category) : this(text)
        { 
            Category = category;
        }

        private string GetText(int intValue) => TimeTextConverter.GetTimeString(intValue);
    }
}
