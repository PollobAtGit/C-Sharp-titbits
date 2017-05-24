using System;
using System.Linq;

internal class Ans
{
    internal static void Main()
    {
        var t = System.Int32.Parse(Console.ReadLine());

        while(--t >= 0)
        {
            var n = System.Int32.Parse(Console.ReadLine());

            var nameSequence = new string[n];

            for(var i = 0; i < n; i++) nameSequence[i] = Console.ReadLine();

            Console.WriteLine(MaxLengthNameByLinq(nameSequence));
            Console.WriteLine(maxLengthName(nameSequence));
        }
    }

    internal static string MaxLengthNameByLinq(string[] arr) => arr.OrderByDescending(name => name.Length).First();

    internal static string maxLengthName(string[] arr)
    {
        var maxLengthName = "";
        foreach(var name in arr) 
            if(maxLengthName.Length < name.Length)
                maxLengthName = name;

        return maxLengthName;
    }
}
