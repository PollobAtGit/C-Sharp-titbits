using System;

internal static class Solution
{
    internal static void Main()
    {
        try
        {
            var t = int.Parse(Console.ReadLine());

            while(--t >= 0)
            {
                var n = ulong.Parse(Console.ReadLine());

                var zeroBitIndex = GetZeroBitIndex(n);

                var shiftNum = 1ul << zeroBitIndex;

                Console.WriteLine(n | shiftNum);
            }
        }
        catch(Exception)
        {

        }
    }

    internal static int GetZeroBitIndex(ulong n)
    {
        var i = 0;

        while((n & (1ul << i)) != 0)
        {
            i = i + 1;
        }

        return i;
    }
}