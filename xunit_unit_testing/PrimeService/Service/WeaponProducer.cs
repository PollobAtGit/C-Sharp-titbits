using System.Collections.Generic;
using PrimeService.Attribute;
using PrimeService.Model;

namespace PrimeService.Service
{
    [SleepForFiveMinutes]
    public class WeaponProducer : IWeaponProducer
    {
        public List<Weapon> Produce(LandscapeType landscape, bool canWait = false)
        {
            var weapons = new List<Weapon>
            {
                new Weapon(),
                new Pistol(),
                new Destroyer()
            };

            if (canWait)
                weapons.Add(new RocketLauncher());

            if (landscape == LandscapeType.Sea)
                weapons.Add(new Torpedo());

            if (landscape == LandscapeType.Air)
                weapons.Add(new TorpedoBomber());

            return weapons;
        }
    }
}
