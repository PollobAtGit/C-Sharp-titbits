using System.Collections.Generic;
using PrimeService.Model;

namespace PrimeService.Service
{
    public interface IWeaponProducer
    {
        List<Weapon> Produce(LandscapeType landscape, bool canWait = false);
    }
}