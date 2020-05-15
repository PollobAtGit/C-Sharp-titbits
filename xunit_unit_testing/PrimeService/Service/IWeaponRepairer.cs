using PrimeService.Model;

namespace PrimeService.Service
{
    public interface IWeaponRepairer
    {
        Weapon Repair(Weapon weapon);
    }
}