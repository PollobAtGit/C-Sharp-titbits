using System;
using System.Reflection;
using FluentAssertions;
using FluentAssertions.Types;
using PrimeService.Attribute;
using PrimeService.Service;
using Xunit;

namespace FluentAssertionDemo.Test
{
    // ReSharper disable once InconsistentNaming
    public class IWeaponProducer_ImplementorsShould
    {
        private readonly Type _fileOperationWrapperType;

        public IWeaponProducer_ImplementorsShould() => _fileOperationWrapperType = typeof(FileOperationWrapper);

        [Fact]
        public void Decorate_It_Self_With_SleepForFiveMinutesAttribute() =>
            _fileOperationWrapperType.Assembly.Types()
                .ThatImplement<IWeaponProducer>()
                .Should().BeDecoratedWith<SleepForFiveMinutesAttribute>();
    }
}