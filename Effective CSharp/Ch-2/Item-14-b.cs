using System;

class T
{
	public static void Main()
	{

	}
}

class TB
{
	private readonly int _x;
	private readonly byte _y;

	// POI: Not having a parameterless constructor can be problamatic for 
	// client because client will be forced to defined constructor even 
	// if that's parameterless
	protected TB(int x) { _x = x; }

	protected TB(byte y) { _y = y; }
}

// POI: This statement will not compile because 
// 1# TB has a constructor that overrides the default parameterless constructor
// 2# TD doesn't invoke that constructor though explicitly/implicitly. Base class
// constructor must be invoked by derived class
// 3# In this instance compiler is trying to detect if it can create base class 
// via derived class using the default parameterless constructor of TD

// class TD : TB { }

// POI: TB doesn't have a parameterless constructor which means TD is bound to define a explicit constructor which have to invoke the base constructor with param  
class TD : TB 
{
	// POI: Client is forced to define a constructor which can be undesirable
	TD() : base(0) { }

	// POI: Constructor initialization only works if construction is delegated
	// to another constructor of this Type (via this()) or to a base Type 
	// constructor
	// POI: Both this() & base() is not allowed
	// POI: Constructor initialization chaining works only for a single 
	// constructor

	// TD(int x) : this(), base(0) { }
	// TD(byte y) : this(0), this() { }

	TD(int x) : this() { }
}


