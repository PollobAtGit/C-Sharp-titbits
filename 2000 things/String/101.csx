
using System.Globalization;

Action<object> cl = (object x) => Console.WriteLine(x);

// POI: It's expression body so semi-colon is required at the end of the statement
Action<object> cln = (object x) => { Console.WriteLine(); Console.WriteLine(x); };

/* #1,116 – Iterating Through a String Using the foreach/ToList().ForEach() Statement */

var str = "string";

var strBuildr = new StringBuilder();

// POI: Prepend to string builder
// POI: ToList().ForEach() is a good alternative to foreach statement
// POI: String reverse
str.ToList().ForEach(s => strBuildr.Insert(0, s));

cl(strBuildr);// gnirts

/* #1,011 – TryParse Indicates Whether a Parse Operation Will Succeed */

decimal n;
cln(Decimal.TryParse("12.3d", out n));// False
cl(Decimal.TryParse(null, out n));// False

// POI: 'm' as suffix is only allowed in numeric decimal numbers not in their number representation
cl(Decimal.TryParse("0.0m", out n));// False

cl(Decimal.TryParse("-0.23", NumberStyles.None, new CultureInfo("en-US"), out n));// False
cl(Decimal.TryParse("-0.23",

    // POI: Only allowing negative sign & decimal point
    // POI: Allowing decimal point also
    NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint,
    new CultureInfo("en-US"),
    out n));// True

cl(Decimal.TryParse("+23", out n));// True

// POI: NumberStyles.None indicates only digits are allowed
cl(Decimal.TryParse("+23", NumberStyles.None, new CultureInfo("en-US"), out n));// False
cl(Decimal.TryParse("23.23", NumberStyles.None, new CultureInfo("en-US"), out n));// False

// POI: NumberStyles.None is the base point for styles upon which we can apply other styles one by one
cl(Decimal.TryParse("23.23", NumberStyles.None | NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"), out n));// True


// POI: m is applied only for numeric values. It's not emitted in it's string representation
cl(23.056m.ToString());// 23.056

// Idiomatic approach

double nd;

// Parsed Value: 0.23
if (Double.TryParse("0.23", out nd)) { cln($"Parsed Value: {nd}"); }
else { cl($"String can't be parsed to double"); }

/*#1,010 – Checking to See Whether a String is Null or Empty */

// POI: string.IsNullOrEmpty() checks for nullability & checks if string is empty. It doesn't perform Trim()
// of any sort & don't consider whitespaces as empty string

cln(string.IsNullOrEmpty(""));// True
cl(string.IsNullOrEmpty("   "));// False
cl(string.IsNullOrEmpty(" "));// False
cl(string.IsNullOrEmpty(null));// True
