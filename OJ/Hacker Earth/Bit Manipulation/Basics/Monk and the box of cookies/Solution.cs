using System;
using System.Linq;

internal static class Solution
{
    internal static void Main()
    {
        var t = int.Parse(Console.ReadLine());

        while(--t >= 0)
        {
            var n = int.Parse(Console.ReadLine());

            var ns = new int[n];

            for(var i = 0; i < n; i = i + 1)
            {
                ns[i] = int.Parse(Console.ReadLine());
            }

            var indexWiseFrequencey = new int[32];

            for(var i = 0; i < ns.Length; i = i + 1)
            {
                var num = ns[i];

                //POI: Might be optimized
                for(var j = 0; j < 32; j = j + 1)
                {
                    if((num & (1 << j)) != 0)
                    {
                        indexWiseFrequencey[j] = indexWiseFrequencey[j] + 1;
                    }
                }
            }

            Console.WriteLine(indexWiseFrequencey.ToList().IndexOf(indexWiseFrequencey.Max()));
        }
    }
}