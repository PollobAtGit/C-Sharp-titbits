using FluentAssertions;
using PrimeService.Factory;
using PrimeService.Model;
using Xunit;

namespace FluentAssertionDemo.Test
{
    public class FactoryShould
    {
        [Fact]
        public void Be_Abstract() => typeof(Factory<WeaponType, Weapon>).Should().BeAbstract();
    }
}
