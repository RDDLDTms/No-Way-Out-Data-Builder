using NWO_Support;

namespace NWO_Battles
{
    public class BattleTextMessage
    {
        public string TextMessage { get; private set; }

        public string Time { get; private set; }

        public BattleTextMessage(string textMessage)
        {
            TextMessage = textMessage;
            Time = $"{TimeTextConverter.GetTimeString(DateTime.Now.TimeOfDay.Hours)}:{TimeTextConverter.GetTimeString(DateTime.Now.TimeOfDay.Minutes)}:{TimeTextConverter.GetTimeString(DateTime.Now.TimeOfDay.Seconds)}";
        }
    }
}
