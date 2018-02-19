using System;

internal class T
{
	public static void Main()
	{
		// POI: Converting Note Type to double
		double dn = new Note(10);// 31.....

		Console.WriteLine(dn);

		// POI: dn is double but can be implicitly converted to Note Type
		Note n = dn;

		Console.WriteLine(n.Value);
	}
}

internal class Note
{
	// POI: Members can be 'internal'
	
	internal int Value { get; private set; }

	internal Note(int x)
	{
		Value = x;
	}

	// POI: Expressing the intent that any 'Note' can be converted to double even though these Types has nothing in common
	public static implicit operator double (Note n) => (double)n.Value * Math.PI;

	// POI: Allowing implicit conversion from double to Note Type
	public static implicit operator Note(double n) => new Note((int)Math.Pow(2, n / 15));
}

