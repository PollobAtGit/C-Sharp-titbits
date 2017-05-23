
// -------------------------------------------- C# String -----------------------------------------------------

//POI: String assignment follows the symantics of value type even though it's actually a REFERENCE type
var str = "I AM A STRING";

//POI: String is defined in 'System' namespace. It's part of BCL
Console.WriteLine(str.GetType());//System.String

//POI: For System.String instances only equal to & not equal to operators are defined
Console.WriteLine(str == "SOME STRING");
Console.WriteLine(str != "SOME STRING");

//POI: Following comparisons are NOT allowed on System.String
//Console.WriteLine(str > "SOME STRING");
//Console.WriteLine(str < "SOME STRING");

//POI: Verbatim string's are prefixed with '@'
//POI: Verbatim strings don't allow escaping characters (It considers everything inside literally)
System.String verbatimStr = @"I DON'T NEED \ ESCAPE CHARACTER";

//POI: For non-verbatim string special characters need to be escaped
System.String nonVerbatimStr = "I NEED \\ ESCAPE CHARACTER";

Console.WriteLine(verbatimStr);
Console.WriteLine(nonVerbatimStr);

//POI: Non-verbatim strings CAN NOT BE expanded to multiple lines
/*
    System.String nonMultiLineStr = "LINE 1
    LINE 2";

    Console.WriteLine(nonMultiLineStr);
*/

//POI: Verbatim strings takes everything inside it literally. So CRLF after 'LINE 1' will be taken literally
System.String multiLineStr = @"LINE 1
LINE 2";

//POI: This line is equivalent to the above line which took imposed CRLF literally
System.String singleLineStr = "LINE 1 \r\nLINE 2";

Console.WriteLine(multiLineStr);
Console.WriteLine(singleLineStr);

//POI: Verbatim string needs a way to distinguish string initiator double quotation & literal double quotation. So double quotation needs to be escaped
System.String xmlElement = @"<customer id = ""123""></customer>";

Console.WriteLine(xmlElement);

// -------------------------------------------- C# String Interpolation -----------------------------------------------------

int aValue = 100;

//POI: '$' is the indicator for string interpolation
//POI: Expression that will be evaluated needs to be enclosed by '{}'
System.String aValueStr = $"Value Is {aValue}";

Console.WriteLine(aValueStr);

//POI: '$' (dollar sign) indicates string interpolation
System.String fourDigitHexStr = $"Hex of 255 is {byte.MaxValue:X4}";//4 digit hexa-decimal value
Console.WriteLine(fourDigitHexStr);//00FF

//POI: 'byte' is the alias for Byte (what's the exact type name?) type
System.String twoDigitHexStr = $"Hex of 255 is {byte.MaxValue:X2}";
Console.WriteLine(twoDigitHexStr);//FF

//POI: Following is NOT valid because interpolated string must end in a single line (similar to normal string)
/*
    System.String singleLineStrInterpolation = $"LINE 1
    LINE 2";
*/

//POI: To use string interpolation & also to let string expand multiple lines use both verbatim string & string interpolation syntax
System.String interpolatedMultilineStr = $@"LINE 1
{byte.MaxValue:X4}";

Console.WriteLine(interpolatedMultilineStr);
