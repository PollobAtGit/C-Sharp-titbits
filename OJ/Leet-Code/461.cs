using System;

internal static class T
{
  static int HammingDistance(int x, int y) 
	{
		var diff = x ^ y;
		var c = 0;

		while(diff > 0) 
		{
			if((diff & 1) == 1) c++;
			diff = diff >> 1;
		}

		return c;
       	}

	public static void Main()
	{
		var x = int.Parse(Console.ReadLine());
		var y = int.Parse(Console.ReadLine());

		var c = HammingDistance(x, y);

		Console.WriteLine(c);
	}
}
