using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public delegate T Transformer<T>(T a);

    public static void Main()
    {
        var values = new int[] { 0,1, 2, 3 };

        //POI: Square IS NOT a generic. But Transform IS generic
        Transform(values, Square);

        //DisplayArray(values.Select<int, object>(elem => elem as object));
        DisplayArray(values);

        Print(null);

        //POI: Transformer is generic so typed parameter 'decimal' can be given. Also method 'Cube'
        // takes decimal as parameter so consistency is maintained 
        Transformer<decimal> cubeTransformer = new Transformer<decimal>(Cube);

        //This isn't valid & throws compilation error. Because in this case Transformer delegate is declared
        //as decimal but Square takes int as parameter. So there's inconsistency.
        //Transformer<decimal> squareTransformer = new Transformer<decimal>(Square);

        //var decimalArray = values.Select<int, decimal>(elem => (decimal)elem);
        var decimalArray = new decimal[] { 1m, 2.202m, -3.99m };
        TransformByCube(decimalArray, cubeTransformer);

        DisplayDecimalArray(decimalArray);
        Print(null);

        //From seeing this code it's difficult to say whether 'Cube' is generic or non-generic
        // If Cube were generic this code will always compile (given that the cube &
        // Transformer declaration is proper). But if cube is strongly typed then it MIGHT not compile
        // & that depends on type of Transformer & Cube's type 
        Transformer<decimal> transformer = Cube;

        GenericTransform(decimalArray, Cube);
        GenericArrayDisplay(decimalArray);
        Print(null);

        GenericTransform(values, Square);
        GenericArrayDisplay(values);
        Print(null);

        GenericFuncTransform(values, Square);
        GenericArrayDisplay(values);
        Print(null);

        GenericFuncTransform(values, (x) => x / 2);
        
        //POI: (input [,...]) => .... this lambda format doen't necessarily means something has to be returned
        // it depends on the delegate that's being accepted. In this example, Print(x) returns noting but displays x
        // on the other hand in the invocation 'GenericFuncTransform(values, (x) => x / 2);' the second parameter
        // returns 'x / 2' for every 'x'
        ActionArrayDisplay<int>(values, (x) => Print(x));
        Print(null);
    }

    //Why doesn't it work?
    //public static void DisplayArray(IEnumerable<object> object[] array)

    public static void DisplayArray(int[] array)
    {
        foreach(var elem in array)
        {
            Print(elem);
        }
    }

    public static void DisplayDecimalArray(decimal[] array)
    {
        foreach(var elem in array)
        {
            Print(elem);
        }
    }

    //This can take array of any type
    //POI: This method makes 'DisplayDecimalArray' & 'DisplayArray' obsolete
    //POI: Failed attempt to do this was by declaring 'object[]' as parameter but as int[]/decimal[]/double[] etc..
    // can't be transformed into object[] (they aren't reference types)
    public static void GenericArrayDisplay<T>(T[] array)
    {
        foreach(var elem in array)
        {
            Print(elem);
        }
    }

    public static void ActionArrayDisplay<T>(T[] array, Action<T> action)
    {
        foreach(var elem in array)
        {
            action(elem);
        }
    }

    //Why can't IEnumerable<T> can't be pushed into T[]? Following doesn't work
    //public static void TransformByCube(decimal[] array, Transformer<decimal> t)

    public static void TransformByCube(decimal[] array, Transformer<decimal> t)
    {
        //IEnumerable doesn't have 'Length' property
        //for(var i = 0; i < array.Count(); i++)
        for(var i = 0; i < array.Length; i++)
        {
            array[i] = t(array[i]);//Transformation
        }
    }

    public static void Transform(int[] array, Transformer<int> t)
    {
        //Array has 'Length' property but not 'Count' property
        for(var i = 0; i < array.Length; i++)
        {
            array[i] = t(array[i]);//Transformation
        }
    }

    //POI: This method made 'Transform' & 'TransformByCube' obsolete
    // POI: Transform<T> has been declared here & that's possible because this method is generic (note '<T>')
    public static void GenericTransform<T>(T[] array, Transformer<T> transform)
    {
        for(var i = 0; i < array.Length; i++)
        {
            array[i] = transform(array[i]);
        }
    }

    //POI: First argument for 'Func' is input, second one is output
    //POI: Becasue Func<T, T> is provided by .NET we don't need delegate 'Transformer' 
    public static void GenericFuncTransform<T>(T[] array, Func<T, T> func)
    {
        for(var i = 0; i < array.Length; i++) 
            array[i] = func(array[i]);
    }

    public static int Square(int a) => a * a;

    public static decimal Cube(decimal a) => a * a * a;

    public static void Print(object msg) => Console.WriteLine(msg);
}