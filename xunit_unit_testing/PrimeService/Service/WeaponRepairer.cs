using PrimeService.Model;

namespace PrimeService.Service
{
    public class WeaponRepairer : IWeaponRepairer
    {
        public Weapon Repair(Weapon weapon)
        {
            if (weapon == null)
                return null;

            if (weapon.DamageCapacity < 0)
                return new Weapon
                {
                    Description = weapon.Description,
                    DamageCapacity = 100
                };

            if (weapon.DamageCapacity < 50)
                return new Weapon
                {
                    Description = weapon.Description,
                    DamageCapacity = weapon.DamageCapacity + 20
                };

            return null;
        }
    }
}
