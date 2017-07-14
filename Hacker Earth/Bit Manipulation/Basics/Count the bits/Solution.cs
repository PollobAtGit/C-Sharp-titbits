using System;

internal static class Solution
{
    internal static void Main()
    {
        var t = int.Parse(Console.ReadLine());

        while(--t >= 0)
        {
            var n = int.Parse(Console.ReadLine());

            var bitCount = 0;
            while(n != 0)
            {
                bitCount = bitCount + 1;
                n = n & (n - 1);
            }

            Console.WriteLine(bitCount);
        }
    }
}
