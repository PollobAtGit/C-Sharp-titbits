using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOFBuilderPattern;
using GOFBuilderPattern.Vehicle;
using GOFBuilderPattern.Builder;

namespace Client
{
    internal static class BuilderClient
    {
        static void Main(string[] args)
        {
            Execute();
        }

        internal static void Execute()
        {
            //QRY: Look like decorator pattern?
            Director carDirector = new Director(new CommuteCarBuilder(new MazdaTwo()));

            //POI: Building process
            carDirector.Construct();

            var commuteCar = carDirector.ConstructedCar as Car;
            commuteCar.PrintCarInfo();

        }

        internal static void PrintCarInfo(this Car source)
        {
            Console.WriteLine(source);
        }
    }
}