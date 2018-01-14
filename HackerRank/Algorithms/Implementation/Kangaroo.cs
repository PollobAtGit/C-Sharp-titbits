using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Kangaroo
{

    static string KangarooCal(int x1, int v1, int x2, int v2)
    {
        if (v1 == v2 && x1 == x2) return "YES";
        if (v1 == v2 && x1 != x2) return "NO";
        if (x1 > x2 && v2 > v1 && (Math.Abs(x1 - x2) % Math.Abs(v1 - v2) == 0)) return "YES";
        if (x1 < x2 && v2 < v1 && (Math.Abs(x1 - x2) % Math.Abs(v1 - v2) == 0)) return "YES";
        return "NO";
    }

    static void Main(String[] args)
    {
        string[] tokens_x1 = Console.ReadLine().Split(' ');

        int x1 = Convert.ToInt32(tokens_x1[0]);
        int v1 = Convert.ToInt32(tokens_x1[1]);
        int x2 = Convert.ToInt32(tokens_x1[2]);
        int v2 = Convert.ToInt32(tokens_x1[3]);

        string result = KangarooCal(x1, v1, x2, v2);

        Console.WriteLine(result);
    }
}
