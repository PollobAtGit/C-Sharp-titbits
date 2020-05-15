using FluentAssertions;
using Moq;
using PrimeService.Model;
using PrimeService.Service;
using Xunit;

namespace FluentAssertionDemo.Test
{
    public class WeaponProducerShould
    {
        private readonly IWeaponProducer _weaponProducer;

        public WeaponProducerShould()
        {
            _weaponProducer = new WeaponProducer();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Return_Empty_Collection_Of_Weapons(bool canWait) => _weaponProducer.Produce(LandscapeType.Sea, canWait).Should().NotBeEmpty();

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Return_At_Least_Three_Items(bool canWait) => _weaponProducer.Produce(LandscapeType.Sea, canWait).Should().NotBeEmpty().And.HaveCountGreaterOrEqualTo(3);

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Return_Unique_Items(bool canWait) => _weaponProducer.Produce(LandscapeType.Sea, canWait).Should().OnlyHaveUniqueItems(x => x.Description);

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Return_Collection_With_A_Torpedo_Provided_That_Landscape_Is_Sea(bool canWait) => _weaponProducer.Produce(LandscapeType.Sea, canWait).Should().Contain(new Torpedo(), "in sea battle player must have a torpedo");

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Return_Collection_Without_A_Torpedo_Provided_That_Landscape_Is_Sea(bool canWait) => _weaponProducer.Produce(LandscapeType.Air, canWait).Should().NotContain(new Torpedo());

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Return_All_Non_Null_Values(bool canWait) => _weaponProducer.Produce(LandscapeType.Sea, canWait).Should().NotContainNulls("every consumer of the API expects usable weapons");

        [Fact]
        public void Return_Torpedo_Bomber_Provided_That_Landscape_Is_Air() => _weaponProducer.Produce(LandscapeType.Air, It.IsAny<bool>()).Should().Contain(new TorpedoBomber(), "in air landscape planes player must destroy ships");
    }
}
