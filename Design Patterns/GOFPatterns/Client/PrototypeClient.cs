using System;
using PrototypePattern;

namespace Client
{
    internal static class PrototypeClient
    {
        internal static void Execute()
        {
            var powerBank = new PowerBank();
            var clonedPowerBank = powerBank.Clone();

            Console.WriteLine(powerBank.Type.ToString());
            Console.WriteLine(clonedPowerBank.Type.ToString());

            powerBank.Type = ProductType.BEVERAGE;

            Console.WriteLine(powerBank.Type.ToString());//BEVERAGE

            //POI: clonedPowerBank Type hasn't been changed. So it's a proper clone
            Console.WriteLine(clonedPowerBank.Type.ToString());//ELECTRONIC
        }
    }
}
