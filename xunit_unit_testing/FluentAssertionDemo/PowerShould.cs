using System.Linq;
using FluentAssertions;
using Moq;
using PrimeService.Model;
using Xunit;

namespace FluentAssertionDemo
{
    public class PowerShould
    {
        [Fact]
        public void Not_Drop_The_Last_Weapon_It_Poses_Even_If_Requested()
        {
            var power = new Power(It.IsAny<string>());

            power.PrepareWeapons();

            foreach (var _ in Enumerable.Range(0, 30))
                power.DropWeapon();

            power.Weapons.Should().HaveCount(1);
        }

        [Fact]
        public void Have_Empty_Weapons_Set_Initially() => new Power(It.IsAny<string>()).Weapons.Should().BeEmpty();

        [Fact]
        public void Have_Default_Weapon_Set_Upon_Preparation()
        {
            var p = new Power(It.IsAny<string>());

            p.Weapons.Should().NotBeNull();
            p.PrepareWeapons();

            p.Weapons.Should().Contain(new Weapon
            {
                Description = "x",
            });

            p.Weapons.Should().Contain(new Weapon
            {
                Description = "ux",
            });

            p.Weapons.Should().Contain(new Weapon
            {
                Description = "xxx",
            });
        }
    }
}