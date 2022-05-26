using System;
public static class TimeUtil
{
    public static readonly DateTime DateForm = new(1970, 1, 1, 0, 0, 0, 0);

    public static long GetTimeStamp()
    {
        long currentTicks = DateTime.Now.Ticks;
        long curMs = (currentTicks - DateForm.Ticks) / 10000;
        return curMs;
    }
}