using FluentAssertions;
using Moq;
using Moq.Protected;
using Moqs;
using Xunit;

namespace FluentAssertionDemo.Test.ForMoq
{
    public class MoqShould
    {
        [Fact]
        public void Return_Null_Email_Provided_That_Default_Value_Is_Not_Set_For_The_Mock() => new Mock<IEmployee>().Object.Email.Should().BeNull();

        [Fact]
        public void Return_Mock_Email_Provided_That_Default_Value_Is_Mock()
        {
            var employeeMock = new Mock<IEmployee>
            {
                DefaultValue = DefaultValue.Mock
            };

            employeeMock.Object.Email.Should().NotBeNull();
            (employeeMock.GetType() == typeof(Mock<IEmployee>)).Should().BeTrue();
        }

        [Fact]
        public void Set_Expectation_Properly_For_Protected_Members()
        {
            var ticketPurchaserMock = new Mock<TicketPurchaser>();

            const string dummyOrderNumber = "SRT";

            ticketPurchaserMock.Protected()
                .Setup<PurchaseInfo>("PreparePurchaseInfo")
                .Returns(new PurchaseInfo { OrderNumber = dummyOrderNumber });

            var ticketPurchaseManager = new TicketPurchaseManager(ticketPurchaserMock.Object);

            ticketPurchaseManager.Purchase().OrderNumber.Should().Be(dummyOrderNumber);
        }
    }
}
