using System;

internal static class Solution
{
    internal static void Main()
    {
        var str = Console.ReadLine();

        var toggledStr = Toggle(str, str.Length - 1);

        Console.WriteLine(toggledStr);
    }

    private static string Toggle(string str, int i)
    {
        if(i == 0) return ToggleChar(str[i]);
        return ToggleChar(str[0]) + Toggle(str.Substring(1, str.Length - 1), i - 1);
    }

    private static string ToggleChar(char ch)
    {
        if(!Char.IsLetter(ch)) return null;
        
        var toggledChar = Char.IsLower(ch) ? Char.ToUpper(ch) : Char.ToLower(ch);
        return toggledChar.ToString();
    }
}
