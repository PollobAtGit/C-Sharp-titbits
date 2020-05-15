using System.Linq;
using FluentAssertions;
using PrimeService.Model;
using Xunit;
using Xunit.Abstractions;

namespace FluentAssertionDemo
{
    public class PlayerTestUsingFluentAssertionsShould
    {
        private readonly ITestOutputHelper _outputHelper;

        public PlayerTestUsingFluentAssertionsShould(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Not_Return_Same_Instance_After_Copy()
        {
            var p = new Player(health: 99);

            p.CreateCopy().Should().NotBeSameAs(p);
        }

        [Fact]
        public void Return_Zero_After_Max_Fight()
        {
            var player = new Player(health: 100);

            foreach (var i in Enumerable.Range(start: 0, count: 10))
                player.TakeBlow(severity: 10);

            player.Health.Should().Be(0);
            _outputHelper.WriteLine(player.Health.ToString());
        }

        [Fact]
        public async void Increase_Health_After_Sleep()
        {
            var player = new Player(health: 90);

            player.TakeBlow(severity: 20);

            await player.Sleep();

            player.Health.Should().BeGreaterThan(70);
        }

        [Fact]
        public async void Not_OverFlow_Original_Health_And_Must_Be_Positive()
        {
            var originalHealth = 90;

            var player = new Player(health: originalHealth);

            foreach (var _ in Enumerable.Range(start: 0, count: 10))
                player.TakeBlow(severity: 20);

            foreach (var _ in Enumerable.Range(start: 0, count: 10))
                await player.Sleep();

            player.Health.Should().BeInRange(0, originalHealth);
        }
    }
}
