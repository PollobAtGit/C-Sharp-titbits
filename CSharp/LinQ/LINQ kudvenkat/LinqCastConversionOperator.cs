using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace LinqCastConversionOperator
{

    internal interface IBook { }
    internal class Book : IBook
    {
        public override string ToString() => "BOOK STRING";
    }

    internal interface IRepository { }

    internal class Client
    {

        private static readonly ArrayList _objectArray;
        private static readonly string[] _strArray;
        private static readonly IBook[] _books;

        static Client()
        {
            _objectArray = new ArrayList { 1, 2, 3 };
            _strArray = new string[] { "10", "20", "30" };
            _books = new IBook[] { new Book(), new Book() };
        }

        public static void Main()
        {
            IEnumerable<int> intsFromArrayList = _objectArray.Cast<int>();
            IterateOverSequence<int>(intsFromArrayList);

            _objectArray.Add(8);
            _objectArray.Add("I AM STRING");
            _objectArray.Add(80);

            //Poi: While iterating over sequence the conversion is being performed. That's why, 1, 2 & 3 is printed in console but not
            //"I AM STRING" because while conversion it throws exception

            //Poi: Because Cast<TResult>(...) performs deferred execution '8' is printed in console

            IterateOverSequence<int>(intsFromArrayList);

            //Poi: Normally Cast<TResult>() is used on non-generic collection. But it can be used on generic collections too. Because
            //generic collections implement 'IEnumerable' which all non-generic collections implement

            IEnumerable<object> ints = _strArray.Cast<object>();
            IterateOverSequence<object>(ints);

            IEnumerable<Book> castToBookList = _books.Cast<Book>();

            //Poi: Overridden 'ToString()' will be invoked from here
            IterateOverSequence<Book>(castToBookList);

            IEnumerable<IRepository> failedCastToRepositoryList = _books.Cast<IRepository>();
            IterateOverSequence<IRepository>(failedCastToRepositoryList);
        }

        private static void IterateOverSequence<T>(IEnumerable<T> source)
        {
            Console.WriteLine();

            //Poi: Conversion is being done when 'IEnumerator<T> GetEnumerator()' is invoked. That's why 'foreach' has to be enclosed by
            //'try...catch' which internally calls 'IEnumerator<T> GetEnumerator()'
            try
            {
                foreach(T item in source)
                {
                    Console.WriteLine(item);
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Conversion Failed For Some Value");
            }
        }
    }
}