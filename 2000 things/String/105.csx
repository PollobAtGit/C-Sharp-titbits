
Action<object> cl = (object x) => Console.WriteLine(x);

/* #104 Functions To Trim Leading And Trailing Characters From A String/*/

var names = "Johny  -  Mary  -  Elvis  -  Ringo";

var chars = names.Split(' ');

cl(string.Join("|", chars));// Johny||-||Mary||-||Elvis||-||Ringo
cl(chars.Length);// 13

var charsRemovedEmpty = names.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

cl(string.Join("|", charsRemovedEmpty));
cl(charsRemovedEmpty.Length);

var braces = new char[] { '{', '}' };
var guidString = "{f543ff3b-bc38-455d-8a13-00b0a6389cc8}";
var trimmedGuid = guidString.Trim(new char[] { '{', '}' });// Leading & traling trim
var guid = Guid.Parse(trimmedGuid);

cl(guidString);
cl(trimmedGuid);
cl(guid);

cl(null);
cl("{{f{543ff3b-bc38-{455d-8a13}-00b0a6389cc}8{}".Trim(new char[] { '{', '}' }));// f{543ff3b-bc38-{455d-8a13}-00b0a6389cc}8


/* #103 - Inserting and Removing Substrings*/

var name = "John Adams";

// POI: IndexOf(...) returns the starting index of the specified string
var insertedString = name.Insert(name.IndexOf("Adams"), "Another ");

// POI: Original string is unmodified
cl(name);// John Adams
cl(insertedString);// John Another Adams

var partialString = insertedString.Remove(2, 5);// Starting from index 2 remove 5 characters
cl(partialString);// Joother Adams

/* #104 - Use Substring() to extract sub strings from a string */

var extractedString = insertedString.Substring(2, 5);// Starting from index 2 extract 5 characters
cl(extractedString);// hn An

/* #105 - Use Contains(...) to figure out if a string contains other string */

cl(insertedString.Contains(extractedString));// True
cl(insertedString.Contains(partialString));// False

