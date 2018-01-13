
using System.Globalization;

Action<object> cl = (object x) => Console.WriteLine(x);

/*#1,007 – Getting Length of String that Contains Surrogate Pairs */

var containsSurrogatePair = "A𠈓C";

// POI: string.Length instance member works fine for characters that can be represented in BMP (basic multilingual plane)
cl(containsSurrogatePair.Length);// 4

// POI: Characters outside BMP (Basic Multilingual Plane) are stored in 4 bytes rather than on 2 bytes. To get proper length of these
// characters (outside of BMP) we need to use StringInfo class which can deal with surrogate pair
cl(new StringInfo(containsSurrogatePair).LengthInTextElements);// 3

/*#1,005 – Replacing a Substring with a New Substring */

var bmpString = "dan brown";

cl(bmpString.Replace("dan", "DAN"));// DAN brown

// POI: ?? is shown but that's a issue with console
cl(containsSurrogatePair);// A??C
cl(containsSurrogatePair.Replace("A", ""));// ??C

// POI: Replace can deal with surrogate pair. Characters outside BMP (basic multi lingual plane)
cl(containsSurrogatePair.Replace("𠈓", ""));// AC

/*#1,004 – Converting a String to Uppercase or Lowercase */

cl("dan brown".ToUpper());// DAN BROWN
cl("A𠈓c".ToUpper());// A??C

// POI: CultureInfo.InvariantCulture returns a CultureInfo instance that is culture agnostic (independent)
// POI: CultureInfo.InvariantCulture is associated with English language but is not associated with any country/region
// POI: CultureInfo.InvariantCulture is more stable then other CutureInfos that are subject to changes
cl("A𠈓c".ToUpper(CultureInfo.InvariantCulture));

cl("Indigo".ToUpper(new CultureInfo("tr-TR")));// INDIGO
cl("indigo".ToUpper(CultureInfo.InvariantCulture));// INDIGO

// POI: Passing empty in constructor indicates Invariant culture info
var indigoUpperTr = "indigo".ToUpper(new CultureInfo("tr-TR"));
var indigoUpperInvariant = "indigo".ToUpper(CultureInfo.InvariantCulture);

cl(new StringInfo(indigoUpperTr).LengthInTextElements);// 6
cl(new StringInfo(indigoUpperInvariant).LengthInTextElements);// 6

cl($"{indigoUpperTr} => {indigoUpperInvariant}");// INDIGO => INDIGO

// POI: The upper cases are similar in both cultures but they are not equal because there internal character representation scheme is not same
cl(string.CompareOrdinal(indigoUpperTr, indigoUpperInvariant) == 0);// False
cl(string.Compare(indigoUpperInvariant, indigoUpperTr) == 0);// False
cl(indigoUpperInvariant == indigoUpperTr);// False

/*#1,003 – Accessing Underlying Bytes in a String for Different Encodings */

var turkishUpper = "some string".ToUpper(new CultureInfo("tr-TR"));

cl(null);

// TODO: Why following fails?
// turkishUpper.Cast<ushort>().Count();

turkishUpper.ToList().ForEach(x => Console.Write($"{(ushort)x:x4} "));// 0053 004f 004d 0045 0020 0053 0054 0052 0130 004e 0047
cl(null);
cl(turkishUpper.Length);// 11
cl(new StringInfo(turkishUpper).LengthInTextElements);// 11

cl(null);
Encoding.UTF8.GetBytes(turkishUpper).ToList().ForEach(x => Console.Write($"{x:x4} "));

cl(null);
cl(Encoding.UTF8.GetBytes(turkishUpper).ToList().Count());// 12

cl(null);
Encoding.Unicode.GetBytes(turkishUpper).ToList().ForEach(x => Console.Write($"{x:x4} "));
cl(null);
cl(Encoding.Unicode.GetBytes(turkishUpper).ToList().Count());// 22

cl(null);
Encoding.UTF32.GetBytes(turkishUpper).ToList().ForEach(x => Console.Write($"{x:x4} "));

cl(null);
cl(Encoding.UTF32.GetBytes(turkishUpper).ToList().Count());// 44

// TODO: Why is the encoded bytes different between original ushort conversion & all other UTF conversion. It should match with any of
// the above atleas
