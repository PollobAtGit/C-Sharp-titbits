using FluentAssertions;
using PrimeService.Model;
using Xunit;

namespace FluentAssertionDemo
{
    public class WeaponShould
    {
        [Fact]
        public void Be_Different_Provided_That_They_Have_Different_Description()
        {
            var weapon = new Weapon
            {
                Description = "dummy description",
                DamageCapacity = 66
            };

            weapon.Should().NotBe(new Weapon
            {
                Description = "dummy",
                DamageCapacity = 66
            });
        }

        [Fact]
        public void Be_Considered_Equal_Provided_That_They_Have_Same_Description()
        {
            var weapon = new Weapon
            {
                Description = "dummy description",
                DamageCapacity = 90
            };

            weapon.Should().Be(new Weapon
            {
                Description = "dummy description",
                DamageCapacity = 90
            });
        }

        [Fact]
        public void Have_Default_Negative_Damage_Capacity() => new Weapon().DamageCapacity.Should().BeNegative();
    }
}
