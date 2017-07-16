
void Print(object obj) { Console.WriteLine(obj); }

void AnyFunc()
{
    int x = 10;

    {
        //POI: 'x' is declared in outer scope
        //int x = 20;

        int y = 10;

        //POI: 'z' is declared in outer scope. A variable's scope extends in both directions. 'z' is declared in outer scope
        //but at the end so another 'z' can't be declared here
        //int z = 100;
    }

    Print(x);

    //POI: 'y' is not declared in this scope
    //Print(y);

    int z = 10;
}

AnyFunc();

Print(null);

void SwitchFlow(int n)
{
    //POI: C# enforces 'break' on switch statements. Otherwise exception
    //'Control cannot fall through from one case label ('case 1:') to another' will be thrown
    switch(n)
    {
        case 1:
            Print(1);
            break;
        case 2:
            Print(2);
            break;
        case 3:
            Print(3);
            break;
        default:
            Print("Not Found");

            //POI: break on 'default' is also mandatory
            break;
    }
}

SwitchFlow(1);//1
SwitchFlow(2);//2
SwitchFlow(3);//3
SwitchFlow(10);//Not Found
