using System;

public class Program
{
    private delegate T ArithmeticOperation<T>(T a, T b);

    private static T Max<T>(T a, T b) where T : IComparable => a.CompareTo(b) <= 0 ? b : a;
    protected static T Min<T>(T a, T b) where T : IComparable => a.CompareTo(b) <= 0 ? a : b;

    public static void Main()
    {
        //POI: Note the usage. Delegate is a .NET type. This is usage is similar to generic class declaration
        //POI: Max/Min are generic methods themselves
        //POI: Because of this declaration Max & Min's type parameter is IComparable
        ArithmeticOperation<IComparable> op = Max;
        op += Min;
        
        IterateOverInvocationList(op);
    }
    
    //POI: Similar to delegate instance declaration, parameter must have a type defined
    //This has to be resolved at compile time
    private static void IterateOverInvocationList(ArithmeticOperation<IComparable> op)
    {
        foreach (var method in op.GetInvocationList())
        {
            //Target :  Method : System.IComparable Max[IComparable](System.IComparable, System.IComparable)
            //Target :  Method : System.IComparable Min[IComparable](System.IComparable, System.IComparable)
            Print("Target : " + method.Target + " " + "Method : " + method.Method);
        }
    }

    //POI: Generic delegate is declared as argument. This makes method 'IterateOverInvocationList' obsolete
    //POI: This is possible even though 'ArithmeticOperation<T> op' can't be declared as variable unless that resided in a generic class
    private static void IterateOverInvocationGenericDelegate<T>(ArithmeticOperation<T> op)
    {
        foreach (var method in op.GetInvocationList())
        {
            //Target :  Method : System.IComparable Max[IComparable](System.IComparable, System.IComparable)
            //Target :  Method : System.IComparable Min[IComparable](System.IComparable, System.IComparable)
            Print("Target : " + method.Target + " " + "Method : " + method.Method);
        }
    }

    //POI: Multiple generic type parameters are defined
    public static void GenericFuncTransform<T, TResult>(T[] array, TResult[] resultArray, Func<T, TResult> func)
    {
        for(var i = 0; i < array.Length; i++)
        {
            //POI: Type defined with 'as' can be generic if on that generic type there is any constraint 
            //array[i] = func(array[i] as T);
            resultArray[i] = func(array[i]);
        }
    }

    private class NonGenericCls
    {
        //POI: This is not allowed because T isn't defined here  
        //private ArithmeticOperation<T> _genericDelegate;

        //POI: Type parameter MUST BE defined here as the class isn't generic itself   
        private ArithmeticOperation<decimal> _genericDelegate;

        public NonGenericCls(ArithmeticOperation<decimal> generic)
        {
            _genericDelegate = generic;
        }  
    }

    private class GenericCls <T>
    {
        //POI: This is alright. Compare it with 'NonGenericCls' class
        private ArithmeticOperation<T> _genericDelegate;

        public GenericCls(ArithmeticOperation<T> generic)
        {
            _genericDelegate = generic;
        }  
    }

    public static void Print(object msg) => Console.WriteLine(msg);
}

