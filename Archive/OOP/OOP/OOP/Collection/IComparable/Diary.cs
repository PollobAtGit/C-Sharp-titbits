using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Collection.InterfaceComparable
{
    internal class Diary : IComparable
    {
        private string petName = null;
        private int? pageCount = null;
        private decimal? price = null;

        public string PetName
        {
            get
            {
                return petName;
            }
            set
            {
                if(!string.IsNullOrWhiteSpace(value))
                {
                    petName = value;
                }
            }
        }
        public int? PageCount
        {
            get
            {
                return pageCount;
            }
            set
            {
                if(value != null && value > 0)
                {
                    pageCount = value;
                }
            }
        }
        public decimal? DiaryPrice
        {
            get
            {
                return price;
            }
            set
            {
                if(value != null && value > 0)
                {
                    price = value;
                }
            }
        }

        public Diary()
        {

        }

        public Diary(string _petName, int _pageCount, int _price)
        {
            PetName = _petName;
            PageCount = _pageCount;
            DiaryPrice = _price;
        }

        public int CompareTo(object otherObj)
        {
            var otherDiary = otherObj as Diary;

            //This will ensure diaries with no page specified will be at the bottom at the list
            var otherDiaryPageCount = (otherDiary.PageCount == null ? int.MaxValue : (int)otherDiary.PageCount);
            var thisDiaryPageCount = (this.PageCount == null ? int.MaxValue : (int)this.PageCount);

            return thisDiaryPageCount - otherDiaryPageCount;
        }
    }

    internal class DescDiaryComparerByPrice : IComparer<Diary>
    {
        int IComparer<Diary>.Compare(Diary firstDiary, Diary otherDiary)
        {
            //This will ensure diaries with no page specified will be at the bottom at the list
            var otherDiaryDiaryPrice = (otherDiary.DiaryPrice == null ? int.MaxValue : (int)otherDiary.DiaryPrice);
            var thisDiaryDiaryPrice = (firstDiary.DiaryPrice == null ? int.MaxValue : (int)firstDiary.DiaryPrice);

            return otherDiaryDiaryPrice - thisDiaryDiaryPrice;
        }
    }

    internal class AscDiaryComparerByPrice : IComparer<Diary>
    {
        //This method contains duplicate code. See 'CompareTo' from class 'Diary'
        int IComparer<Diary>.Compare(Diary firstDiary, Diary otherDiary)
        {
            //This will ensure diaries with no page specified will be at the bottom at the list
            var otherDiaryDiaryPrice = (otherDiary.DiaryPrice == null ? int.MaxValue : (int)otherDiary.DiaryPrice);
            var thisDiaryDiaryPrice = (firstDiary.DiaryPrice == null ? int.MaxValue : (int)firstDiary.DiaryPrice);

            return thisDiaryDiaryPrice - otherDiaryDiaryPrice;
        }
    }

    internal class DescDiaryComparerByPage : IComparer<Diary>
    {
        //This method contains duplicate code. See 'CompareTo' from class 'Diary'
        int IComparer<Diary>.Compare(Diary firstDiary, Diary otherDiary)
        {
            //This will ensure diaries with no page specified will be at the bottom at the list
            var otherDiaryPageCount = (otherDiary.PageCount == null ? int.MaxValue : (int)otherDiary.PageCount);
            var thisDiaryPageCount = (firstDiary.PageCount == null ? int.MaxValue : (int)firstDiary.PageCount);

            return otherDiaryPageCount - thisDiaryPageCount;
        }
    }

    public class AscDiaryComparerByPage : IComparer<Diary>
    {
        //This method contains duplicate code. See 'CompareTo' from class 'Diary'
        int IComparer<Diary>.Compare(Diary firstDiary, Diary otherDiary)
        {
            //This will ensure diaries with no page specified will be at the bottom at the list
            var otherDiaryPageCount = (otherDiary.PageCount == null ? int.MaxValue : (int)otherDiary.PageCount);
            var thisDiaryPageCount = (firstDiary.PageCount == null ? int.MaxValue : (int)firstDiary.PageCount);

            return thisDiaryPageCount - otherDiaryPageCount;
        }
    }

    internal static class TestDiary
    {
        public static void SortDiaryByWithDifferentStrategies()
        {
            List<Diary> lstOfDiaries = new List<Diary>
            {
                new Diary()
                , new Diary
                {
                    PetName = "Rosemary"
                    , PageCount = 100
                    , DiaryPrice = 569
                }
                , new Diary
                {
                    PetName = "Paramount"
                    , PageCount = 120
                    , DiaryPrice = 90
                }
                , new Diary
                {
                    PetName = "Black Diamond"
                    , PageCount = 35
                    , DiaryPrice = 150
                }
            };

            #region Choose strategy
            //Following is similar to 'IComparer<Diary> descByPrice = new DescDiaryComparerByPrice();'
            var ascByPage = new AscDiaryComparerByPage();
            var descByPage = new DescDiaryComparerByPage();
            var ascByPrice = new AscDiaryComparerByPrice();
            var descByPrice = new DescDiaryComparerByPrice();
            #endregion

            Console.WriteLine("Not Sorted\n");
            PrintAllDiaryInformation(lstOfDiaries);

            lstOfDiaries.Sort(descByPrice);

            Console.WriteLine("\nFollowing Is The Sorted List\n");
            PrintAllDiaryInformation(lstOfDiaries);
        }


        public static void SortDiaryByPage()
        {
            List<Diary> lstOfDiaries = new List<Diary>
            {
                new Diary()
                , new Diary
                {
                    PetName = "Rosemary"
                    , PageCount = 100
                    , DiaryPrice = 569
                }
                , new Diary
                {
                    PetName = "Paramount"
                    , PageCount = 120
                    , DiaryPrice = 90
                }
                , new Diary
                {
                    PetName = "Black Diamond"
                    , PageCount = 35
                    , DiaryPrice = 150
                }
            };

            Console.WriteLine("Not Sorted\n");
            PrintAllDiaryInformation(lstOfDiaries);

            //The following will work only and only if IComparable is implemented for Diary
            lstOfDiaries.Sort();

            Console.WriteLine("\nFollowing Is The Sorted List/n");
            PrintAllDiaryInformation(lstOfDiaries);
        }

        //Trying to use var as parameter throws following error
        //Error CS0825  The contextual keyword 'var' may only appear within a local variable declaration or in script code
        private static void PrintAllDiaryInformation(List<Diary> lstOfDiaries)
        {
            foreach (var diary in lstOfDiaries)
            {
                Console.Write("Pet Name: " + diary.PetName + " || ");
                Console.Write("Page Count: " + diary.PageCount + " || ");
                Console.Write("Diary Price: " + diary.DiaryPrice);
                Console.WriteLine();
            }
        }
    }
}
