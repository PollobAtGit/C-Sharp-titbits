using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class Helicopter : Vehicle
    {
        public Helicopter()
        {
            Console.WriteLine("Creating Helicopter!");
        }

        public Helicopter(IGoAlgorithm goAlgo)
        {
            goAlgorithm = goAlgo;
            Console.WriteLine("Creating Helicopter! & Moving strategy: " + goAlgorithm.Go());
        }
    }
}
