using System.Linq;
using System.Collections.Generic;

namespace PrimeService.Model
{
    public class Power
    {
        public string Description { get; }

        public List<Weapon> Weapons { get; protected set; } = new List<Weapon>();

        public Power(string description)
        {
            Description = description;
        }

        public virtual void PrepareWeapons()
        {
            Weapons = new List<Weapon>
            {
                new Weapon
                {
                    Description = "x",
                    DamageCapacity = 90
                },
                new Weapon
                {
                    Description = "ux",
                    DamageCapacity = 80
                },
                new Weapon
                {
                    Description = "xxx",
                    DamageCapacity = 98
                }
            };
        }

        public void DropWeapon()
        {
            if (Weapons.Count > 1)
                Weapons = Weapons.Take(count: Weapons.Count - 1).ToList();
        }
    }
}
