using System;
using System.Collections.Generic;

internal static class T
{
	internal static void Main()
	{
		// POI: Can convert derived class to base class List
		var seqD = new List<D> { new D(), new B(), new C() };
	}
}

class D { }
class B : D { }
class C : B { }
