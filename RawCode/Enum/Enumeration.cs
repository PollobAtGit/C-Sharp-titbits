using System;

//Which namespace is this? How check namespace dynamically
public class ClientApp
{
	public static void Main()
	{
		//Note that this invocation executes the static constructor
		//OUTOUT: App.Model.UserSession+Client
		//OUTOUT: DESKTOP_BROWSER
		Utility.Print(App.Model.Token.ClientApp.GetType());

		//Also note that this invocation executes the non-static default constructor that is provided by compiler
		//Implication: If a non-staic constructor is defined then compiler doesn't provide anymore constructor
		//But even if static constructors are defined but no non-static constructor is defined then compiler
		//will provide the default parameterless constructor. So compiler considers static constructor as a
		//totally different construct
		new App.Model.Token();//OUTOUT: 
	}
}

public static class Utility { public static void Print(object msg) { Console.WriteLine(msg.ToString()); } }

namespace App.Model
{
	//Elements defined in namespace can't be explicitly specified as private/protected/protected internal.
	//What's the impact? What defines 'element'?
	public enum AuthState { AUTHORIZED, UNAUTHORIZED }

	public class UserSession
	{
		//private enum should be useful
		private enum State { ACTIVE, INACTIVE }
		
		public enum SessionValidity { VALID, INVALID, PENDING_STATUS }

		public enum Client { DESKTOP_BROWSER, MOBILE, WEB_SERVICE }
	}

	public class Token
	{
		private static UserSession.Client _clientApp = UserSession.Client.DESKTOP_BROWSER;

		//Assigning null to this variable will throw build error 'CS0169'.Because enum variables are non-nullable values
		private static UserSession.Client _clientAppOriginal;

		//var can only be used in local variable declaration
		public static dynamic ClientApp { get { return _clientApp; } }
		static Token()
		{
			//Following will throw 'error CS0103: The name 'State' does not exist in the current context' cause enum isn't visible
			//var sessionState = State.INACTIVE;

			//SessionValidity isn't accessible also because this enumeration is defined in another class. But then why allow 'public' enum?
			//=> See the assignment of '_clientApp' as an usage of public enum
			//var sessionValidityStatus = SessionValidity.PENDING_STATUS;
		
			//Joss! Note the usage.
			//Defined enums are static internally. Also note the default assignment operation for this member field
			_clientApp = UserSession.Client.WEB_SERVICE;

			//AuthState enumerations are available as enumeration is the first child of namespace
			var userAuthorizationStatus = AuthState.AUTHORIZED;

			//Checking default value of enum type variables
			Utility.Print("Default client app value: " + _clientAppOriginal.ToString());
		}
	}
}



