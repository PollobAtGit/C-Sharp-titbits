using System;

public enum Country
{
	BANGLADESH,
	UNITED_KINGDOM,
	UNITED_STATES_OF_AMERICA,
	INDIA,
	AUSTRALIA,
	BHUTAN,
	NEPAL,
	TUNISIA,
	ITALY,
	CZECH_REPUBLIC
}

public class Customer
{
	private string _name;
	private string _id;
	private bool _isPremiumUser;

	//Is properties private by default ? YES
	public string Name { get { return _name; } }
	public string ID { get { return _id; } }
	public bool IsPremiumUser { get { return _isPremiumUser; } }

	//static field members
	private static Country _country;

	//static properties
	public static Country CustomerCountry { get { return _country; } }//static properties can only access static field members
	

	public Customer() { _isPremiumUser = false; }

	//RULE #1: static constructor can't have access modifiers. In effect all static constructors are private. So none can instantiate it
	//RULE #2: static constructor has no relation with other non-staitc constructor, in terms of method overloading.
	//RULE #3: static constructors can't have any parameters. Which means, one class can have only one static constructor
	//APPARENTLY: static constructors are invoked even though there isn't any static memebers to initialize & it's done at the very beginning
	static Customer() { _country = Country.BANGLADESH; }

	//Following won't compile because of RULE #3
	//static Customer(string name = "NOT REGISTERED", string id = "UNDEFINED") { }

	public Customer(string msg) { ClientApp.Print(msg); }

	//Multiple constructors can't be invoked from another constructor using 'this'
	public Customer(string name = "NOT REGISTERED", string id = "UNDEFINED") : this ()
	{
		_name = name;
		_id = id;
	}

	public void PromoteAsPremiumUser()
	{
		//Additional logic goes here based on which premium-ness will be detected
		_isPremiumUser = true;
	}

	//static methods to access static member field
	public static void ChangeCustomerCountry(Country country)
	{
		_country = country; 
	}
}

public class ClientApp
{
	public static void Main()
	{
		Print("All customers are from " + Customer.CustomerCountry);
		Customer.ChangeCustomerCountry(Country.TUNISIA);
		Print("All customers are from " + Customer.CustomerCountry + "\n");

		var customer = new Customer();
		
		//Note the syntax
		ClientApp.Print("Name: " + customer.Name + " || ID: " + customer.ID + " || IsPremiumUser: " + customer.IsPremiumUser);

		customer = new Customer("Debasish Dada", "OKT56D");
		Print("Name: " + customer.Name + " || ID: " + customer.ID + " || IsPremiumUser: " + customer.IsPremiumUser);

		Print("Promoted");
		customer.PromoteAsPremiumUser();
		Print("Name: " + customer.Name + " || ID: " + customer.ID + " || IsPremiumUser: " + customer.IsPremiumUser);
	}

	public static void Print(string msg)
	{
		Console.WriteLine(msg);
	}
}
