using System;
using System.Linq;
using System.Collections.Generic;

internal static class Ans
{
    internal static void Main()
    {
        var t = int.Parse(Console.ReadLine());

        while(--t >= 0)
        {
            Console.WriteLine(RomanToInt(Console.ReadLine()));
        }
    }

    private static int RomanToInt(string s) 
    {
        //POI: One alternative to Dictionary but to achieve constant look up is to use 'switch' construct
        //POI: Roman numeral system depends on 7 basic symbols (I, V, X, L, C, D, M)
        var romanToDecimalMap = new Dictionary<string, int>
        {
            { "I", 1 }
            , { "V", 5 }
            , { "X", 10 }
            , { "L", 50 }
            , { "C", 100 }
            , { "D", 500 }
            , { "M", 1000 }
            , { "IV", 4 }
            , { "IX", 9 }
            , { "XL", 40 }
            , { "XC", 90 }
            , { "CD", 400 }
            , { "CM", 900 }
        };

        var total = 0;
        for(var i = s.Length - 1; i >= 0; )
        {
            //POI: Accessing surrounding value of 'i'. So possibility of out of index
            if((i - 1 >= 0) && romanToDecimalMap.ContainsKey(s[i - 1].ToString() + s[i].ToString()))
            {
                total = total + romanToDecimalMap[s[i - 1].ToString() + s[i].ToString()];
                i = i - 2;
                continue;
            }

            if(romanToDecimalMap.ContainsKey(s[i].ToString()))
            {
                total = total + romanToDecimalMap[s[i].ToString()];
                i = i - 1;
            }
        }

        return total;
    }
}
