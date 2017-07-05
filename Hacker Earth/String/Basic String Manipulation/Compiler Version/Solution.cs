using System;

internal static class Solution
{
    internal static void Main()
    {
        var str = Console.ReadLine();

        while(str != null)
        {
            var didCommentStart = false;

            for(var i = 0; i < str.Length; i++)
            {
                var ch = str[i];

                //POI: IF (i + 1) is used in condition then possibility is higher that normal
                //enumeration for (i + 1) is not desired
                
                if((i < str.Length - 1) && ch == '/' && str[i + 1] == '/' && !didCommentStart)
                {
                    didCommentStart = true;
                }

                if((i < str.Length - 1) && ch == '-' && str[i + 1] == '>' && !didCommentStart)
                {
                    Console.Write(".");
                    i++;
                } else
                {
                    Console.Write(ch);
                }
            }

            Console.WriteLine();

            str = Console.ReadLine();
        }
    }
}