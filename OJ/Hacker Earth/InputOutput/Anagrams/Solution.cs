using System;

internal class Anagram
{
    public static void Main()
    {
        var q = int.Parse(Console.ReadLine());

        while (--q >= 0)
        {
            var s = Console.ReadLine();
            var t = Console.ReadLine();
            var dC = 0;

            var fS = new int[128];
            var fT = new int[128];

            for (int i = 0; i < s.Length; i++) fS[s[i]]++;
            for (int i = 0; i < t.Length; i++) fT[t[i]]++;
            for (int i = 0; i < fS.Length; i++) dC = dC + Math.Abs(fS[i] - fT[i]);

            Console.WriteLine(dC);
        }
    }
}
