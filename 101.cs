using System;

class Program
{
	public static void Main()
	{
		var h = new Human();

		new T().S(h);// Animal
		new TT().S(h);// Mamal
	}
}

class TBase
{
	protected Action<object> cl = (object x) => Console.WriteLine(x);

	public void S(Mamal a) { cl("MAMAL"); }
}

class T : TBase
{

	public void S(Animal a) { cl("ANIMAL"); }
}

class TT
{
	protected Action<object> cl = (object x) => Console.WriteLine(x);

	public void S(Animal a) { cl("ANIMAL"); }
	public void S(Mamal a) { cl("MAMAL"); }
}

class Animal { }
class Mamal : Animal { }
class Human : Mamal { }
