using System;
using System.Linq;

internal static class T
{
	public static void Main()
	{
		var t = Console.ReadLine();

		var bO = JudgeCircle(t);

		Console.WriteLine(bO);
	}

  static bool JudgeCircle(string moves) 
	{
		var u = moves.Where(x => x == 'U').Count();
		var d = moves.Where(x => x == 'D').Count();
		var l = moves.Where(x => x == 'L').Count();
		var r = moves.Where(x => x == 'R').Count();

		return u == d && l == r;
	}
}
