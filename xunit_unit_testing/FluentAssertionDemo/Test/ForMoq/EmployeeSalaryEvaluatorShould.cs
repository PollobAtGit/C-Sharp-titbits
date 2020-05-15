using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Moqs;
using Xunit;

namespace FluentAssertionDemo.Test.ForMoq
{
    public class EmployeeSalaryEvaluatorShould
    {
        private readonly EmployeeSalaryEvaluator _employeeSalaryEvaluator;
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;

        public EmployeeSalaryEvaluatorShould()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _employeeSalaryEvaluator = new EmployeeSalaryEvaluator(_employeeRepositoryMock.Object);
        }

        [Fact]
        public async Task Increase_Salary_By_Defined_Constants()
        {
            var employee = new Mock<IEmployee>();

            employee.SetupProperty(x => x.Salary, 56m);

            var readOnlyCollection = new List<IEmployee> { employee.Object }.AsReadOnly() as IReadOnlyCollection<IEmployee>;

            _employeeRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(readOnlyCollection));

            await _employeeSalaryEvaluator.IncreaseSalaryAsync();

            employee.Object.Salary.Should().Be(56 + Constants.SalaryIncreaseAmount);
        }
    }
}
