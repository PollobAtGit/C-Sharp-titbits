using System;
using System.Linq;
using System.Collections.Generic;

internal class TT
{
	// COMPLEXITY: O(n) n => numbers in [L, R]
	// Number of digits in a number upper-n = floor(log10(n)) + 1
	// Total comlexity: O(n upper-n)
	static IList<int> SelfDividingNumbersBetter(int left, int right)
	{
		var nums = new List<int>();

		for(int i = left; i <= right; i++)
		{
			if(i.ToString().Select(x => x - 48).All(x => x != 0 && i % x == 0))
				nums.Add(i);
		}
		
		return nums;
	}

	// COMPLEXITY: O(n) where n is count in [L, R]
	static IList<int> SelfDividingNumbers(int left, int right) 
	{
		var nums = new List<int>();

		for(int i = left; i <= right; i++)

			// Caution: Dividing by x which is a digit from a number so it can be zero which means possibility for DivideByZero
			if(GetDigits(i).All(x => x != 0 && i % x == 0)) 
				nums.Add(i);

		return nums;
	}

	static IList<int> GetDigits(int i)
	{
		var ds = new List<int>();

		while(i != 0)
		{
			ds.Add(i % 10);
			i = i / 10;
		}

		return ds;
	}

	public static void Main()
	{
		var nl = int.Parse(Console.ReadLine());
		var nr = int.Parse(Console.ReadLine());

		var nums = SelfDividingNumbersBetter(nl, nr);

		Console.WriteLine(string.Join(" ", nums));
	}
}
