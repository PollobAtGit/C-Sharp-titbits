
using System.Text.RegularExpressions;

Action<object> cl = (object x) => Console.WriteLine(x);

/*#970 – Checking for Valid Characters in a String */

cl(Regex.IsMatch("^[0-9]$", "123"));// False
cl(Regex.IsMatch("[0-9]+", "123.23"));// False

var r = new Regex("^[0-9]+$");

// TODO: Why difference between static method & instance method
cl(r.IsMatch("8"));// True
cl(Regex.IsMatch("^[0-9]+$", "8"));// False
