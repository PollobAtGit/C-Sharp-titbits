using System.Threading.Tasks;
using Moq;
using Moqs;
using Xunit;

namespace FluentAssertionDemo.Test.ForMoq
{
    public class EmailSenderShould
    {
        [Fact]
        public async Task Invoke_Email_Server_Send_Method()
        {
            var emailServerMock = new Mock<IEmailServer>();
            var officeMock = new Mock<IOffice>();

            var dummyEmailAddress = "dummy email address";

            officeMock.Setup(x => x.ChiefExecutiveOfficer.Email.Address).Returns(dummyEmailAddress);

            var emailSender = new EmailSender(officeMock.Object, emailServerMock.Object);
            await emailSender.SendAsync();

            emailServerMock.Verify(x => x.SendAsync(dummyEmailAddress));
        }
    }
}
