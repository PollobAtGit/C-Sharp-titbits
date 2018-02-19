using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqPartitioningWithString
{
    internal class Client
    {
        private static string[] _countries = new string[] { "Australia", "Canada", "Germany", "US", "India", "UK", "Italy" };

        public static void Main()
        {
            //Poi: Following can't be done because IEnumerable<T> can't be assigned to T[] though T[] can be assigned to IEnumerable<T>
            //That's why we can iterate over an array ([]) with LINQ query operator & expression

            //Poi: Using Take<TSource>(...) or Skip<TSource>(...) on sequence will result in a different set if Ordering is done on
            //the sequence first

            //string[] firstThreeCountries = _countries.Take<string>(3);

            //Poi: IEnumerable<TSource>.Take<TSource>(...) & IEnumerable<TSource>.Skip<TSource>(...) are just opposite of each other.
            //What 'Take' takes is ignored by 'Skip' & what 'Skip' takes is ignored by 'Take'

            IEnumerable<string> firstThreeCountries = _countries.Take<string>(3).OrderByDescending<string, string>(cntry => cntry);
            IEnumerable<string> exceptFirstThreeCountries = _countries.Skip<string>(3).OrderByDescending<string, string>(cntry => cntry);

            IEnumerable<string> firstFourCountriesWithQueryExp = (from country in _countries select country).Take<string>(4)
                .OrderByDescending<string, string>(cntry => cntry);

            //Poi: Always Skip offset

            int offset = 2;
            int pageSize = 3;

            IEnumerable<string> thirdAndFourthCountryInList = _countries.Skip<string>(offset).Take<string>(pageSize);
            IEnumerable<string> thirdAndFourthCountryInListTakeFirst = _countries.Take<string>(offset + pageSize).Skip<string>(offset);
            IEnumerable<string> thirdAndFourthCntryInLstQryExpression =
                (from country in _countries select country)
                .Take<string>(offset + pageSize)
                .Skip<string>(offset);

            IEnumerable<string> countriesWthLngthMrThanFv = _countries.Where<string>(country => country.Length >=5);

            //Poi: Skip will always return the REST of the sequence
            //Poi: Take will always return specified number of elements from the beginning of sequence

            IEnumerable<string> countriesWthLngthMrThanFvFrmBgnng = _countries.TakeWhile<string>(country => country.Length >=5);
            IEnumerable<string> cntrsWthLngthNtMrThanFvFrmBgnng = _countries.SkipWhile<string>(country => country.Length >=5);

            Console.WriteLine("\nPAGING BELOW\n");

            //Generally, this is the only parameter that is given
            int page = 1;

            pageSize = 3;
            offset = (page - 1) * pageSize;

            IEnumerable<string> listOfCountriesGivenPage = _countries.Skip<string>(offset).Take<string>(pageSize);
            IterateOverSequence<string>(listOfCountriesGivenPage);

            page = 2;
            offset = (page - 1) * pageSize;
            listOfCountriesGivenPage = _countries.Skip<string>(offset).Take<string>(pageSize);
            IterateOverSequence<string>(listOfCountriesGivenPage);

            page = 3;
            offset = (page - 1) * pageSize;
            listOfCountriesGivenPage = _countries.Skip<string>(offset).Take<string>(pageSize);
            IterateOverSequence<string>(listOfCountriesGivenPage);

            Console.WriteLine("\nPAGING DONE\n");

            IterateOverSequence<string>(firstThreeCountries);
            IterateOverSequence<string>(exceptFirstThreeCountries);
            IterateOverSequence<string>(firstFourCountriesWithQueryExp);
            IterateOverSequence<string>(thirdAndFourthCountryInList);
            IterateOverSequence<string>(thirdAndFourthCountryInListTakeFirst);
            IterateOverSequence<string>(thirdAndFourthCntryInLstQryExpression);
            IterateOverSequence<string>(countriesWthLngthMrThanFv);
            IterateOverSequence<string>(countriesWthLngthMrThanFvFrmBgnng);
            IterateOverSequence<string>(cntrsWthLngthNtMrThanFvFrmBgnng);
            IterateOverSequence<string>(listOfCountriesGivenPage);
        }

        private static void IterateOverSequence<T>(IEnumerable<T> source)
        {
            Console.WriteLine();
            foreach(T item in source)
            {
                Console.WriteLine(item);
            }
        }
    }
}