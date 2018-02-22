using System;
using System.Linq;
using System.Collections.Generic;

internal static class T
{
	public static void Main()
	{
		// POI: Asking compiler to infer type from given values which are anonymous in this case
		var l = new []
		{ 
			new { a = 0, b = 20 },
			new { a = 30, b = 40 }
		};

		var lO = new object[]
		{
			new { a = 20 },
		        new { a = 30 }
		};

		// POI: Here x is object not anonymous type. So x.a is not defined here
		// POI: Can't use Cast<T>(...)/TypeOf<T>(...) because the Type is anonymous so not defined
		// POI: Passed dummy value must of same Type in terms of the shape of the object

		Console.WriteLine(string.Join(" ", lO.Select(x => x.CastTo(new { a = 0 }))));
	}

	// POI: 2nd Argument to make compiler determine type of the anonymous object. Note it's a generic method so T will be determined by getting an anonymous object
	private static T CastTo<T>(this object o, T d) => (T)o;
}
