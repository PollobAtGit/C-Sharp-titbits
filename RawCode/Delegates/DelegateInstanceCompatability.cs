using System;

public class Program
{
    public delegate int Transformer(int a);//Identifier 'a' must be defined

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

*/