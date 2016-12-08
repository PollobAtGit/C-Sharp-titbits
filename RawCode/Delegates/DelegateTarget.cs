using System;
using System.Linq;

public class Program
{

    private string _isbn;

    public delegate X[] Methods();
    public delegate void ITakeProgramMethods();
    
    
    //Delegate can't be static. They are static by default? Similar to const? Is Enum static?
    //public static delegate void IAmAStaticDelegate();

    public Program() { }

    public Program(string isbnNumber)
    {
        _isbn = isbnNumber;
    }

    public static void Main()
    {
        //How to use LINQ here?
        foreach (var item in IAmStatic())
        {
            Print(item.Price);
        }

        //There weren't any issue using non-static delegates in static method
        //This is valid as IAmStatic is static no object reference is needed
        Methods methodInstances = new Methods(IAmStatic);

        //To reference a instance method an instance has been created
        methodInstances += new Program().IAmAnInstanceMethod;

        ShowDelegateMethodTypes(methodInstances);

        ITakeProgramMethods programMethods = new ITakeProgramMethods(new Program("CVTR").GetISBN);
        programMethods += new Program("GHTY").GetISBN;

        //Indeed delegates keep a reference to the instance (not only class name though that's what will shown if 'Target'
        // property of the delegate is inquired) that had the method
        programMethods();//CVTR, GHTY

        ShowDelegateMethodTypes(programMethods);

        //This isn't allowed because _isbn is an instance member but this method is static
        //var a = _isbn;

        //But this allowed even though ITakeProgramMethods isn't static (!). Delegates can't be static
        ITakeProgramMethods iTakeProgramMethods = new ITakeProgramMethods(new Program().GetISBN);
    }

    public void GetISBN() => Print(_isbn);

    //Note that here the base class of all delegates System.Delegate has been used
    public static void ShowDelegateMethodTypes(Delegate methods)
    {
        foreach(var method in methods.GetInvocationList())
        {
            //Note that for the static method Target is EMPTY But for the instance method it contains the Class name
            Print("TARGET: " + method.Target + " METHOD: " + method.Method);
        }
    }

    public static X[] IAmStatic() => new X[] { new X(10.23m), new X(0.00m) };

    public X[] IAmAnInstanceMethod() => new X[] { new X(100.23m), new X(110.00m) };

    public Program[] IAmAnInstanceMethodOfProgramClass() => new Program[] { new Program("CVTR"), new Program("GHTY") };

    //Accessibility of X should be same as the static method as in this case the static method can be accessed from outside the assembly  
    public class X
    {
        public decimal Price { private set; get; }

        public X(decimal value)
        {
            Price = value;
        }    
    }

    public static void Print(object msg) => Console.WriteLine(msg);
} 