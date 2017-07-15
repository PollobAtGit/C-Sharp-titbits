
void Print(object obj) { Console.WriteLine(obj); }

var x = 10;

Print(x);//10
Print(2 * x);//20

//POI: Assignment expression returns the number that has been assigned. So operations occur, 1) Assignment
//2) Returning assignment value
Print(2 * (x = 20));//40
Print(x);//20

Print(null);

//POI: To use continuous assignment the variables must be defined/declared before. In this case variable declaration &
//initialization can't be done together
int s, k, m;

//POI: 'k = 10' returns 10 which is assigned to 's'. (s = k = 10) returns 10 which is then multiplied with 100
//POI: This style of continuous assignment only works because assignment expressions return value that has been assigned
m = 100 * (s = k = 10);

Print(s);//10
Print(k);//10
Print(m);//1000

Print(null ?? "Default String");//Default String
Print("Non-default String" ?? "Default String");//Non-default String

Print(new Guid().ToString());

//POI: Throws Exception because null is null it doesn't have any ToString() member. It's not even a object
//Print(null.ToString());

string str = null;

//POI: Doesn't throw NullReferenceException because Elvis Operator (?.) returns null when the object is null rather than
//throwing Exception
Print(str?.ToString());

//POI: This statement (Expression?) is equivalent to 'str?.ToString()'
Print(str == null ? null : str.ToString());

internal class B
{
    //POI: Possible NullReferenceException when accessed
    public string Str;
}

internal class A
{
    //POI: Possible NullReferenceException when accessed
    public B Instance;
}

//POI: Default value at class member level is null for reference types & that is true for string too
Print(new B().Str == null);

//POI: Exception can occur at any state. 1) When accessing 'Instance' 2) When accessing Str
//POI: Using Elvis operator (?.). The first usage isn't required because we are initializing the object but later are useful

//POI: This approach is useful when we need to access a member by going through chain & we only care about the last
//accessed member ('Str' in this case). So in this case we only need to check for nullability of the last the member
//rather than checking for the whole chain of reference type members

Print(new A()?.Instance?.Str?.ToString());

//POI: ToString() might return null even though Length is invoked on it. So possibility for NullReferenceException.
//But there won't be any problem here because other expressions before ToString() invocation might result null. Otherwise
//potential for NullReferenceException
Print(new A()?.Instance?.Str?.ToString().Length);
