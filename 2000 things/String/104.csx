
Action<object> cl = (object x) => Console.WriteLine(x);

/*#479 – Identical String Literals Are Stored in the Same Object */

var s = "people";
var st = "people";
var strr = "diff";

cl(s == st);// True
cl(s.Equals(st));// True

// POI: Apparently, underlying referenced object is the same in terms of reference !!
cl(string.ReferenceEquals(s, st));// True

// POI: Underlying referenced object for string with same value is same
cl(string.ReferenceEquals("diff", "diff"));// True
cl(string.ReferenceEquals("𠈓", "𠈓"));// True

cl("With StringBuilder: " + string.ReferenceEquals("diff", new StringBuilder("diff").ToString()));

cl(string.Equals("diff", new StringBuilder("diff").ToString()));// True
cl("diff" == new StringBuilder("diff").ToString());// True

class A { public override string ToString() => "diff"; }

cl("With A: " + string.ReferenceEquals("diff", new A().ToString()));// True

var input = Console.ReadLine();
cl(input);
cl("With Input: " + string.ReferenceEquals("diff", input));// False
cl(string.Equals("diff", input));// True

// POI: Apparently, C# CLR uses same object for strings with same value but that depends. This statement is not true for StringBuilder or
// with strings for which value is generated in runtime. So it's better to use string.Equals(..., ...) or '==' which is implemented to use
// string.Equals(..., ...)
