using System;
using System.Linq;
using System.Collections.Generic;

// TODO: All important question, why is boxing/unboxing occuring for generic list? Or is it simply they return a different object?

class T
{
	private static readonly Action<object> cl = (object x) => Console.WriteLine(x);

	public static void Main()
	{
		// POI: Default constructor will be invoked by default
		var l = new List<Person> { new Person() { Name = "X" } };
		var lA = new List<Animal> { new Animal { Name = "X" } };

		var fPerson = l.First();
		var fAnimal = lA.First();

		fPerson.Name = "Y";
	        fAnimal.Name = "Y";

		// POI: Boxing is bad bad bad. Possibility for subtle bug

		// POI: Internal value didn't change in this case because when returning the first element unboxing is done (because Person is a value type/struct)
		// which in turn means a new object is being created. So any change to that instance will change that instance but will not impact the original 
		// object instance in the List
		cl(l.First().Name);// X

		// POI: Internal value did change because the returned value was an object that references the original object which means any change to that object
		// will change the original object referenced in the list
		cl(lA.First().Name);// Y

		var aP = new Person { Name = "xX" };

		l.Add(aP);

		// POI: Original object & the internal object & also the returned object are not same in terms of reference. Internal objects referenced
		// by list are boxed values
		cl(object.ReferenceEquals(aP, l.Last()));// False

		var aA = new Animal { Name = "yY" };

		lA.Add(aA);

		// POI: The original object, the internal object & the returned object all references the same object because Animal is of reference Type
		cl(object.ReferenceEquals(aA, lA.Last()));// True

		// POI: This assignment doesn't nullify the object in the list because that internal object (variable) 
		aA = null;
		cl(lA.Last().Name);// yY

		M();
	}

	private static void M()
	{
		cl("");

		var p = new Person { Name = "X" };
		var a = new Animal { Name = "X" };

		var ps = new Person[] { p };
		var ns = new Animal[] { a };

		var fPs = ps.First();
		var fNs = ns.First();

		fPs.Name = "Y";
		fNs.Name = "Y";

		cl(ps.First().Name);// X
		cl(ns.First().Name);// Y

		// POI: Why are value types being boxed in arrays? Or is it simply they return a different object?
		cl(object.ReferenceEquals(p, fPs));// False
		cl(object.ReferenceEquals(a, fNs));// True
	}


	private struct Person
	{
		public string Name { get; set; }
	}

	private class Animal
	{
		public string Name { get; set; }
	}
}
