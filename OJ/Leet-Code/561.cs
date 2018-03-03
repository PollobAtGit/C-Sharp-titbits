using System;
using System.Linq;

internal static class T
{
	static int ArrayPairSum(int[] nums) 
	{
		if(!nums.Any()) throw new Exception("nums contain no values");

		var o = nums.OrderBy(x => x);

		if(o.Count() == 2) return o.First();

		return o.First() + o.Skip(o.Count() - 2).First();
	}

	public static void Main()
	{
		var a = Array.ConvertAll(Console.ReadLine().Split(' '), x => int.Parse(x));

		Console.WriteLine(ArrayPairSum(a));
	}
}
