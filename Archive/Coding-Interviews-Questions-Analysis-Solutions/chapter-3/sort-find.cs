using System;
using System.Linq;
using System.Collections.Generic;

static class Ans
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] inputArray = PopulateArray(n);

        //TODO: Find a better approach
        Array.Sort(inputArray);

        inputArray.ForEach();

        var duplicatedValueStr = GetFirstDuplicateElement(inputArray);

        Console.WriteLine("Duplicate: " + (duplicatedValueStr ?? "NONE"));
    }

    //TODO: Try nullable int type
    private static string GetFirstDuplicateElement(int[] array)
    {
        var length = array.Length;
        for (int i = 0; i < (length - 1); i++)
            if(array[i] == array[i + 1])
                return array[i].ToString();

        return null;
    }

    internal static int[] PopulateArray(int n)
    {
        try
        {
            int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            if(array.Length != n) throw new Exception("More Elements Than Expected");

            return array;
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    private static void ForEach(this IEnumerable<int> source)
    {
        Console.WriteLine();

        var elementsString = string.Join(" ", source.Select(elem => elem.ToString()));

        Console.WriteLine(elementsString);
        Console.WriteLine();
    }
}
