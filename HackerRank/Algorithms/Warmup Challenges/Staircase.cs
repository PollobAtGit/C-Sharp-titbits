using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Warmup_Challenges
{
    class Staircase
    {
        static void staircase(int n)
        {
            for (var i = 1; i <= n; i = i + 1)
            {
                var spacesCount = n - i;

                for (var j = 0; j < spacesCount; j = j + 1) { Console.Write(" "); }
                for (var z = 0; z < n - spacesCount; z = z + 1) { Console.Write("#"); }

                Console.WriteLine();
            }
        }

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            staircase(n);
        }
    }

}
