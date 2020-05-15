using PrimeService.Model;
using Xunit;

namespace PrimeService.Tests
{
    public class ShipDestroyerTestShould
    {
        [Fact]
        public void Have_Weapons_With_Damage_Capacity_Over_Ninety()
        {
            var sd = new ShipDestroyer();

            Assert.NotNull(sd.PrimaryPower?.Weapons);
            Assert.Empty(sd.PrimaryPower.Weapons);

            sd.PrimaryPower.PrepareWeapons();

            Assert.All(sd.PrimaryPower.Weapons,
                x => Assert.True(x.DamageCapacity > 90, "Destroyers must have damage capacity over 90"));
        }
    }
}