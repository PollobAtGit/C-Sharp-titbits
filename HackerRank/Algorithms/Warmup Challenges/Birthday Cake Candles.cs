using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class BirthdayCakeCandles
{
    static int BirthdayCakeCandle(int n, int[] ar)
    {
        return ar
            .GroupBy(x => x)
                .Select(x => new { key = x.Key, count = x.Count() })
                    .OrderByDescending(x => x.count)
                        .First()
                            .count;
    }

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] ar_temp = Console.ReadLine().Split(' ');
        int[] ar = Array.ConvertAll(ar_temp, Int32.Parse);
        int result = BirthdayCakeCandle(n, ar);
        Console.WriteLine(result);
    }
}
