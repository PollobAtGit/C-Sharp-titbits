using System;
using System.Collections.Generic;

class T
{
	static readonly Action<object> cl = (object x) => Console.WriteLine(x);

	public static void Main()
	{
		var lI = new GenT<int>();// Int32 => Is Gneric: False
		var lT = new GenT<Type>();// Type => Is Gneric: False
		var lL = new GenT<List<double>>();// List`1 => Is Gneric: True

		cl(lI.GetType() + " => Is Gneric: " + lI.GetType().IsGenericType);// GenT`1[System.Int32] => Is Gneric: True
		cl(lT.GetType() + " => Is Gneric: " + lT.GetType().IsGenericType);// GenT`1[System.Type] => Is Gneric: True
		cl(lL.GetType() + " => Is Gneric: " + lL.GetType().IsGenericType);// GenT`1[System.Collections.Generic.List`1[System.Double]] => Is Gneric: True
	}
}

class GenT<T>
{
	public GenT()
	{
		// POI: typeof(...) can be used directly on Type name rather than on instance. typeof(...) compile time but ...GetType() is runtime
		// POI: Levaraging typeof(...) is actually using reflection
		// POI: T is the generic type parameter
		var genType = typeof(T);

		Console.WriteLine(genType.Name + " => Is Gneric: " + genType.IsGenericType);
	}
}

