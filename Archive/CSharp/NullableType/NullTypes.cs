using System;

using Poco;

namespace Client
{
	public static class ClientApp 
	{ 
		public static void Main() 
		{
		      	Console.WriteLine(Nullable.Int.NullableInt.Test(23)); 

			var retValue = Nullable.Int.NullableInt.Test(null);
			Console.WriteLine(string.IsNullOrWhiteSpace(retValue) ? "EMPTY" : retValue);//ToString() on null values return EMPTY 

			//Console.WriteLine(typeof(null));//Compilation error
			//Console.WriteLine(null.ToString());//compilation error

			Customer customer = new Customer();;
			Console.WriteLine(customer.ToString());

			customer = null;
			//Console.WriteLine(customer.ToString());//Throws RTE as customer is NULL. Then why Line#14 displays EMPTY
		} 
	}
}

namespace Nullable.Int { public static class NullableInt { public static string Test(int? intVal) { return intVal.ToString(); }	} }

namespace Poco { public class Customer { } }
