using System;
using System.Collections.Generic;

class X
{
	public static void Main()
	{
		TOne.Execute();
	}
}

class T
{
	private readonly int _x;
	private readonly int _y;

	// POI: Client sees the following constructors
	// POI: Delegating object creation to one (!) constructor is desirable
	// because generated IL is optimized
	public T() : this(0, 0) { }
	public T(int x) : this(x, 0) { }
	public T(byte y) : this(0, y) { }


	// POI: This constructor is private just to prove the point that even 
	// having a private constructor is worth having when that faciliates
	// reducing duplication
	private T(int x, int y)
	{
		_x = x;
		_y = y;
	}
}

class TAnother
{
	private readonly int _x;
	private readonly int _y;

	// POI: Lots of initialization duplication. So compiler can't optimize the
	// initialization
	// POI: Also not readable
	public TAnother()
	{
		_x = 0;
		_y = 0;
	}

	public TAnother(int x)
	{
		_x = x;
		_y = 0;
	}

	public TAnother(byte y)
	{
		_x = 0;
		_y = y;
	}

	private TAnother(int x, int y)
	{
		_x = x;
		_y = y;
	}
}

class TOne
{
	private readonly static Action<object> cl = 
		(object x) => Console.WriteLine(x);

	private readonly int _x;
	private readonly int _y;

	// POI: Levaraging default parameter
	// POI: This better in the sense that we get a default constructor by 
	// definition
	public TOne(int x = -1, int y = -1)
	{
		_x = x;
		_y = y;
	}

	public override string ToString() => $"X: {_x} => Y: {_y}";

	internal static void Execute()
	{
		var t = new TOne();// -1, -1
		var tOne = new TOne(10);// 10, -1
		var tTwo = new TOne(100, 200);// 100, 200

		cl(t);// X: -1 => Y: -1
		cl(tOne);// X: 10 => Y: -1
		cl(tTwo);// X: 100 => Y: 200

		// POI: This property initialization will invoke default 
		// constructor
		// POI: Property initialzation works properly whe constructor 
		// overload is implemented via default parameters
		new TOne { };

		// POI: error CS0310: 'TOne' must be a 
		// non-abstract type 
		// with a public parameterless constructor
		
		// POI: Default/parameterless constructor that is generated 
		// by levaraging default arguments/parameters is enough for 
		// compiler to allow property initialization syntax but that's
		// not enough for generic methods which requires 'new ()'
		
		// POI: To be qualified to be used in a generic method that uses
		// 'new ()' the Type must have a parameterless default constructor

		// ExecuteGeneric<TOne>();
	}

	internal static void ExecuteGeneric<T>() where T : new() { }
}

class TT
{
	private readonly int _x;

	public TT(int x)
	{
		_x = x;
	}

	private static void Execute()
	{
		var t = new List<TT>();
	}
}

class TTT
{
	public int X { get; set; }

	// POI: A default parameter is mandatory when we want to use property 
	// initialization
	public TTT() : this(0) { }

	public TTT(int x)
	{
		X = x;
	}

	private static void Execute()
	{
		// POI: Property initialization works only when default constructor
		// is provided
		// POI: In other words, in property initialization default 
		// constructor is executed
		new TTT
		{
			X = 10
		};

		// POI: Property initializer can be used without initializing any
		// property
		new TTT { };

		// POI: Valid because the Type has a default parameterless 
		// constructor
		ExecuteGeneric<TTT>();
	}

	private static void ExecuteGeneric<T>() where T : new () { }

}

