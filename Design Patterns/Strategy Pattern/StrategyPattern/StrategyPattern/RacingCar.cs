using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class RacingCar : Vehicle
    {
        public RacingCar()
        {
            Console.WriteLine("Creating RacingCar!");
        }

        public RacingCar(IGoAlgorithm goAlgo)
        {
            goAlgorithm = goAlgo;
            Console.WriteLine("Creating RacingCar! & Moving strategy: " + goAlgorithm.Go());
        }
    }
}
