using NWO_Abstractions.Enums;

namespace NWO_Abstractions
{
    /// <summary>
    /// Сообщение лога боя
    /// </summary>
    public interface IBattleMessage
    {
        public string TextMessage { get; }

        public string Time { get; }

        public byte[]? Icon { get; }

        public BattleMessageCategory Category { get; }
    }
}
