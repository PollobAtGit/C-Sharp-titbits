using System;

//Delegate is a CLR TYPE. In fact 'error CS0118' is thrown if delegate isn't used like a TYPE

//Syntax: 'keyword delegate' + a 'full method signature with method name'
//This method name will be used as TYPE for the delegate  
delegate void Observers();

delegate int Transform(int x);

class Program
{
    public static void Main()
    {
        ObserverDelegate();
        TransformMethod();

        Prnt(IWilltranformAsYouWant(10, x => x * x) == 100);
    }

    //Plugging method into another method via delegate is useful when that function is used by some other language / framework type / construct that
    //the developer wanna use. If that type / construct depends on a function that developer can provide with his custom implementation than the 
    //construct can be used without re-writting the construct
    public static int IWilltranformAsYouWant(int value, Transform func) => func(value);

    //Can't declare another member/TYPE with this name      
    //delegate void TransformMethod();
    
    //Can a delegate of this name exist?
    public static void TransformMethod()
    {
        Transform _instance = (x) => x * x * x;
        Console.WriteLine(_instance.Invoke(9) == 729);//TRUE
    }

    public static void ObserverDelegate()
    {
        Observers observer = null; 
        
        //Note that the instance of the delegate is initialized with NULL.
        //Yet methods can be added to that instance. This behavior is different from other
        //CLR types where the instance is initialized with a 'new keyword'

        observer += () => Console.WriteLine("First Lambda Expression");
        observer += () => Console.WriteLine("Second Lambda Expression");

        observer();
        
        //This invocation is same as the above one. Above call is a syntactic sugar for this statement
        observer.Invoke();


        //This can't be done (!) Compiler sees this line & assumes the name as a type (class/struct) that has constructor
        //Observers anotherObserver = new Observers();

        //Here anotherObserver is a INSTANCE of Observers
        Observers anotherObserver = null;

        anotherObserver += () => Console.WriteLine("I am from another observer");

        anotherObserver();
    }

    public static void Prnt(object msg) => Console.WriteLine(msg);
}