using System;

public class Program
{
    private delegate T ArithmeticOperation<T>(T a, T b);

    private static T Max<T>(T a, T b) where T : IComparable => a.CompareTo(b) <= 0 ? b : a;
    protected static T Min<T>(T a, T b) where T : IComparable => a.CompareTo(b) <= 0 ? a : b;

    public static void Main()
    {
        //Note the usage. Delegate is a .NET type. This is usage is similar to generic class declaration
        ArithmeticOperation<IComparable> op = Max;
        op += Min;
        
        IterateOverInvocationList(op);
    }
    
    private static void IterateOverInvocationList(ArithmeticOperation<IComparable> op)
    {
        foreach (var method in op.GetInvocationList())
        {
            //Target :  Method : System.IComparable Max[IComparable](System.IComparable, System.IComparable)
            //Target :  Method : System.IComparable Min[IComparable](System.IComparable, System.IComparable)
            Print("Target : " + method.Target + " " + "Method : " + method.Method);
        }
    }

    public static void Print(object msg) => Console.WriteLine(msg);
}

