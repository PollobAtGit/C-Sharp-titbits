using System;
using System.Linq;

internal static class T
{
	public static void Main()
	{
		Console.ReadLine();

		var a = Array.ConvertAll(Console.ReadLine().Split(' '), x => int.Parse(x));

		var sa = a.OrderBy(x => x);

		Console.WriteLine(OddFreq(sa.ToArray()));
	}

	static int OddFreq(int[] a)
	{
		for(int i = 0; i < a.Length; )
		{
			var c = 1;
			while( i < (a.Length - 1) && a[i] == a[i+1])
			{
				c++;
				i++;
			}

			if((c & 1) == 1) return a[i];
			i++;
		}

		return -1;
	}
}
