using System;

internal static class Solution
{
    internal static void Main()
    {
        var t = int.Parse(Console.ReadLine());

        while(--t >= 0)
        {
            var n = int.Parse(Console.ReadLine());
            var count = 0;

            for(var i = 1; i <= n; i = i + 1)
            {
                for(var j = i + 1; j <= n; j = j + 1)
                {
                    if((i ^ j) <= n)
                    {
                        count = count + 1;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
