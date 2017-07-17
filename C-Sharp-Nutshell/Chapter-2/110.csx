
void Print(object obj) { Console.WriteLine(obj); }

//POI: In switch-case statements using 'default' is a best practice because new ENUM values might
// be added to the ENUM type later

//POI: Enums can be statically evaluated along with integral types, string, boolean etc.
//POI: Enum defines a Type
enum DAY
{
    SAT,
    SUN,
    MON
}

void SwitchOnEnum(DAY day)
{
    //POI: Jump statement must be provided for each 'case'. In this case it's 'break'
    switch(day)
    {
        case DAY.SAT:
            Print("SAT");
            break;
        case DAY.SUN:
            Print("SUN");
            break;
        case DAY.MON:
            Print("MON");
            break;
        //POI: 'default' for switch is optional
    }
}

SwitchOnEnum(DAY.SUN);
SwitchOnEnum(DAY.MON);

void SwitchOnInt(int n)
{
    switch(n)
    {
        //POI: Grouping of 'case' statements
        case 1:
        case 2:
        case 3:
            Print("1/2/3");

            //POI: Every case must have an 'jump' statement even with the last 'case' statement
            break;

        //POI: 'default' is not mandatory but 'jump statement' after each case or group of case is mandatory
    }
}

SwitchOnInt(1);
SwitchOnInt(2);
SwitchOnInt(3);
SwitchOnInt(10);

void SwitchOnBool(bool isTrue)
{
    switch(isTrue)
    {
        case true:
            Print("TRUE");
            break;
        case false:
            Print("FALSE");
            break;

        //POI: 'default' is allowed on boolean type even if 'default' doesn't make any sense in this context
        default:
            Print("Default for boolean");

            //POI: 'Jump statement' is mandatory for both 'case' & 'default'
            break;
    }
}

SwitchOnBool(true);
SwitchOnBool(false);

void SwitchOnChar(char ch)
{
    switch(ch)
    {
        case 'A':

        //POI: Unlike C++, char & int are not compatible with each other
        //case 65:
            Print("A");
            break;
        case 'B':

        //POI: Unlike C++, char & int are not compatible with each other
        //case 66:
            Print("B");
            break;

        //POI: 'default' is not mandatory but if 'default' is mentioned then 'Jump statement' is mandatory
    }
}

SwitchOnChar('A');
SwitchOnChar((char)66);

//POI: No output as 'default' is not defined in switch-case
SwitchOnChar('z');

void SwitchRedirectToCase(DAY day)
{
    switch(day)
    {
        case DAY.MON:
            Print("MON");

            //POI: 'Jump statement' can be used to redirect/jump to 'default' case/label
            goto default;
        case DAY.SUN:
            Print("SUN");

            //POI: 'goto' is one 'Jump statement' that can be used in 'case' instead of 'break'
            //POI: Syntax of 'case' is same as any other 'case' statement
            //POI: This syntax is the simplistic version of 'goto LABEL'

            goto case DAY.MON;
        default:
            Print("End of world");
            break;
    }
}

Print(null);

SwitchRedirectToCase(DAY.MON);

Print(null);

//POI: 1st prints 'SUN' then control is moved to 'MON'
SwitchRedirectToCase(DAY.SUN);//SUN MON

DAY ReturnFromSwitch(DAY day)
{
    switch(day)
    {
        //POI: Along with 'break' & 'goto' 'return' can be used as 'Jump Statement'
        case DAY.MON: return DAY.SUN;
        case DAY.SUN: return DAY.MON;
        default: return DAY.SAT;
    }
}

Print(null);

Print(ReturnFromSwitch(DAY.SUN));
Print(ReturnFromSwitch(DAY.MON));
Print(ReturnFromSwitch(DAY.SAT));

void SwitchWithBreak(DAY day)
{
    switch(day)
    {
        case DAY.SUN:
            Print("SUN");

            //POI: 'continue' is applicable if the switch statement is enclosed by a lopping construct such as 'foreach', 'for' etc.
            // continue;

            break;
        case DAY.MON:
            Print("MON");
            break;
        default: break;
    }
}

Print(null);

SwitchWithBreak(DAY.SUN);
SwitchWithBreak(DAY.MON);
SwitchWithBreak(DAY.SAT);

void SwitchWithThrow(DAY day)
{
    switch(day)
    {
        //POI: throw can be used as a 'Jump statement' along with break, return, continue & goto
        case DAY.SUN: throw new Exception("SUN EXCEPTION");
        case DAY.MON: throw new Exception("MON EXCEPTION");
        case DAY.SAT: throw new Exception("SAT EXCEPTION");
        default: throw new Exception("UNKNOWN EXCEPTION");
    }
}

Print(null);

void TryCatchSwitchWithThrow(DAY day)
{
    try
    {
        SwitchWithThrow(day);
    }
    catch (Exception exp)
    {
        Print(exp.Message);
    }
}

TryCatchSwitchWithThrow(DAY.SUN);
TryCatchSwitchWithThrow(DAY.MON);
TryCatchSwitchWithThrow(DAY.SAT);
