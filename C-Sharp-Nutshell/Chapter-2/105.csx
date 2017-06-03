
void Print(object msg) { Console.WriteLine(msg); }

enum DAY { }
class Dog { }
struct Cat
{
    private double _width;
    public double Width { get { return _width; } }
    public string Name;
}

char ch;
int defaultIntValue;
decimal defaultDecimalValue;
double defaultDoubleValue;
float defaultFloatValue;
bool isTrue;

Action<int> defaultDelegateValue;

//POI: Default value for an enum instance is '0'
DAY someDay;

//POI: Default value for a custom class is 'null'
Dog aDog;

Cat aCat;

//POI: In this case default value will be set because of the environment (using scripting, csx file) generally a LOCAL variable MUST be
//initialized before it's first usage

Console.WriteLine(ch == 0);//True
Console.WriteLine(defaultIntValue);//0
Console.WriteLine(defaultDecimalValue);//0
Console.WriteLine(defaultDoubleValue);//0
Console.WriteLine(defaultFloatValue);//0
Console.WriteLine(isTrue);//False

Console.WriteLine(defaultDelegateValue == null);//True
Console.WriteLine(someDay);//0

Console.WriteLine(aDog == null);//True

//POI: struct is a VALUE TYPE also a custom type. So the default value is bitwise zeroing of memory but that' not null (because
//it's a value type). Some text here indicates default value is NOT NULL
Console.WriteLine(aCat);//Submission#0+Cat

//POI: Internal types are also initialized to their default value
Console.WriteLine(aCat.Width);//0
Console.WriteLine(aCat.Name == null);//True

// ------------------ USING default keyword to get the default value ------------------------

Print("\n------------------ USING default keyword to get the default value ------------------------\n");

Print(default(decimal));
Print(default(double));
Print(default(int));
Print(default(string) == null);//True
Print(default(char) == 0);//True

//POI: Default value for a Enum type is '0'
Print(default(DAY));//0

//POI: Default value for a custom type is 'null'
Print(default(Dog) == null);//True
Print(default(Cat));//Submission#0+Cat

//POI: Delegates are TYPE & they are of reference TYPE
Print(default(Action<int>) == null);//True
Print(default(Func<int>) == null);//True

// --------------------- Assign default values to a variable -------------------------------------

Print("\n--------------------- Assign default values to a variable -------------------------------------\n");

//POI: All of the below statements will work properly because from usage of default compiler can infer the TYPE. So using 'var' is
//alright in this context
var doubleValue = default(double);
var defaultInt = default(int);
var defaultString = default(string);
var defaultEnum = default(DAY);
var defaultClass = default(Dog);
var defaultStruct = default(Cat);
var defaultDelegate = default(Action<int>);

Print(defaultEnum);
Print(defaultInt);
Print(defaultStruct);
Print(doubleValue);
Print(defaultClass == null);
Print(defaultDelegate == null);
Print(defaultString == null);
