using System;
using PrototypePattern;

namespace Client
{
    internal static class PrototypeClient
    {
        internal static void Execute()
        {
            var powerBank = new PowerBank(new Battery { Price = 56.00m });
            var clonedPowerBank = powerBank.Clone<PowerBank>();

            powerBank.PrintPowerBankInfo();
            clonedPowerBank.PrintPowerBankInfo();

            powerBank.Type = ProductType.BEVERAGE;

            //POI: This assignment will change battery price of clonedPowerBank 
            //too because cloning is done shallowly not deeply
            powerBank.Battery.Price = 100m;

            powerBank.PrintPowerBankInfo();//BEVERAGE

            //POI: clonedPowerBank Type hasn't been changed. So it's a proper clone
            clonedPowerBank.PrintPowerBankInfo();//ELECTRONIC

            var milk = new Milk(new FreezingProperty { FreezingPoint = -0.235 });
            var clonedMilk = milk.Clone<Milk>();

            milk.PrintPowerBankInfo();
            clonedMilk.PrintPowerBankInfo();

            //POI: This assignment will not have any impact on cloned instance because Milk 
            //performs deep clone
            milk.FreezingProp.FreezingPoint = 23.023;

            milk.PrintPowerBankInfo();
            clonedMilk.PrintPowerBankInfo();
        }

        internal static void PrintPowerBankInfo(this CloneableProduct source)
        {
            Console.WriteLine(source);
        }
    }
}
