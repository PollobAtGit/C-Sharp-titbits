using System;
using System.Collections.Generic;

static class T
{
	public static void Main()
	{
		var o = new D();
		o.Bar(new D2());// D.Bar

		B oB = new D();

		// POI: Which overload will be invoked is determined in compilation time (based on compilation Type) not on runtime
		oB.Bar(new D2());// B.Bar

		var seq = new List<D2>();

		// POI: Interesting! D.FooTwo(...) is a candidate for overload resolution because C# 4.0 & later versions support generics covariance &
		// contravariance before that generics was invariant which means in that case D.FooTwo(...) is not a candidate for overload resolution
		o.FooTwo(seq);// D.FooTwo

		o.Foo(new D2());// D.Foo
		o.Foo(new B2());// D.Foo
	}
}

class B2 { }
class D2 : B2 { }

class B
{
	internal void Foo(D2 p) { Console.WriteLine("B.Foo"); }

	internal void Bar(B2 p) { Console.WriteLine("B.Bar"); }

	internal void FooTwo(IEnumerable<D2> p) { Console.WriteLine("B.FooTwo"); }
}

class D : B
{
	internal void Foo(B2 p) { Console.WriteLine("D.Foo"); }

	internal void Bar(B2 pOne, B2 pTwo = null) { Console.WriteLine("D.Bar"); }

	internal void FooTwo(IEnumerable<B2> p) { Console.WriteLine("D.FooTwo"); }
}

