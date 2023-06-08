using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class DateTimeExtensions
{

    public static DateTime ToSecondsOnly(this DateTime self)
    {
        var format = "yyyy/MM/dd HH:mm:ss";
        var str = self.ToString(format);
        return DateTime.Parse(str);
    }

    public static double TicksToSeconds(this long self)
    {
        // 10 NS -> Seconds
        return self * 0.0000001;
    }

    public static long SecondsToTicks(this double self)
    {
        return (long)(self * (10 * 1000 * 1000));
    }

    public static long SecondsToTicks(this float self)
    {
        return (long)(self * (10 * 1000 * 1000));
    }

    public static long TicksToTotalSeconds(this long self)
    {
        return self / (10 * 1000 * 1000);
    }
}