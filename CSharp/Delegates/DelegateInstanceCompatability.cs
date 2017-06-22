using System;

public class Program
{
    public delegate int Transformer(int a);//Identifier 'a' must be defined


    delegate void D1();
    delegate void D2();

    void Method1() { }
    void Method2() { }

    public void DelegateInstanceCompatability()
    {
        D1 dInstance = Method1;
        
        //This throws compilation error
        //POI: One delegate instance isn't compatible with another delegate type
        // even though they are instances of same delegate type (Compare the scenario with class instances) 
        
        //D2 dTwoInstance = dInstance;

        //Compare the below scenario with delegate instance's compatible scenario
        X xInstance = new X();
        X xxInstance = new X();

        X xSwapper = xInstance;

        xInstance = xxInstance;
        xxInstance = xSwapper;
    }

    public static void Main()
    {
        //Delegate instance declared. Instance is null here
        Transformer instance;
        Transformer instanceTwo;
        Transformer instanceThree;
        Transformer instanceFour;

        instance = new Transformer(MethodOne);
        instanceTwo = new Transformer(MethodOne);
        instanceThree = new Transformer(MethodTwo);
        instanceFour = new Transformer(new X().MethodOne);

        Print((instance == instanceTwo) == true);//TRUE

        //POI: Both of the methods that subscribed to these delegate instances have SAME signature. But the difference is in method name 
        Print((instance == instanceThree) == false);//TRUE

        //POI: Difference between instanceTwo & instanceFour is instanceFour's Target is X 
        Print((instance == instanceFour) == false);//TRUE

        instanceThree += MethodOne;
        instanceTwo += MethodTwo;

        Print((instanceThree == instanceTwo) == false);//TRUE

        instance += MethodTwo;

        //In this case, both of the instances are multicast delegate & the methods are added in same order & those methods have same Method & Target
        Print((instance == instanceTwo) == true);//TRUE
    }

    private class X
    {
        public int MethodOne(int a) => a;    
    } 

    //POI: Must be static to be used in another static method even if that method isn't really invoked but used to create an delegate 
    public static int MethodOne(int a) => a;
    public static int MethodTwo(int a) => a;  

    //POI: Generic option, it's better than using object as parameter type because that has the boxing overhead
    public static void Print<T>(T msg) => Console.WriteLine(msg);
}

/*

POI: Two delegate instances are considered same if

# They are of same typed delegates
# They have same Target
# They have same Method
# They have same invocation list (applicable for multicast delegate)

Even if some delegate instance is considered SAME with another they aren't COMPATIBLE

*/