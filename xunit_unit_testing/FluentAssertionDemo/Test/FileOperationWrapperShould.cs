using System;
using System.Threading.Tasks;
using FluentAssertions;
using PrimeService.Attribute;
using PrimeService.Service;
using Xunit;

namespace FluentAssertionDemo.Test
{
    public class FileOperationWrapperShould
    {
        private readonly Type _fileOperationWrapperType;

        public FileOperationWrapperShould() => _fileOperationWrapperType = typeof(FileOperationWrapper);

        [Fact]
        public void Be_Non_Static() => _fileOperationWrapperType.Should().NotBeStatic();

        [Fact]
        public void Contain_Methods_That_Are_Virtual_And_Return_Boolean() => _fileOperationWrapperType.Methods().ThatReturn<bool>().Should().BeVirtual();

        [Fact]
        public void Contain_Only_Methods_Returning_Task_That_Are_Decorated_With_DoingNothingAttribute()
        {
            _fileOperationWrapperType.Methods().ThatReturn<Task>().Should().BeDecoratedWith<DoingNothingAttribute>();
        }

        [Fact]
        public void Decorate_All_Methods_With_SleepForFiveMinutesAttribute_Provided_That_Method_Is_Already_Decorated_With_DoingNothing() =>
            _fileOperationWrapperType.Methods()
                .ThatAreDecoratedWith<DoingNothingAttribute>()
                .Should().BeDecoratedWith<SleepForFiveMinutesAttribute>();

        [Fact]
        public void Decorate_All_Methods_That_Do_Not_Return_Boolean() =>
            _fileOperationWrapperType.Methods()
                .ThatDoNotReturn<bool>()
                .Should().BeDecoratedWith<SleepForFiveMinutesAttribute>();
    }
}
