using System;

class X
{
	public static void Main()
	{

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
