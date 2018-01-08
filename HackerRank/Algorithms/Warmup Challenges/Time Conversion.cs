using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class TimeConversion
{
    static string TimeConv(string s)
    {
        var parts = s.Split(':');
        var isAm = parts[2].Substring(2) == "AM";

        int hour = int.Parse(parts[0]);
        int minute = int.Parse(parts[1]);
        int second = int.Parse(parts[2].Replace("AM", "").Replace("PM", ""));

        if (hour == 12 && isAm)
        {
            hour = 0;
        }

        if (!isAm && hour != 12)
        {
            hour = hour + 12;
        }

        return hour.ToString("00") + ":" + minute.ToString("00") + ":" + second.ToString("00");
    }

    static void Main(String[] args)
    {
        string s = Console.ReadLine();
        string result = TimeConv(s);
        Console.WriteLine(result);
    }
}
