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

    public static int Square(int a) => a * a;

    public static decimal Cube(decimal a) => a * a * a;

    public static void Print(object msg) => Console.WriteLine(msg);
}