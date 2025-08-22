using NWO_Support;

namespace NWO_Battles
{
    public class BattleTestMessage
    {
        public string TextMessage { get; private set; }

        public string Time { get; private set; }

        public BattleTestMessage(string textMessage)
        {
            TextMessage = textMessage;
            Time = $"{TimeTextConverter.GetTimeString(DateTime.Now.TimeOfDay.Hours)}:{TimeTextConverter.GetTimeString(DateTime.Now.TimeOfDay.Minutes)}:{TimeTextConverter.GetTimeString(DateTime.Now.TimeOfDay.Seconds)}";
        }
    }
}
