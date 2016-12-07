using System;

//Delegate is a CLR TYPE. In fact 'error CS0118' is thrown if delegate isn't used like a TYPE

//Syntax: 'keyword delegate' + a 'full method signature with method name'
//This method name will be used as TYPE for the delegate  
delegate void Observers();//EMPTY parenthesis indicates no parameter is needed

delegate int Transform(int x);

//Can class access any of the InnerClass members specially private ones?
class Program
{
    public static void Main()
    {
        ObserverDelegate();

        TransformMethod();

        Prnt(IWilltranformAsYouWant(10, x => x * x) == 100);//TRUE

        BulkTransform(new int[] { 1, 3, 6, 7, 12, 0 }, x => x % 2);//6, 12, 0
        BulkTransform(new int[] { 1, 3, 6, 7, 12, 0 }, x => x % 3);//3, 6, 12, 0

        DelegatesHaveMultiCastCapability();

        //Note that null is passed as argument. So a 'Null Reference Exception' is thrown which indicates delegate instances are reference types &
        //every method that replies on delegate instance must check for the instance's nullability
        Invoke(null);
    }

    private static void ABitOfNestedClassAccessibilityChecking()
    {
        var inner = new InnerClass();
        
        //Note that inner class's static variable isn't accessible here automatically
        //(unlike the scenario where inner class has automatic accessibility to outer class static members)
        var count = InnerClass.StrCount;
    }

    private class InnerClass
    {
        //This member is accessible only INSIDE this function, not even to the Outer level class (even though inner class can access private members of outer level class)
        private readonly int _count = 100;

        //This member is public so that makes it accessible to the outer class but through object reference
        public int Count = 100;

        //This member is public which makes it accessible to outer class but even though it's static it's not accessible to outer level class
        // automatically. So it has to referenced normally with specifying class name
        public static int StrCount = 1000;

        //Even though the constructor is public it's accessibility is limited by 'private' access specifier for the class
        //In other words, accessibility of the constructor can be restricted class's accessibility, if required 
        public InnerClass()
        {
            //'Invoke' is a static member of Outer class. So InnerClass can directly (without any reference at all) access them   
            Invoke(MethodFour);//MethodFour is private. So delegate instances doesn't distinguish based on accessibility. Or doesn they?
        }
        
        public InnerClass(int count)
        {
            _count = count;
        }

        private void MethodFour() => Prnt("FROM METHOD #4");
    }

    public static void Invoke(Observers func)
    {
        if(func == null) return;
        func();
    }

    public static void DelegatesHaveMultiCastCapability()
    {
        Observers observer = () => Prnt("MONITOR");

        //Adding more methods to the delegate instance
        observer += () => Prnt("PC");
        observer += () => Prnt("PRINTER");
        observer += () => Prnt("HEADPHONE");

        //Add non-anonymous methods to delegate instance 
        observer += MethodOne;
        observer += MethodTwo;

        Prnt(null);
        observer.Invoke();//It can be observer()

        Prnt(null);

        //Following two statements will not remove any methods from delegate instance. Is it because they are anonymous methods?
        observer -= () => Prnt("HEADPHONE");
        observer -= () => Prnt("PRINTER");

        //Remove non-anonymous methods to delegate instance
        //This removal will work properly because they aren't anonymous methods
        observer -= MethodOne;
        observer -= MethodTwo;

        //This statement doesn't cause any issue even though 'MethodThree' wasn't added in the delegate instance 
        observer -= MethodThree;

        observer();
    } 

    public static void BulkTransform(int[] array, Transform func)
    {
        if(func == null) return;

        Prnt(null);

        //Length is a property, not method
        for(var i = 0; i < array.Length; i++)
        {
            if(func(array[i]) != 0) continue;
            Prnt("#" + array[i] + " found");
        }
    }

    //Plugging method into another method via delegate is useful when that function is used by some other language / framework type / construct that
    //the developer wanna use. If that type / construct depends on a function that developer can provide with his custom implementation than the 
    //construct can be used without re-writing the construct
    public static int? IWilltranformAsYouWant(int value, Transform func)
    { 
        if(func == null) return null;
        return func(value);
    }

    //Can't declare another member/TYPE with this name      
    //delegate void TransformMethod();
    
    //Can a delegate of this name exist?
    public static void TransformMethod()
    {
        Prnt(null);

        Transform _instance = (x) => x * x * x;
        Prnt(_instance.Invoke(9) == 729);//TRUE
    }

    public static void ObserverDelegate()
    {
        Observers observer = null; 
        
        //Note that the instance of the delegate is initialized with NULL.
        //Yet methods can be added to that instance. This behavior is different from other
        //CLR types where the instance is initialized with a 'new keyword'

        observer += () => Prnt("First Lambda Expression");
        observer += () => Prnt("Second Lambda Expression");

        Prnt(null);
        observer();
        
        Prnt(null);
        //This invocation is same as the above one. Above call is a syntactic sugar for this statement
        observer.Invoke();


        //This can't be done (!) Compiler sees this line & assumes the name as a type (class/struct) that has constructor
        //Observers anotherObserver = new Observers();

        //Here anotherObserver is a INSTANCE of Observers
        Observers anotherObserver = null;

        anotherObserver += () => Prnt("I am from another observer");

        Prnt(null);
        anotherObserver();
    }

    public static void Prnt(object msg) => Console.WriteLine(msg);

    //All of these methods subscribe to delegate instance. Note that they are static methods
    public static void MethodOne() => Prnt("FROM METHOD #1");
    public static void MethodTwo() => Prnt("FROM METHOD #2");
    public static void MethodThree() => Prnt("FROM METHOD #3");
}

//POI #1: Method removal from delegate instance will succeed if the given method's 'Target' & 'Method' matches with any of the subscribed method.
// Problem is for a anonymous method/lambda instance (!) 'Method' & 'Target' aren't strictly defined (actually defined reference: http://stackoverflow.com/questions/25563518/why-cant-i-unsubscribe-from-an-event-using-a-lambda-expression/25564492#25564492)  