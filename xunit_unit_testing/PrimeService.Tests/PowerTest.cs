using System.Collections.Generic;
using PrimeService.Model;
using Xunit;

namespace PrimeService.Tests
{
    public class PowerTestsShould
    {
        [Fact]
        public void Return_Non_Null_Primary_Power_Of_A_Player()
        {
            var p = new Player(health: 100);

            Assert.NotNull(@object: p.PrimaryPower);
        }

        [Fact]
        public void Return_Proper_Weapon_Set()
        {
            var p = new Player(health: 100);

            Assert.NotNull(@object: p.PrimaryPower.Weapons);

            p.PrimaryPower.PrepareWeapons();

            Assert.Contains(expected: new Weapon { Description = "x" }, collection: p.PrimaryPower.Weapons);
            Assert.Contains(expected: new Weapon { Description = "ux" }, collection: p.PrimaryPower.Weapons);
            Assert.Contains(expected: new Weapon { Description = "xxx" }, collection: p.PrimaryPower.Weapons);
        }

        [Fact]
        public void Return_Default_Weapon_Sets()
        {
            var p = new Player(health: 100);

            Assert.NotNull(@object: p.PrimaryPower.Weapons);

            p.PrimaryPower.PrepareWeapons();

            Assert.Equal(expected: p.PrimaryPower.Weapons, actual: new List<Weapon>
            {
                new Weapon { Description = "x" },
                new Weapon { Description = "ux" },
                new Weapon { Description = "xxx"}
            });
        }

        [Fact]
        public void Return_Empty_Weapon_List_Initially()
        {
            var p = new Player(health: 100);

            Assert.NotNull(@object: p.PrimaryPower.Weapons);
            Assert.Empty(collection: p.PrimaryPower.Weapons);
        }

        [Fact]
        public void Return_Have_All_Weapons_With_Damage_Capacity_More_Than_Fifty()
        {
            var p = new Player(health: 88);

            Assert.NotNull(@object: p?.PrimaryPower?.Weapons);

            p.PrimaryPower.PrepareWeapons();

            Assert.All(collection: p.PrimaryPower.Weapons, action: x => Assert.True(condition: x.DamageCapacity >= 50));
        }

        [Fact]
        public void Return_Single_Weapon_After_Rest_Are_Removed()
        {
            var p = new Player(health: 45);

            Assert.NotNull(@object: p.PrimaryPower.Weapons);
            Assert.Empty(collection: p.PrimaryPower.Weapons);

            p.PrimaryPower.PrepareWeapons();

            p.PrimaryPower.DropWeapon();
            p.PrimaryPower.DropWeapon();
            p.PrimaryPower.DropWeapon();
            p.PrimaryPower.DropWeapon();

            Assert.Single(collection: p.PrimaryPower.Weapons);
        }
    }
}
