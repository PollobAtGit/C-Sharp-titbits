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
            IEnumerable<int> intsFromArrayList = _objectArray.OfType<int>();
            IterateOverSequence<int>(intsFromArrayList);

            _objectArray.Add(8);
            _objectArray.Add("I AM STRING");
            _objectArray.Add(80);

            //Poi: While iterating over sequence the filtering is being performed. That's why, 1, 2 & 3 is printed in console but not
            //"I AM STRING". Actually it is being SKIPPED & later '80' is returned/printed in console

            //Poi: Because OfType<TResult>(...) performs deferred execution '8' & '80' is printed in console

            IterateOverSequence<int>(intsFromArrayList);

            //Poi: Normally OfType<TResult>() is used on non-generic collection. But it can be used on generic collections too. Because
            //generic collections implement 'IEnumerable' which all non-generic collections implement

            IEnumerable<object> ints = _strArray.OfType<object>();
            IterateOverSequence<object>(ints);

            IEnumerable<Book> castToBookList = _books.OfType<Book>();

            //Poi: Overridden 'ToString()' will be invoked from here
            IterateOverSequence<Book>(castToBookList);

            //Poi: This filtering will not result any data because all of the elements in sequence is of type IBook & but it has been asked
            //to be converted into IRepository.

            IEnumerable<IRepository> failedCastToRepositoryList = _books.OfType<IRepository>();
            IterateOverSequence<IRepository>(failedCastToRepositoryList);
        }

        private static void IterateOverSequence<T>(IEnumerable<T> source)
        {
            if(!source.Any()) Console.WriteLine("Source Is Empty");

            Console.WriteLine();
            foreach(T item in source)
            {
                Console.WriteLine(item);
            }
        }
    }
}