using System;
using PrimeService.Model;

namespace PrimeService.Factory
{
    public class WeaponFactory : Factory<WeaponType, Weapon>
    {
        public override Weapon Create(WeaponType weaponType)
        {
            switch (weaponType)
            {
                case WeaponType.ShortGun:
                    return new ShortGun();
                case WeaponType.Default:
                    return new Weapon();
                case WeaponType.Pistol:
                    return new Pistol();
                default:
                    throw new ArgumentOutOfRangeException(nameof(weaponType), weaponType, null);
            }
        }
    }
}
