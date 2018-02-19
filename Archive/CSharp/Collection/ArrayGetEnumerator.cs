using System;
using System.Collections;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {

        /********** INT ARRAY *******************/

        //In which namespace Arrays are defined? Seems like 'System'
        int[] ints = new int[] { 0, 1, 2, 3 };

        //POI: Following will throw 'Cannot implicitly convert type 'System..IEnumerator' to 'System..IEnumerator<int>'
        // Because for compatibility reasons Array returns classic (non generic) version of IEnumerator 
        //IEnumerator<int> intEnumerator = ints.GetEnumerator();

        IEnumerator intEnumerator = ints.GetEnumerator();//System.Array+SZArrayEnumerator

        Print<string>(null);
        
        //What is ArrayEnumerator?
        Print<Type>(ints.GetEnumerator().GetType());

        Print<string>(null);
        while(intEnumerator.MoveNext())
        {
            //POI: As array returns non-generic version of IEnumerator in this case Current will hold object NOT int
            Print<object>(intEnumerator.Current);

            //Following will throw CE saying: 'cannot convert from 'object' to 'int''
            //Print<int>(intEnumerator.Current);
        }

        /********** CHAR ARRAY *******************/

        char[] charSequence = new char[] { 'S', 'T', 'R' };

        //POI: Following will throws 'Cannot implicitly convert type 'System..IEnumerator' to 'System.Collections..IEnumerator<char>'
        // because array returns non-generic version of IEnumerator. NOT EVEN CharEnumerator defined in System namespace
        //IEnumerator<char> charSequenceEnumerator = charSequence.GetEnumerator();

        Print<string>(null);
        
        //What is ArrayEnumerator?
        Print<Type>(charSequence.GetEnumerator().GetType());//System.Array+SZArrayEnumerator

        IEnumerator charSequenceEnumerator = charSequence.GetEnumerator();

        Print<string>(null);
        while(charSequenceEnumerator.MoveNext())
        {
            Print<object>(charSequenceEnumerator.Current);
        }

        /********** X ARRAY *******************/

        X[] xTypeArray = new X[] { new X(10) , new X(100) };

        Print<string>(null);

        //In this case too ArrayEnumerator is returned even though the array is of custom object
        Print<Type>(xTypeArray.GetEnumerator().GetType());//System.Array+SZArrayEnumerator

        IEnumerator xTypeArrayEnumerator = xTypeArray.GetEnumerator();

        Print<string>(null);
        while(xTypeArrayEnumerator.MoveNext())
        {
            //This will fail because 'Current' is of object type. But Identity is a property of class X
            //Print<int>(xTypeArrayEnumerator.Current.Identity);

            Print<int>((xTypeArrayEnumerator.Current as X).Identity);
        }
    }
    
    private class X
    { 
        public int Identity { get; private set; }
        public X(int identity)
        {
            Identity = identity;
        }
    }

    public static void Print<T>(T a) => Console.WriteLine(a);
}