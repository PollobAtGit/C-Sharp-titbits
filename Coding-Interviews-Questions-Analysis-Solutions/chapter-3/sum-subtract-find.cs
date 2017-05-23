using System;
using System.Linq;

internal static class Ans
{
    internal static void Main()
    {
        //DRWBK: Values have to be non-negative

        //var inputArray = new int[] { 0, 1, 2, 1 };
        //var inputArray = new int[] { 0, 0 };
        var inputArray = new int[] { 1, 0, 0 };

        var n = inputArray.Length - 1;

        var expectedSumation = n * ( n - 1 ) / 2;

        //CMPLX: O(n)
        var currentSummation = inputArray.Sum();

        Print(currentSummation - expectedSumation);
    }

    internal static void Print(object msg)
    {
        Console.WriteLine(msg);
    }
}