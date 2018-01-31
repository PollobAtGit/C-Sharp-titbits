using System;

public class T
{
	private static Action<object> cl = (object x) => Console.WriteLine(x);

	public static void Main()
	{
		var addOne = new AddressOne("Address One", "Address Two", "Address Three", "12001");
		cl(addOne); // Address : Address One || Zip: 12001
		addOne.ChangeZip("000-899");
		cl(addOne); // Address : Address One || Zip: 000-899

		var addTwo = new AddressImmutable("A 1", "A 2", "A 3", "US-CA-BD");
		cl(addTwo); // Address One: A 1 || Address Two: A 2 || Address Three: A 3 || Zip: US-CA-BD
	}
}

public class AddressImmutable
{
	// Readonly setter. It can be initialized only in constructor. Direct initialization actually copies the initialization codes into constructor, so it's
	// the same as initialization via constructor
	private readonly string lOne;
	private readonly string lTwo;
	private readonly string lThree;
	private readonly string zip;

	// Getter
	public string LineOne => lOne;
	public string LineTwo => lTwo;
	public string LineThree => lThree;
	public string Zip => zip;

	public AddressImmutable(string lOne, string lTwo, string lThree, string zip)
	{
		this.lOne = lOne;
		this.lTwo = lTwo;
		this.lThree = lThree;
		this.zip = zip;
	}

	// POI: Accessing values via (public) getters. We could have used setters too to read value but they can't be used for setting values as they are
	// readonly
	public override string ToString() => $"Address One: { LineOne } || Address Two: { LineTwo } || Address Three: { LineThree } || Zip: { Zip }";
}

// POI: Using private setter is better than having public setter (unless required) 
// POI: But Internal code base can still modify the properties which is a risk factor
public class AddressOne
{
	public string LineOne { get; private set; }
	public string LineTwo { get; private set; }
	public string LineThree { get; private set; }

	public string Zip { get; private set; }

	public AddressOne(string lOne, string lTwo, string lThree, string zip)
	{
		LineOne = lOne;
		LineTwo = lTwo;
		LineThree = lThree;

		Zip = zip;
	}

	public void ChangeZip(string zip)
	{
		// POI: Zip has a private setter. So the setter can be accessed from internal code making the member not immutable
		Zip = zip;
	}

	public override string ToString() => $"Address : { LineOne } || Zip: { Zip }";
}

