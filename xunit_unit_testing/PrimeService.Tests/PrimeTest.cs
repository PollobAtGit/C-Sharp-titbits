using System;
using System.Linq;
using PrimeService.Model;
using Xunit;

namespace PrimeService.Tests
{
    public class PrimeTestShould
    {
        private readonly PrimeFinderService _primeService = new PrimeFinderService();

        [Fact]
        public void Return_True_For_Two()
        {
            Assert.True(condition: _primeService.IsPrime(candidate: 2), userMessage: "2 Is a prime");
        }

        [Fact]
        public void Return_False_For_One()
        {
            Assert.False(condition: _primeService.IsPrime(candidate: 1), userMessage: "1 Should not be prime");
        }
    }

    public class PlayerCharacterShould
    {
        private readonly PlayerCharacter _playerCharacter = new PlayerCharacter();

        [Fact]
        public void Not_Return_Null_As_Default_Name_Parts()
        {
            Assert.True(condition: _playerCharacter.FirstName != null);
            Assert.True(condition: _playerCharacter.LastName != null);
        }

        [Fact]
        public void Return_Name_That_Has_Been_Passed_In_Ctor()
        {
            var fn = "q";
            var ln = "r";

            var pc = new PlayerCharacter(fn: fn, ln: ln);

            Assert.Equal(expected: fn, actual: new String(value: pc.FirstName.Skip(count: 4).ToArray()));
            Assert.Equal(expected: ln, actual: pc.LastName);
        }

        [Fact]
        public void Return_First_Name_With_Mr_As_Prefix_If_Not_Dead()
        {
            var fn = "q";
            var ln = "r";

            var pc = new PlayerCharacter(fn: fn, ln: ln);

            Assert.StartsWith(expectedStartString: "Mr.", actualString: pc.FirstName);
            Assert.Equal(expected: ln, actual: pc.LastName);
        }

        [Fact]
        public void Return_Late_As_Prefix_If_Dead()
        {
            var pc = new PlayerCharacter(fn: "p", ln: "q", diedOn: DateTime.Now);

            Assert.StartsWith(expectedStartString: "Late", actualString: pc.FirstName);
        }

        [Fact]
        public void Contain_Only_Numerics_Seperated_By_Dash_As_Contact_Info()
        {
            Assert.Matches(expectedRegexPattern: "[0-9]{2}-[0-9]{2}", actualString: _playerCharacter.ContactInfo);
        }

    }
}
