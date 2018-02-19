using System;

namespace Miles_per_gallon_to_kilometers_pe
{
    class Program
    {
        private const double LitresPerGallon = 4.54609188;
        private const double KiloMetersPerMile = 1.609344;

        public static double Converter(int mpg)
        {
            return Math.Round(KiloMeterRepresentationOfMile(mpg)/LitresPerGallon, 2);
        }

        private static double KiloMeterRepresentationOfMile(int mile)
        {
            return KiloMetersPerMile * mile;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Converter(12));
            Console.WriteLine(Converter(24));
            Console.WriteLine(Converter(36));
        }
    }
}
