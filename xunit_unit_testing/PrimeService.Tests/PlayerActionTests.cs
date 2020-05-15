using System.Linq;
using PrimeService.Model;
using Xunit;

namespace PrimeService.Tests
{
    public class PlayerTestShould
    {
        [Fact]
        public void Not_Return_Same_Instance_After_Copy()
        {
            var p = new Player(health: 99);

            Assert.NotSame(p, p.CreateCopy());
        }
    }

    public class PlayerActionShould
    {
        [Fact]
        public void Return_Zero_After_Max_Fight()
        {
            var p = new Player(health: 100);

            foreach (var i in Enumerable.Range(start: 0, count: 10))
                p.TakeBlow(severity: 10);

            Assert.Equal(expected: p.Health, actual: 0);
        }

        [Fact]
        public async void Increase_Health_After_Sleep()
        {
            var p = new Player(health: 90);

            p.TakeBlow(severity: 20);

            await p.Sleep();

            Assert.True(condition: p.Health > 70);
        }

        [Fact]
        public async void Not_OverFlow_Original_Health_And_Must_Be_Positive()
        {
            var originalHealth = 90;

            var p = new Player(health: originalHealth);

            foreach (var _ in Enumerable.Range(start: 0, count: 10))
                p.TakeBlow(severity: 20);

            foreach (var _ in Enumerable.Range(start: 0, count: 10))
                await p.Sleep();

            Assert.InRange(actual: p.Health, low: 0, high: originalHealth);
        }

    }
}
