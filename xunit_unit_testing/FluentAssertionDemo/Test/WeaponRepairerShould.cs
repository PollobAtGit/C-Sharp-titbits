using System;
using FluentAssertionDemo.ClassData;
using FluentAssertions;
using FluentAssertions.Execution;
using PrimeService.Model;
using PrimeService.Service;
using Xunit;

namespace FluentAssertionDemo.Test
{
    public class WeaponRepairerShould
    {
        private readonly IWeaponRepairer _repairer;

        public WeaponRepairerShould()
        {
            _repairer = new WeaponRepairer();
        }

        [Fact]
        public void Return_Without_Throwing_Exception_Provided_That_Given_Weapon_Is_Null()
        {
            Action act = () => { _repairer.Repair(null); };
            act.Should().NotThrow();
        }

        [Fact]
        public void Return_A_New_Instance_Of_Weapon_Not_The_Provided_One()
        {
            var damagedWeapon = new Weapon();
            var repairedWeapon = _repairer.Repair(damagedWeapon);

            repairedWeapon.Should().NotBeSameAs(damagedWeapon);
        }

        [Theory]
        [ClassData((typeof(WeaponDamageCapacityClassData)))]
        public void Increase_Weapon_Damage_Capacity_By_20_Provided_That_Current_Damage_Capacity_Is_Less_Than_50(int damageCapacity)
        {
            var damagedWeapon = new Weapon
            {
                DamageCapacity = damageCapacity
            };

            var repairedWeapon = _repairer.Repair(damagedWeapon);

            repairedWeapon.DamageCapacity.Should().Be(damagedWeapon.DamageCapacity + 20);
        }

        [Fact]
        public void Return_The_Same_Weapon_Description_And_Increase_Damage_Capacity_After_Repair()
        {
            var damagedWeapon = new Weapon
            {
                Description = "dummy weapon description"
            };

            var repairedWeapon = _repairer.Repair(damagedWeapon);

            // ReSharper disable once ConvertToUsingDeclaration
            using (var assertionScope = new AssertionScope())
            {
                repairedWeapon.Description.Should().Be(damagedWeapon.Description);
                repairedWeapon.DamageCapacity.Should().BeGreaterThan(damagedWeapon.DamageCapacity);
            }
        }
    }
}
