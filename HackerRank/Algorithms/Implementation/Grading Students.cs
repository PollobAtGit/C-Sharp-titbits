
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class GradingStudents
{

    static int[] solve(int[] grades)
    {
        return grades.Select(g =>
        {
            if (g < 38) return g;
            if (((5 * ((g / 5) + 1)) - g) < 3) { return 5 * ((g / 5) + 1); }
            return g;
        }).ToArray();
    }

    static void Main(String[] args)
    {

        int n = Convert.ToInt32(Console.ReadLine());
        int[] grades = new int[n];

        for (int grades_i = 0; grades_i < n; grades_i++)
        {
            grades[grades_i] = Convert.ToInt32(Console.ReadLine());
        }

        int[] result = solve(grades);
        Console.WriteLine(String.Join("\n", result));
    }
}
