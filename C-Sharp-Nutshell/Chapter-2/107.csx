
int someVal;

void Print(object obj) { Console.WriteLine(obj); }

//POI: This print statement will not fail (throw exception) because 'someVal' is defined in class scope by 'csi' tool
//at local scope it will throw exception because C# makes sure that a variable must be initialized before it is being used
Print(someVal);

void SomeValPrint()
{
    int a;

    //POI: Following will throw exception because 'a' is defined but not initialized
    //Console.WriteLine(a);
}

void DeclareWithOut()
{
    //POI: Using 'out' to initialize a variable means that the variable declaration can not use implicit type declaration
    int a;
    var k = 50;

    //POI: Out & Ref variables must be marked with 'out' & 'ref' keyword
    //POI: 'a' is defined but not initialized
    ITakeOut(out a);

    //POI: 'k' is defined & initialized
    //POI: A variable can be initialized before it enters into a method that takes an argument with 'out' keyword
    //POI: Out & Ref variables must be marked with 'out' & 'ref' keyword
    ITakeOut(out k);
}

//POI: Argument is marked with 'out' keyword. Same is applicable for 'ref'
void ITakeOut(out int n)
{
    //POI: The argument that is accepted with 'out' keyword must be initialized/assigned before the method leaves the scope
    //otherwise a compilation error will be thrown even though it is possible that the variable passed to this method is
    //already initialized
    n = 10;
}

//POI: Usual usage of 'out'. Return multiple return values. In this case one boolean, two strings
bool SplitByWhiteSpace(string fullName, out string firstName, out string lastName)
{
    try
    {
        var spaceIndex = fullName.IndexOf(' ');

        firstName = fullName.Substring(0, spaceIndex);
        lastName = fullName.Substring(spaceIndex + 1);
    }
    catch(Exception)
    {
        //POI: In case of Exception, there's no gurantee that the code inside try will initialize the two string variables
        //So it's essential to handle that scenario otherwise compilation error will be thrown saying 'out' variables must
        //be initialized before method leaves the scope
        firstName = null;
        lastName = null;

        return false;
    }

    return true;
}

string firstName;
string lastName;

//POI: Arguments are marked with 'out'. Getting the return value also
var isSuccess = SplitByWhiteSpace("Same Jackson", out firstName, out lastName);

Console.WriteLine(isSuccess);
Console.WriteLine(firstName + " : " + lastName);

//POI: Because we are passing 'null' the method will throw Exception
var isSuccessAnother = SplitByWhiteSpace(null, out firstName, out lastName);

Console.WriteLine(isSuccessAnother);
Console.WriteLine(firstName + " : " + lastName);
