using PrimeService.Model;
using Xunit;

namespace PrimeService.Tests
{
    public class UserShould
    {
        [Fact]
        public void Return_Proper_Increase_Percentile()
        {
            var u = new User(name: "Xerox");

            Assert.Equal(expected: u.CurrentBalance, actual: 0);
            Assert.Equal(expected: u.Accumulate(money: 78.09), actual: 0);
            Assert.Equal(expected: u.CurrentBalance, actual: 78.09);

            // using precsion argument for comparing double values
            Assert.Equal(expected: u.Accumulate(money: 7.09), actual: 11.014, precision: 3);
        }
    }
}

