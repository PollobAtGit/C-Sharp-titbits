using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Moqs;
using Xunit;

namespace FluentAssertionDemo.Test.ForMoq
{
    public class EmailFixerShould
    {
        private readonly Mock<ICommunicator> _communicatorMock;
        private readonly Mock<IOffice> _officeMock;
        private readonly EmailFixer _emailFixer;

        public EmailFixerShould()
        {
            _officeMock = new Mock<IOffice>();
            _communicatorMock = new Mock<ICommunicator>();
            _emailFixer = new EmailFixer(_officeMock.Object, _communicatorMock.Object);
        }

        [Fact]
        public async Task Persist_Changed_Email_Address_Received_Via_Email_Confirmation_Request()
        {
            var emailMock = new Mock<IEmail>();
            var employeeMock = new Mock<IEmployee>();

            var employees = new List<IEmployee>
            {
                employeeMock.Object
            };

            const string dummyEmailAddress = "q@r.com";

            employeeMock.SetupProperty(x => x.Email, new Email { Address = "a@b.com" });

            emailMock.Setup(x => x.Address).Returns(dummyEmailAddress);

            _communicatorMock
                .Setup(x => x.ConfirmEmailAsync(employeeMock.Object))
                .Returns(Task.FromResult(emailMock.Object));

            _officeMock.Setup(x => x.Employees).Returns(employees.AsReadOnly());

            await _emailFixer.FixEmailAsync();

            employeeMock.Object.Email.Address.Should().Be(dummyEmailAddress);
        }
    }
}
