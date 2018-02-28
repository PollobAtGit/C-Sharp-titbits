using System;
using System.Linq;

internal static class T
{
	static int NumJewelsInStones(string J, string S)
	{
		return J.Select(x => S.Where(y => x == y).Count()).Sum();
    	}

	public static void Main()
	{
		var j = Console.ReadLine();
		var s = Console.ReadLine();

		var c = NumJewelsInStones(j, s);

		Console.WriteLine(c);
	}
}
