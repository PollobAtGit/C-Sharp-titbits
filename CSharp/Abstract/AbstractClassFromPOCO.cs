using System;

namespace Client { public static class Utility { public static void Print(string msg) { Console.WriteLine(msg); } } }

namespace Client.App 
{ 
	public class Client 
	{ 
		public static void Main() 
		{ 
			Utility.Print(new POCO.Model.WebStorm().ReleaseYear()); 
			//Utility.Print(new POCO.Model.Benson().Burn());
			//Utility.Print(POCO.Model.Marlboro.Burn());
		}
       	} 
}

namespace POCO.Model
{
	//Can a regular class be inherited by an abstract class
	public class VisualStudio { public string ReleaseYear() { return "2015"; } }
	public abstract class IDE : VisualStudio { }//Making a regular class inherited by an abstract class
	public class WebStorm : IDE { }

	/*
	//Can a static class be inherited? If so can it be both static and non-static?
	public class Biri {  }
	public static class Cigarette { public static string Burn() {  return "Burn! Burn!!"; } }
	public class Benson : Cigarette { } //CS0709 => Static classes can't be inherited from or instantiated
	public static class Marlboro : Cigarette { } // CS0713
	public static class AkijBiri : Biri { } // CS0713 => static class can't derive from type ... Static class must derive from object (which is default behavior)
	*/
}
