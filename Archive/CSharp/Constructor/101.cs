
// TA:
//      1) Static constructors are invoked ONCE AND ONCE ONLY & it is onvoked
//          the first time anything related to the class occurs
// USE-CASE:
//          1) Some operation need to be done once & once only for a given object
//          2) Initialize static members

using System;

public class Test
{
	private static int _i = 10;

	// POI: static constructors are invoked only & only once
	static Test()
	{
		Console.WriteLine("From Ctor: Hello !");
	}
	
	public static void Main()
	{
		// POI: static constructors are invoked once in life time. So following two 
		// statements combinedly will invoke the defined static constructor once
		//new Test();
		//new Test();
		
		// POI: Static constructors will be invoked when any static members of that class 
		// is being referenced even if no instance has been created
		//Console.WriteLine(Test._i);
		
		// POI: Interesting enough even just referencing the static member is enough to 
		// invoke the static constructor
		Console.WriteLine(_i);

        // POI: This object creation doesn't invoke the static constructors
        new A().F();
	}
}

internal class A
{
    internal void F()
    {
        new Test();
    }
}