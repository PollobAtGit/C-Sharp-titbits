using System;
using System.Linq;
using System.Reflection;

class T
{
	private static Action<object> cl = (object x) => Console.WriteLine(x);

	public static void Main()
	{
		var t = typeof(A);

		var props = t.GetProperties();

		// System.Nullable`1[System.Int32] X
		// Int32 Y
		// B B
		props.ToList().ForEach(x => cl(x));

		cl(null);
		cl(t.GetProperty("X"));
		cl(t.GetProperty("Y"));
		cl(t.GetProperty("B"));

		// TODO: Not working
		cl(t.GetProperty("b", BindingFlags.IgnoreCase | BindingFlags.Default));
	}
}

class A
{
	public int? X { get; set; }
	public int Y { get; set; }

	public B B { get; set; }
}

class B { }
