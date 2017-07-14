using System;

internal static class Solution
{
    private static int[] primes = new int[] { 67 , 71 , 73 , 79 , 83 , 89 , 97 , 101 , 103 , 107 , 109 , 113 };

    internal static void Main()
    {
        var t = int.Parse(Console.ReadLine());

        while(--t >= 0)
        {
            Console.ReadLine();

            var str = Console.ReadLine();
            for(var i = 0; i < str.Length; i = i + 1)
            {
                Console.Write((char)GetClosestPrime((int)str[i]));
            }

            Console.WriteLine();
        }
    }

    internal static int GetClosestPrime(int n)
    {
        var index = 0;
        var i = 0;
        for(; i < primes.Length && n >= primes[i]; i = i + 1)
        {
            index = i;
        }

        if(i < primes.Length && n == primes[i]) index = index - 1;
        if((index == primes.Length - 1) || (n - primes[index] <= primes[index + 1] - n)) return primes[index];
        return primes[index + 1];
    }
}
