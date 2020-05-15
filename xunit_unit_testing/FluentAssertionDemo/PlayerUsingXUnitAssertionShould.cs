using FluentAssertions;
using PrimeService.Model;
using Xunit;

namespace FluentAssertionDemo
{
    public class PlayerUsingXUnitAssertionShould
    {
        [Fact]
        public void Have_Primary_Power_Provided_That_Health_Is_Above_Or_Equal_Hundred() => new Player(health: 99).PrimaryPower.Should().NotBeNull();

        [Fact]
        public void Not_Have_Primary_Power_Provided_That_Health_Is_In_Between_Zero_And_Hundred() => new Player(health: 100).PrimaryPower.Should().BeNull();

        [Fact]
        public void Return_Have_All_Weapons_With_Damage_Capacity_More_Than_Fifty()
        {
            var p = new Player(health: 88);

            Assert.NotNull(@object: p?.PrimaryPower?.Weapons);

            p.PrimaryPower.PrepareWeapons();

            Assert.All(collection: p.PrimaryPower.Weapons, action: x => Assert.True(condition: x.DamageCapacity >= 50));
        }
    }
}