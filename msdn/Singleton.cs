using System;
using System.Threading.Tasks;

internal static class TS
{
	public static void Main()
	{
		// POI: Without lock there's a race condition between two threads so two initial hash codes that are different from each other
		// But after that dependency has been resolved the last created object is being server
		// 30015890
		// 4032828
		// 4032828
		// 4032828
		// 4032828

		Parallel.Invoke(
				() => { Console.WriteLine(D.Instance.GetHashCode()); }, // WL: 30015890
				() => { Console.WriteLine(D.Instance.GetHashCode()); },  // WL: 63835064
				() => { Console.WriteLine(D.Instance.GetHashCode()); }, // WL: 30015890
				() => { Console.WriteLine(D.Instance.GetHashCode()); }, // WL: 30015890
				() => { Console.WriteLine(D.Instance.GetHashCode()); } // WL: 30015890
			       );

		Console.WriteLine();

		// POI: GetHashCode() is unique for each object
		Console.WriteLine(new F().GetHashCode());
		Console.WriteLine(new F().GetHashCode());
	}

	private class F { }
}

internal class AA
{
	// POI: private constructor ensures no other Type can inherit from this Type unless that's a nested Type inside A
	// POI: private constructor can ensure only static method & properties can be accessed if singleton is not provided
	private AA() { }

	// POI: C can inherit from A even though A has one private constructor because C is inside A's scope so it has access to all private members of A
	private class C : AA
	{
		private void M()
		{
			// POI: private constructor doesn't even prevent object creation inside that Type's scope
			new A();
		}
	}
}

/*
	internal class B : A
	{
		// POI: A has private constructor which means B can't invoke any base constructors which breaks inheritence hierarchy in terms of object creation
	}
*/

internal sealed class D
{
	// POI: Ensures object creation using 'new' is not allowed unless it's done in this Type's scope
	// POI: private constructor only diallows derived Type creation if the Type is being derived outside this Type's scope
	private D() { }

	// POI: D is sealed. D is not derivable anywhere not even in the scope of the Type itself
	// private class E : D { }

	private static D _instance;
	private static object _lock = new object();

	public static D Instance
	{
		get
		{
			// POI: Double locking mechanism
			if(_instance == null)
			{
				lock(_lock)
				{
					if(_instance == null)
						_instance = new D();
				}
			}
			return _instance;
		}
	}
}

