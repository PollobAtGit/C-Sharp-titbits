using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using PrimeService.Factory;
using PrimeService.Model;
using Xunit;
using Xunit.Abstractions;

namespace FluentAssertionDemo.Test
{
    public class WeaponFactoryShould
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly WeaponFactory _factory;

        public WeaponFactoryShould(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _factory = new WeaponFactory();
        }

        [Fact]
        public void Throw_Argument_Out_Of_Range_Exception_Provided_Rocket_Launcher_Is_Requested()
        {
            Action act = () => { _factory.Create(WeaponType.RocketLauncher); };

            act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*actual value was*");
        }

        [Fact]
        public void Return_Pistol_Object_Provided_That_Pistol_Is_Requested_For() => _factory.Create(WeaponType.Pistol).Should().NotBeNull();
    }
}
