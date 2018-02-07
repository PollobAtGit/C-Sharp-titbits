using System;

class T
{
	public static void Main()
	{
		// POI: Reflection doesn't invoke static constructor
		Type nType = typeof(M);

		// POI: Base static constructor is invoked first then derived
		// Static: M
		// Static: B
		var m = M.Instance;
		var mm = M.Instance;
	}
}

class M : B
{
	private static readonly Action<object> cl = (x) => Console.WriteLine(x);

	// private static readonly M _instance = new M();

	// POI: Will be invoked only when anything of M is accessed
	static M()
	{
		cl("Static: M");
	}

	// POI: Singleton makes sense only when constructors are private &
	// constructors are provided explicitly because otherwise public default
	// parameterless constructor is provided
	M() { }

	internal static M Instance => new M();
}

class B
{
	private static readonly Action<object> cl = (x) => Console.WriteLine(x);

	// POI: Will only be invoked when anything related to B will be accessed
	static B()
	{
		cl("Static: B");
	}
}
