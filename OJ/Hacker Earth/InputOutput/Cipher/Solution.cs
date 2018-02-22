using System;
using System.Text;

internal static class T
{
	public static void Main()
	{
		var s = Console.ReadLine();
		var k = int.Parse(Console.ReadLine());

		var sb = new StringBuilder();

		for(int i = 0; i < s.Length; i++)
			sb.Append((char)GenerateCipheredChar(s[i], k));

		Console.WriteLine(sb.ToString());
	}

	private static int GenerateCipheredChar(char c, int k)
	{
		if(!Char.IsLetterOrDigit(c)) return c;

		var b = GetBase(c);

		var n = Char.IsDigit(c) ? 10 : 26;

		var ch = (int)c;

		if(((ch - b) + k) % n == 0) return b + n;
		return (((ch - b) + k) % n) + b;
	}

	private static int GetBase(char ch)
	{
		if(Char.IsDigit(ch)) return 47;
		if(Char.IsLetter(ch) && Char.IsUpper(ch)) return 64;
		return 96;
	}
}
