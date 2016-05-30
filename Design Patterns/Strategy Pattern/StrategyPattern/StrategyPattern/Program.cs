using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Helicopter helicopter = new Helicopter();
            RacingCar racingCar = new RacingCar();
            Car car = new Car();
            Jet flyingJet = new Jet();

            Console.WriteLine();

            Console.WriteLine("Helicopter Action: " + helicopter.GetMovingStrategy());
            Console.WriteLine("Car Action: " + car.GetMovingStrategy());
            Console.WriteLine("Racing Car Action: " + racingCar.GetMovingStrategy());
            Console.WriteLine("Jet Action: " + flyingJet.GetMovingStrategy());

            Console.WriteLine();

            Console.WriteLine("ALPHA OX12FG TAKING OFF ... ");
            Console.WriteLine();
            Console.WriteLine("ALPHA OX12FG STATUS ... ");
            Console.WriteLine();

            flyingJet.ChangeMovingStrategy(new DrivingAlgorithm());
            Console.WriteLine("Jet Action: " + flyingJet.GetMovingStrategy());
            flyingJet.ChangeMovingStrategy(new FlyingAlgorithm());
            Console.WriteLine("Jet Action: " + flyingJet.GetMovingStrategy());
            flyingJet.ChangeMovingStrategy(new FlyingVeryFastAlgorithm());
            Console.WriteLine("Jet Action: " + flyingJet.GetMovingStrategy());
            flyingJet.ChangeMovingStrategy(new FlyingAlgorithm());
            Console.WriteLine("Jet Action: " + flyingJet.GetMovingStrategy());
            flyingJet.ChangeMovingStrategy(new DrivingAlgorithm());
            Console.WriteLine("Jet Action: " + flyingJet.GetMovingStrategy());

            Console.WriteLine("ALPHA OX12FG HAS LANDED SAFELY... :)");
            Console.WriteLine();

        }
    }
}
