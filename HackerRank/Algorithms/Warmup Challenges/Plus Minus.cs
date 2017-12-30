using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Warmup_Challenges
{
    class PlusMinus
    {
        static void plusMinus(int[] arr)
        {
            Console.WriteLine(Math.Round(arr.Count(x => x > 0) / (double)arr.Length, 6).ToString("0.000000"));
            Console.WriteLine(Math.Round(arr.Count(x => x < 0) / (double)arr.Length, 6).ToString("0.000000"));
            Console.WriteLine(Math.Round(arr.Count(x => x == 0) / (double)arr.Length, 6).ToString("0.000000"));
        }

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
            plusMinus(arr);
        }
    }
}