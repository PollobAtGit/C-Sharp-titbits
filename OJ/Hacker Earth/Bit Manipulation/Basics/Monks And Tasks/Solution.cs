using System;
using System.Linq;

internal static class T
{
	public static void Main()
	{
		var t = int.Parse(Console.ReadLine());

		while(--t >= 0)
		{
			Console.ReadLine();

			var a = Array.ConvertAll(Console.ReadLine().Split(' '), x => int.Parse(x));
			var b = new Container[a.Length];

			for(int i = 0; i < a.Length; i++)
				b[i] = new Container { N = a[i], C = CountOnes(a[i]) };

			var aB = b.OrderBy(x => x.C).Select(x => x.N);

			Console.WriteLine(string.Join(" ", aB));
		}
	}

	private static int CountOnes(int i)
	{
		var c = 0;

		while(i > 0)
		{
			if((i & 1) == 1) c++;
			i = i >> 1;
		}

		return c;
	}

	private class Container
	{
		public int N { get; set; }
		public int C { get; set; }
	}
}
