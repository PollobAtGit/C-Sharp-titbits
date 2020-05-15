using FluentAssertions;
using PrimeService.Model;
using Xunit;

namespace FluentAssertionDemo
{
    public class ShortGunShould
    {
        [Fact]
        public void Be_Derived_From_Weapon() => new ShortGun().Should().BeAssignableTo<Weapon>("short guns are weapons");

        [Fact]
        public void Have_Default_Description_After_Initialization() => new ShortGun().Description.Should().Be("Short gun");

        [Fact]
        public void Be_Xml_Serializable() => new Weapon().Should().BeXmlSerializable();
    }
}
