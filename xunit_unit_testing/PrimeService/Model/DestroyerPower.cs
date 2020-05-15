using System.Collections.Generic;

namespace PrimeService.Model
{
    public class DestroyerPower : Power
    {
        public DestroyerPower() : base(description: "destroyer") { }

        public override void PrepareWeapons() => Weapons = new List<Weapon> { new Destroyer(), new Destroyer(), new Destroyer(), };
    }
}