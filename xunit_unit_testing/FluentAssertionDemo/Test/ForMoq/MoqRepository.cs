using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Moq;
using Moqs;
using Xunit;

namespace FluentAssertionDemo.Test.ForMoq
{
    public class MoqRepositoryShould
    {
        [Fact]
        public void Create_Mocks_For_All_Dependencies_Of_SUT_Provided_That_Default_Value_Is_Mock_For_Repository()
        {
            var mockRepository = new MockRepository(MockBehavior.Default)
            {
                DefaultValue = DefaultValue.Mock
            };

            var officeMock = mockRepository.Create<IOffice>();
            var employeeMock = mockRepository.Create<IEmployee>();

            employeeMock.Object.Email.Should().NotBeNull();
            officeMock.Object.ChiefExecutiveOfficer.Should().NotBeNull();
        }

        [Fact]
        public void Create_Mocks_For_All_Dependencies_Of_SUT_Provided_That_Default_Value_Is_Empty_For_Repository()
        {
            var mockRepository = new MockRepository(MockBehavior.Default)
            {
                DefaultValue = DefaultValue.Empty
            };

            var officeMock = mockRepository.Create<IOffice>();
            var employeeMock = mockRepository.Create<IEmployee>();

            employeeMock.Object.Email.Should().BeNull();
            officeMock.Object.ChiefExecutiveOfficer.Should().BeNull();
        }
    }
}
