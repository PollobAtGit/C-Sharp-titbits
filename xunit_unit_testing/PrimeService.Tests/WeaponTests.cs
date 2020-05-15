using PrimeService.Model;
using Xunit;

namespace PrimeService.Tests
{
    public class PlayerShould
    {
        [Fact]
        public void Not_Have_Any_Destroyer()
        {
            var p = new Player(health: 00);

            Assert.NotNull(@object: p?.PrimaryPower?.Weapons);

            p.PrimaryPower.PrepareWeapons();

            Assert.All(collection: p.PrimaryPower.Weapons, action: Assert.IsNotType<Destroyer>);
        }
    }

    public class ShipDestroyerShould
    {
        [Fact]
        public void Have_At_Least_One_Destroyer_Weapon()
        {
            var sd = new ShipDestroyer();

            Assert.NotNull(@object: sd?.PrimaryPower?.Weapons);
            Assert.All(collection: sd.PrimaryPower.Weapons, action: x => Assert.IsType<Destroyer>(@object: x));

            sd.PrimaryPower.PrepareWeapons();

            Assert.All(collection: sd.PrimaryPower.Weapons, action: x => Assert.IsType<Destroyer>(@object: x));
        }
    }
}
