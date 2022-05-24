using System;
public static class TimeUtil
{
    public static long GetTimeStamp()
    {
        long currentTicks = DateTime.Now.Ticks;
        DateTime dtFrom = new(1970, 1, 1, 0, 0, 0, 0);
        long curMs = (currentTicks - dtFrom.Ticks) / 10000;
        return curMs;
    }
}