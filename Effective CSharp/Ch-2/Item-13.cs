using System;

class T
{
	private static readonly Action<object> cl = (x) => Console.WriteLine(x);

	public static void Main()
	{
		// POI: Reflection doesn't invoke static constructor
		Type nType = typeof(M);

		cl("#1\n");

		// POI: Base static constructor is invoked first then derived
		// Static: M
		// Static: B
		var m = M.Instance;

		cl("#2\n");

		// POI: In this case a new instance of M will be created but
		// only instance constructor will be invoked but not static 
		// constructor because that has been invoked already
		var mm = M.Instance;

		cl("#3\n");
		// var s = M.ISingleton;
		
		// POI: Base class static constructor will be invoked only when
		// an instance of derived class is created. In other words only
		// when derived class's instance constructor is invoked which in
		// turn will invoke base class's instance constructor which by 
		// definition satisfies the condition for static constructor 
		// invocation
		var x = MM.X;

		cl("#4\n");
		
		// POI: Invocation order:
		// #1: Derived static ctor (if not invoked previously)
		// #2: Base static ctor (if not invoked previously)
		// #3: Base instance ctor
		// #4: Derived instance ctor
		var mi = new MM();

		// IMPORTANT: Derived static constructor doesn't invoke base 
		// static constructor 
		// IMPORTANT: There's no direct relation between derived & base
		// static constructor
		// IMPORTANT: For instance constructor base instance constructors 
		// are invoked first then derived instance constructors
	}
}

class MM : BB
{
	private static readonly Action<object> cl = (x) => Console.WriteLine(x);

	static MM()
	{
		cl("Static CTOR: MM");
	}

	// POI: Will invoke base class cosntructor even if not explicit
	public MM()
	{
		cl("Instance CTOR: MM");
	}

	internal static int X => 0;
}

class BB
{
	private static readonly Action<object> cl = (x) => Console.WriteLine(x);

	static BB()
	{
		cl("Static CTOR: BB");
	}

	internal BB()
	{
		cl("Instance CTOR: BB");
	}	
}

class M : B
{
	private static readonly Action<object> cl = (x) => Console.WriteLine(x);

	// private static readonly M _instance = new M();

	// POI: Will be invoked only when anything of M is accessed
	// POI: static constructor will be invoked once during the AppDomain 
	// life cycle
	static M()
	{
		cl("Static CTOR: M");
	}

	// POI: Singleton makes sense only when constructors are private &
	// constructors are provided explicitly because otherwise public default
	// parameterless constructor is provided
	M() 
	{ 
		cl("Instance CTOR: M");
	}

	// POI: Instance creation will invoke instance constructor multiple times
	// but static constructor will be invoked only & only once
	internal static M Instance => new M();

	// internal static M ISingleton => _instance;
}

class B
{
	private static readonly Action<object> cl = (x) => Console.WriteLine(x);

	// POI: Will only be invoked when anything related to B will be accessed
	static B()
	{
		cl("Static CTOR: B");
	}
}
