using System;
using System.Linq;

internal static class T
{
	static int NumJewelsInStones(string J, string S)
	{
		var grp = S
			.GroupBy(x => x, (k, g) => new { K = k, C = g.ToList().Count() })
			.ToList();

		// problem with Single
		return J.Select(x => grp.Single(y => x == y.K).C).Sum();
	}

	static int NumJewelsInStones_two(string J, string S)
	{
		var count = 0;

		foreach(var i in J)
			foreach(var j in S)
				if(i == j) count++;

		return count;
	}

	static int NumJewelsInStones_three(string J, string S)
	{
		var count = 0;

		for(var i = 0; i < J.Length; i++)
			for(var j = 0; j < S.Length; j++)
				if(J[i] == S[j]) count++;

		return count;
	}

	public static void Main()
	{
		var j = Console.ReadLine();
		var s = Console.ReadLine();

		// var c = NumJewelsInStones(j, s);

		// Console.WriteLine(c);
		Console.WriteLine(NumJewelsInStones_two(j, s));
		Console.WriteLine(NumJewelsInStones_three(j, s));
	}
}
