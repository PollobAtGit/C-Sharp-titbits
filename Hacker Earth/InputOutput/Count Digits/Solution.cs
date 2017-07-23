using System.Collections.Generic;
using static System.Console;

internal static class Solution
{
    internal static void Main()
    {
        // ArrayMain();
        AnotherMain();
    }

    internal static void ArrayMain()
    {
        var digitWiseFrequency = new int[10];

        foreach(var ch in ReadLine())
        {
            var chNum = int.Parse(ch.ToString());
            digitWiseFrequency[chNum] = digitWiseFrequency[chNum] + 1;
        }

        for (int i = 0; i < digitWiseFrequency.Length; i = i + 1)
        {
            WriteLine(i + " " + digitWiseFrequency[i]);
        }
    }

    internal static void AnotherMain()
    {
        var digitWiseFrequency = new Dictionary<int, int>();

        foreach(var ch in ReadLine())
        {
            var chNum = int.Parse(ch.ToString());

            if(digitWiseFrequency.ContainsKey(chNum))
            {
                digitWiseFrequency[chNum] = digitWiseFrequency[chNum] + 1;
            } else
            {
                // POI: Adding a number to dictionary which means the number has been found. So count is '1'
                // at the beginning
                digitWiseFrequency.Add(chNum, 1);
            }
        }

        for(var i = 0; i < 10; i = i + 1)
        {
            if(digitWiseFrequency.ContainsKey(i))
            {
                WriteLine(i + " " + digitWiseFrequency[i]);
            } else
            {
                WriteLine(i + " 0");
            }
        }
    }
}