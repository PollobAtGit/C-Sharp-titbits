class AOne
{
	public virtual int Ret() => 10;
}

class ATwo : AOne
{
	public override int Ret() => 20;
}

class AThree : ATwo
{
	public override int Ret() => 30;
}

class AFour : AThree
{
	// public override int Ret() => 40;
	public new int Ret() => 40;
}

// POI: Left side of the assignment matters in case of polymorphism
AOne a = new AFour();
ATwo b = new AFour();
AThree c = new AFour();
AFour d = new AFour();

Action<object> cl = (object x) => Console.WriteLine(x);

/*
	//Override
	cl(a.Ret());// 40
	cl(b.Ret());// 40
	cl(c.Ret());// 40
*/

// new
cl(a.Ret());// 30
cl(b.Ret());// 30
cl(c.Ret());// 30
cl(d.Ret());// 40
