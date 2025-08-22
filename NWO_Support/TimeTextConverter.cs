namespace NWO_Support;

public static class TimeTextConverter
{
    public static int ConvertToSeconds(int hours, int minutes, int seconds)
    {
        return (hours * 3600 + minutes* 60  + seconds);
    }

    public static string ConvertToText(int seconds)
    {
        if (seconds < 0) 
            seconds = 0;

        int hours = 0;
        int minutes = 0;

        while (seconds > 3600)
        {
            hours++;
            seconds -= 3600;
        }

        while (seconds > 60)
        {
            minutes++;
            seconds -= 60;
        }

        return $"{GetTimeString(hours)}:{GetTimeString(minutes)}:{GetTimeString(seconds)}";
    }

    public static string GetTimeString(int time)
    {
        string timeString = time.ToString();
        if (timeString.Length == 1)
            timeString = $"0{timeString}";
        return timeString;
    }
}

