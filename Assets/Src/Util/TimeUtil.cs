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


    public static long DataTime2TimeStamp(DateTime dateTime)
    {
        long curMs = (dateTime.Ticks - DateForm.Ticks) / 10000;
        return curMs;
    }

    public static long GetServerTimeStamp()
    {
        return GetTimeStamp();// todo 
    }

    // 获取当天结束的时间
    public static DateTime GetDayEndTime()
    {
        long curServerTimestamp = GetServerTimeStamp();
        DateTime curDateTime = new(curServerTimestamp);
        DateTime endDataTime = new(curDateTime.Year, curDateTime.Month, curDateTime.Day, 23, 59, 59);
        return endDataTime;
    }

    // 获取本周结束的时间(周六)
    public static DateTime GetWeekEndTime()
    {
        long curServerTimestamp = GetServerTimeStamp();
        DateTime curDateTime = new(curServerTimestamp);
        DateTime dayEndDataTime = GetDayEndTime();
        int offsetDay = DayOfWeek.Saturday - curDateTime.DayOfWeek;
        DateTime weekEndDataTime = dayEndDataTime.AddDays(offsetDay);
        return weekEndDataTime;
    }

}