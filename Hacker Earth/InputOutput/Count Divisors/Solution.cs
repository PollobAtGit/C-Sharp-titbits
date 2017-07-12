using System;

internal static class Solution
{
    internal static void Main()
    {
        var lrk = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);

        var divisors = 0;
        for(var i = lrk[0]; i <= lrk[1]; i = i + 1)
        {
            if(i % lrk[2] == 0)
            {
                divisors = divisors + 1;
            }
        }
        Console.WriteLine(divisors);
    }
}
