using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Collection.IEnum
{
    internal enum CableType
    {
        COAXIAL_CABLE
        , TWISTED_PAIR_CABLE
    }

    internal class Hub
    {
        public int NumberOfPorts { get; set; }
        public decimal Price { get; set; }
        public CableType CableType { get; set; }

        public Hub()
        {

        }

        public override string ToString()
        {
            //Fancy way of preparing string
            return String.Concat(new String[]
                    {
                        "Ports: "
                        , NumberOfPorts.ToString()
                        , " || Cable: "
                        , CableType.ToString()
                        , " || Price: "
                        , Price.ToString()
                    });
        }
    }

    static class HubIterator
    {
        public static void TestIterator()
        {
            var lstOfHubs = new List<Hub>()
            {
                new Hub()
                , new Hub
                {
                    NumberOfPorts = 2
                    , CableType = CableType.COAXIAL_CABLE
                    , Price = 1500
                }
                , new Hub
                {
                    NumberOfPorts = 4
                    , CableType = CableType.TWISTED_PAIR_CABLE
                    , Price = 2500
                }
                , new Hub
                {
                    NumberOfPorts = 32
                    , CableType = CableType.COAXIAL_CABLE
                    , Price = 5000
                }
            };

            Console.WriteLine("\nORIGINAL LIST OF HUBS\n");
            IteratingThroughForEach(lstOfHubs);

            Console.WriteLine("\nORIGINAL LIST OF HUBS BUT ITERATING THROUGH IENUMERATOR\n");
            IterrateThroughIEnumerator(lstOfHubs);

            Console.WriteLine("\nORIGINAL LIST OF HUBS BUT ITERATING THROUGH IENUMERABLE\n");
            IterrateThroughIEnumerable(lstOfHubs);

            ForEachReadOnlyBehaviorAndCallByReferenceTest(lstOfHubs);
        }

        private static void IterrateThroughIEnumerable(List<Hub> lstOfHubs)
        {
            //Same as below: IEnumerable<Hub> lst = lstOfHubs.AsEnumerable<Hub>();
            var enumerableLst = lstOfHubs.AsEnumerable<Hub>();

            //For-each actually, internally iterates over IEnumerable list which internally
            //holds each object. IEnumerable is a sugar coat over IEnumerator so that
            //for-each can be directly used over collection
            foreach(var hub in enumerableLst)
            {
                Console.WriteLine(hub);
            }

            //Following ToList() method will return a list that will
            //reference the original list
            var duplicateHubList = enumerableLst.ToList<Hub>();
            
            //Following will modify original & newly generated list
            duplicateHubList[1].Price = 89987;

            Console.WriteLine("\nTESTING FOR TOLIST<HUB>() IMPLICATION\n");

            Console.WriteLine(duplicateHubList[1]);
            Console.WriteLine(lstOfHubs[1]);
        }

        private static void IterrateThroughIEnumerator(List<Hub> lstOfHubs)
        {
            int indx = 0;

            //IEnumerator<Hub> itr = lstOfHubs.GetEnumerator();
            var itr = lstOfHubs.GetEnumerator();

            while (itr.MoveNext())
            {
                if (indx == 2)
                {
                    CheckIteratorPositionWhilePassedtoAfunction(itr);
                }
                else
                {
                    Console.WriteLine(itr.Current);
                    indx++;
                }
            }

            //Following compiles & doesn't throw any exceptions though 'itr' is NULL
            //in this situation. So the following returns NULL
            var hub = itr.Current;
        }

        private static void CheckIteratorPositionWhilePassedtoAfunction(IEnumerator<Hub> itr)
        {
            //IEnumerator pointer stays in the position from where function was invoked
            Console.WriteLine(itr.Current);
        }

        //Checking extension method for List type objects
        public static int ListResetter (this List<Hub> obj)
        {
            throw new NotImplementedException();
        }

        private static void ForEachReadOnlyBehaviorAndCallByReferenceTest(List<Hub> lstOfHubs)
        {
            //Testing read only behavior of for each. Apparently, for each allows to modify value
            Console.WriteLine("\nTEST FOR EACH READ ONLY BEHAVIOR\n");
            IteratingThroughForEach(lstOfHubs, 100);

            //Objects are passed to function by reference. Price has been modified here to 100
            Console.WriteLine("\nCALL BY REFERENCE ?\n");
            IteratingThroughForEach(lstOfHubs);

            Console.WriteLine("\nMODIFIED LIST OF HUBS BUT ITERATING THROUGH ITERATOR\n");
            IterrateThroughIEnumerator(lstOfHubs);
        }

        private static void IteratingThroughForEach(List<Hub> lstOfHubs, int _priceToOverWrite = 0)
        {
            foreach (var hub in lstOfHubs)
            {
                if(_priceToOverWrite != 0)
                {
                    hub.Price = _priceToOverWrite;
                }

                //Following will throw 'Error CS1656' because in this context local variable 'hub' holds
                //iterator's Current Property which is read only. So that can't be changed though other
                //instance members can be changed
                //hub = new Hub();

                Console.WriteLine(hub);
            }
        }
    }
}
