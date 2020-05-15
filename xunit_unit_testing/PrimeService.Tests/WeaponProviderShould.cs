using PrimeService.Model;
using Xunit;

namespace PrimeService.Tests
{
    public class WeaponProviderShould
    {
        [Fact]
        public void Return_Singleton_Instance()
        {
            Assert.Same(WeaponProvider.Provider, WeaponProvider.Provider);
        }
    }
}