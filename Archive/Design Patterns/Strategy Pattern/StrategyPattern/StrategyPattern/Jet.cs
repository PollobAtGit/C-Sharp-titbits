using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class Jet : Vehicle
    {
        public Jet()
        {
            Console.WriteLine("Creating Jet!");
        }

        public Jet(IGoAlgorithm goAlgo)
        {
            goAlgorithm = goAlgo;
            Console.WriteLine("Creating Jet! & Moving strategy: " + goAlgorithm.Go());
        }
    }
}
