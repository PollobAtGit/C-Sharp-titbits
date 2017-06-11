using System;
using System.Text;
using System.Linq;

internal static class Ans
{
    internal static void Main()
    {
        var str = Console.ReadLine();
        Console.WriteLine(ReverseString(str));
        Console.WriteLine(ReverseStringLINQ(str));
        Console.WriteLine(ReverseStringAppend(str));
    }

    private static string ReverseStringAppend(string s)
    {
        var str = new StringBuilder();

        for (int i = s.Length - 1; i >= 0; i--) str.Append(s[i]);

        return str.ToString();
    }

    private static string ReverseString(string s)
    {
        //POI: Creating this String Builder takes some time. So even though main algorithm is O(n/2) it might not have much impact
        var str = new StringBuilder(s);

        var i = 0;
        var j = str.Length - 1;

        while(i < j)
        {
            var tmp = str[i];
            str[i] = str[j];
            str[j] = tmp;

            i = i +1;
            j = j - 1;
        }

        return str.ToString();
    }

    private static string ReverseStringLINQ(string s) => new string(s.Reverse().ToArray());
}