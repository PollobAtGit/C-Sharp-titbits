using System;
using System.Linq;

internal static class Ans
{
    internal static void Main()
    {
        Console.ReadLine();
        var a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        var b = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        for(var i = 0; i < a.Length; i++)
        {
            Console.Write(a[i] + b[i] + " ");
        }
        Console.WriteLine();

        Console.WriteLine(string.Join(" ", SumArrWithLinq(a, b)));
    }

    //POI: Zip privides better performance
    private static int[] SumArrWithLinq(int[] a, int[] b)
    {
        return a.Zip(b, (ai, bi) => ai + bi).ToArray();
    }
}
