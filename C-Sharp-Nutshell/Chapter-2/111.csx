
//POI: break, continue, return, throw & goto can be used as jump statement
//POI: break is used in switch statement & to break out from for looping construct
//POI: continue is used to postpone & resume operation in a looping construct
//POI: throw can be used as jump statement with/without looping construct

void Print(object obj) { Console.WriteLine(obj); }

void ForLoop()
{
    //POI: Following will cause Exception because C#'s scoping rule works both ways
    // var i = 0;

    for(var i = 0; i < 10; i = i + 1)
    {
        Print(i);
    }

    //POI: Following will cause Exception because C#'s scoping rule works both ways
    // var i = 0;
}

ForLoop();

Print(null);

//POI: Using a string directly not via a variable
foreach(var ch in "BEER") Print(ch);

Print(null);

foreach(var ch in "BEAR")
{
    //POI: 'break' is a jump statement
    if(ch == 'A') break;
    Print(ch);
}

Print(null);

foreach(var ch in "BEAR")
{
    //POI: 'continue' is a jump statement
    if(ch == 'A') continue;
    Print(ch);
}

Print(null);

bool ContainsU()
{
    foreach(var ch in "HUSH")
    {
        //POI: 'return' is used as a 'jump statement'
        if(ch == 'U') return true;
        Print(ch);
    }
    return false;
}

Print(ContainsU());

void IThrowException()
{
    //POI: 'throw' can be used as a jump statement & with/without looping construct
    throw new Exception("Throwing");
}

try
{
    IThrowException();
}
catch(Exception exp)
{
    Print("Exception occurred : " + exp.Message);
}

void IThrowExceptionFromLoop()
{
    foreach(var ch in "CHARACTER")
    {
        //POI: throw is used as a jump statement
        if(ch == 'T') throw new Exception("T Found");
        Print(ch);
    }
}

Print(null);

try
{
    IThrowExceptionFromLoop();
}
catch(Exception exp)
{
    Print(exp.Message);
}
