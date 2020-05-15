using System;
using FluentAssertions;
using PrimeService.Attribute;
using PrimeService.Factory;
using PrimeService.Model;
using PrimeService.Service;
using Xunit;

namespace FluentAssertionDemo.Test
{
    // ReSharper disable once InconsistentNaming
    public class AllTypesFrom_PrimeService_AssemblyShould
    {
        private readonly Type _fileOperationWrapperType;

        public AllTypesFrom_PrimeService_AssemblyShould() => _fileOperationWrapperType = typeof(FileOperationWrapper);

        [Fact]
        public void Not_Be_Decorated_With_DoingNothingAttribute_Provided_That_Types_Derived_From_Factory() =>
            _fileOperationWrapperType.Assembly.Types().ThatDeriveFrom<Factory<WeaponType, Weapon>>().Should()
                .NotBeDecoratedWith<DoingNothingAttribute>();
    }
}