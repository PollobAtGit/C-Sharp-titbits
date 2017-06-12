using System;
using System.Linq;

internal static class Ans
{
    internal static void Main()
    {
        var t = int.Parse(Console.ReadLine());

        while(--t >= 0)
        {
            var nk = Console.ReadLine().Split(' ');

            var n = int.Parse(nk[0]);
            var k = int.Parse(nk[1]);

            var a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            //POI: Subtract: Possibility of getting negative numbers
            var minTime = UsingLinq(a, k);
            // var minTimeUsingLoop = UsingLoop(a, k);

            Console.WriteLine(minTime < 0 ? 0 : minTime);
            // Console.WriteLine(minTimeUsingLoop < 0 ? 0 : minTimeUsingLoop);
        }
    }

    internal static int UsingLinq(int[] a, int k) => k - a.Min();

    internal static int UsingLoop(int[] a, int k)
    {
        var min = int.MaxValue;

        foreach(var el in a)
        {
            min = Math.Min(min, el);
        }

        return min;
    }
}