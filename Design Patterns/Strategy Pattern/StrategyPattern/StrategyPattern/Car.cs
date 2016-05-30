using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class Car : Vehicle
    {
        public Car()
        {
            Console.WriteLine("Creating Car!");
        }

        public Car(IGoAlgorithm goAlgo)
        {
            goAlgorithm = goAlgo;
            Console.WriteLine("Creating Car! & Moving strategy: " + goAlgorithm.Go());
        }
    }
}
