
// POI: Importing the TYPE 'Console' & importing only the static members of the TYPE & NOT IMPORTING other TYPES from
// System
using static System.Console;

// MI: Just using 'using' we can import a namespace NOT a TYPE. If any attempt is made to import the Type using 'using'
// than following CTE will be thrown
//      CTE => error CS0138: A 'using namespace' directive can only be applied to namespaces; 'Q' is a type not a namespace. Consider a 'using static' directive instead

// MI: 'using static' doesn't import the whole namespace rather only the Type

// MI: 'using static' can be used to import a specific Type which might not be static. But only the static members can be
// accessed. Ref: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive

// MI: using 'using static' we can import static & non-static Types but essentially we can only use static members of that
// Type. Because to use other non-static members we must declare a variable that will hold the new-ed instance of the Type
// which can not be done with a Type that has been imported using 'using static'

// POI: namespace has nothing to do with 'Folder' structure. Here inner namespaces are 'B' & 'C'. But this source file is
// not under 'B' or 'C' folder

namespace A.B.C
{
    // POI: Importing the WHOLE namespace
    using D.E;

    // POI: 'using static' will import the Type NOT the namespace. So 'Q' Type from D.S has been imported but NOT 'R'
    using static D.S.Q;

    // POI: This TYPE IMPORT will enable access to the static members of TYPE 'T' only NOT the non-static members
    using static D.S.T;

    // POI: Aliasing 'Cat' as 'C'. Aliasing technique can be useful when a CS file needs to import same named TYPES
    // from different assemblies/namespaces but for readabilities sake we want to refer to a specific TYPE with a alias
    using C = D.E.Cat;

    internal class Solution
    {
        internal static void Main()
        {
            // POI: This statement will execute without any error because of the import statement
            var man = new Man();

            // POI: This statement will execute without any error because both namespace declaration will be MERGED by C# compiler
            var dog = new Dog();

            // POI: C is alias for TYPE 'Cat'
            var c = new C();

            // POI: CTE because T is imported using 'using static' which will allows access to static members of the TYPE
            // var t = new T();

            WriteLine("Hello!");
            WriteLine(Print());

            // POI: This statement will throw CTE because this Type is defined in 'D.S' & that namespace has NOT been imported
            // rather the Type 'Q' has been imported
            // WriteLine(PrintR());
        }
    }
}

namespace D.E
{
    // POI: Other definition of 'D.E' can't have a TYPE 'Man' because those namespaces will be merged
    internal class Man { }
}

// POI: This definition of 'D.E' will be merged with the other declaration of 'D.E' defined above
namespace D.E
{
    // POI: We can't define 'Man' Type here because that Type is already defined in previous namespace declaration & both
    // of the namespace declarations will be merged later by C# compiler

    internal class Dog { }
}

namespace D.E
{
    internal class Cat { }
}

namespace D.S
{
    internal static class Q
    {
        internal static string Print() => "From D.S.Q";
    }

    internal static class R
    {
        internal static string PrintR() => "CRLF";
    }

    internal class T
    {
        internal string PrintT() => "From D.S.T";
    }
}
