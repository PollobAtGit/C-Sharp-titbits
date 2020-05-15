using System.Linq;
using FluentAssertions;
using Moq;
using Moqs;
using Xunit;

namespace FluentAssertionDemo.Test.ForMoq
{
    public class EmployeeRepositoryShould
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeRepositoryShould() => _employeeRepository = new EmployeeRepository();

        [Fact]
        public async void Return_All_Added_Employees()
        {
            var employeeOne = new Mock<IEmployee>();
            var employeeTwo = new Mock<IEmployee>();

            const string nidOne = "nid_one";
            const string nidTwo = "nid_two";

            employeeOne.Setup(x => x.NationalId).Returns(nidOne);
            employeeTwo.Setup(x => x.NationalId).Returns(nidTwo);

            await _employeeRepository.SaveAsync(employeeOne.Object);
            await _employeeRepository.SaveAsync(employeeTwo.Object);

            var employees = await _employeeRepository.GetAllAsync();

            employees.Should().HaveCount(2);
            employees.First().NationalId.Should().Be(nidOne);
            employees.Last().NationalId.Should().Be(nidTwo);
        }
    }
}
