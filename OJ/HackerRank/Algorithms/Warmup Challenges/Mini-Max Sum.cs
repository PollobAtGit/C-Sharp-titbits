using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class MiniMaxSum
{

    static void miniMaxSum(int[] arr)
    {
        // POI: Summation for Int32 values might cause overflow
        long minSum = Int64.MaxValue;
        long maxSum = Int64.MinValue;
        int i = 0;

        while (i < arr.Length)
        {
            int j = 0;
            long sum = 0;

            while (j < arr.Length)
            {
                if (i != j)
                {
                    sum = sum + arr[j];
                }
                j = j + 1;
            }

            if (sum > maxSum)
            {
                maxSum = sum;
            }

            if (sum < minSum)
            {
                minSum = sum;
            }

            i = i + 1;
        }

        Console.WriteLine(minSum + " " + maxSum);
    }

    static void Main(String[] args)
    {
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
        miniMaxSum(arr);
    }
}
