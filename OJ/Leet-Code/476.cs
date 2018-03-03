using System;
using System.Linq;

internal static class T
{
	static int FindComplement(int num)
	{
		var b = GetBinaryRepresentation(num);
		var c = ComplementBinary(b);

		return ConvertToInt(c);
  }

	static int ConvertToInt(string s)
	{
		int k = 0;
		var sr = new string(s.ToCharArray().Reverse().ToArray());

		for(int i = 0;i < sr.Length; i++)
		{
			k = k + ((sr[i] - 48) * (int)Math.Pow(2, i));
		}

		return k;
	}

	static string ComplementBinary(string b) => new string(b.ToList().Select(x => x == '0' ? '1' : '0').ToArray());

	static string GetBinaryRepresentation(int n)
	{
		var s = string.Empty;

		while(n != 0)
		{
			s = ((n & 1) == 1 ? "1" : "0") + s;
			n = n >> 1;
		}

		return s;
	}

	public static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		
		Console.WriteLine(FindComplement(n));
	}
}
