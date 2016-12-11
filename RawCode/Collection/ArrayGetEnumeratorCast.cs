using System;
using System.Collections;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        ArrayList arrayList = new ArrayList();

        arrayList.Add(new X());
        arrayList.Add(23.56);
        arrayList.Add("STR");
        arrayList.Add(Country.BD);

        IEnumerator arrayEnumerator = arrayList.GetEnumerator();

        //This can never be done because ArrayList doesn't implement IEnumerable<T> rather implements IEnumerable
        //IEnumerator<string> xArrayListEnumerator = (arrayList as IEnumerable<string>).GetEnumerator();

        Print<Type>(arrayEnumerator.GetType());

        while(arrayEnumerator.MoveNext())
        {
            Print<object>(arrayEnumerator.Current);//For Enum displayed value is BD
        }

        /****************** CAST TO IEnumerable<T> ***********************/

        int[] ints = new int[] { 0, 1, 2 };

        //POI: Array of int is converted to IEnumerable<int> to have access to generic implementation of
        // GetEnumerator() that resides in protocol IEnumerable<T>
        IEnumerator<int> xEnumerator = (ints as IEnumerable<int>).GetEnumerator();

        Print<string>(null);
        Print<Type>(xEnumerator.GetType());

        Print<string>(null);
        while(xEnumerator.MoveNext())
        {
            Print<int>(xEnumerator.Current);
        }

        /****************** ENUM ARRAY ***********************/

        Country[] countryArray = new Country[] { Country.BD, Country.UK, Country.AFG };

        //Non generic version of IEnumerator accessed via GetEnumerator() that's part of IEnumerable protocol
        IEnumerator countryEnumerator = countryArray.GetEnumerator();

        //Via casting generic version of IEnumerable<T> is accessed which has a generic GetEnumerator()
        IEnumerator<Country> countryGenericEnumerator = (countryArray as IEnumerable<Country>).GetEnumerator();

        Print<string>(null);
        Print<Type>(countryEnumerator.GetType());//System.Array+SZArrayEnumerator

        while(countryEnumerator.MoveNext())
        {
            //POI: Country is a non-nullable value type!
            Print<Country>((Country)countryEnumerator.Current);//BD, UK, AFG
        }

        /****************** ACCESSING VIA GENERIC IENUMERATOR ***********************/

        Print<string>(null);
        Print<Type>(countryGenericEnumerator.GetType());//System.SZArrayHelper+SZGenericArrayEnumerator`1[Program+Country]

        while(countryGenericEnumerator.MoveNext())
        {
            Print<Country>(countryGenericEnumerator.Current);
        }

        /*********************** STRUCT **********************************************/

        Y[] arrayY = new Y[] { new Y(10), new Y(100) };

        IEnumerator yEnumerator = arrayY.GetEnumerator();//Non-generic version
        IEnumerator<Y> yyEnumerator = (arrayY as IEnumerable<Y>).GetEnumerator();

        Print<string>(null);
        Print<Type>(yEnumerator.GetType());//System.Array+SZArrayEnumerator
        Print<Type>(yyEnumerator.GetType());//System.SZArrayHelper+SZGenericArrayEnumerator`1[Program+Y]

        Print<string>(null);
        while(yEnumerator.MoveNext())
        {
            Print<int>(((Y)yEnumerator.Current).value);
        }
    }

    private enum Country
    {
        BD,
        UK,
        USA,
        PAK,
        AFG
    }

    private struct Y
    {
        public int value;

        public Y(int val)
        {
            value = val;
        }
    }

    private class X { }

    public static void Print<T>(T msg) => Console.WriteLine(msg);
}