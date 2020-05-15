using FluentAssertions;
using PrimeService.Model;
using Xunit;

namespace FluentAssertionDemo
{
    public class DestroyerShould
    {
        [Fact]
        public void Be_Assignable_To_Weapon() => new Destroyer().Should().BeAssignableTo<Weapon>("because destroyers are weapons");

        [Fact]
        public void Have_Positive_Damage_Capacity() => new Destroyer().DamageCapacity.Should().BePositive();

        [Fact]
        public void Have_Default_Damage_Capacity_In_Range_From_0_To_100() => new Destroyer().DamageCapacity.Should().BeInRange(0, 100);
    }
}
