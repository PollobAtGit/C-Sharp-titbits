using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class DiagonalDiff
{

    static int diagonalDifference(int[][] a)
    {

        int leftDiagonalSum = 0;
        int rightDiagonalSum = 0;

        for (int i = 0; i < a.Length; i++)
        {
            leftDiagonalSum += a[i][i];
            rightDiagonalSum += a[i][(a.Length - 1) - i];
        }

        return leftDiagonalSum > rightDiagonalSum ? leftDiagonalSum - rightDiagonalSum : rightDiagonalSum - leftDiagonalSum;
    }

    static void Main(String[] args)
    {

        int n = Convert.ToInt32(Console.ReadLine());

        int[][] a = new int[n][];

        for (int a_i = 0; a_i < n; a_i++)
        {

            string[] a_temp = Console.ReadLine().Split(' ');
            a[a_i] = Array.ConvertAll(a_temp, Int32.Parse);

        }

        int result = diagonalDifference(a);
        Console.WriteLine(result);
    }
}
