using System;

class T
{
	public static void Main()
	{
		var o = new D();

		// POI: Better match for this overload is B.Foo(D2...) but that's not invoked because lookup starts from the derived class
		// Only when a match is not found base class is looked for matching.
		// POI: In this case, a matching (albeit not the best matching) is found in the derived class so control doesn't look into 
		// the base class
		o.Foo(new D2());// D.Foo
		o.Foo(new B2());// D.Foo

		B aO = new D();

		// POI: Overload resolution occurs on compile time Type checking not on run time Type checking that's why D.Foo will not be invoked
		aO.Foo(new D2());// B.Foo
	}
}

class B2 { }
class D2 : B2 { }

class B
{
	public void Foo(D2 p)
	{
		Console.WriteLine("B.Foo");
	}
}

class D : B
{
	public void Foo(B2 p)
	{
		Console.WriteLine("D.Foo");
	}
}

