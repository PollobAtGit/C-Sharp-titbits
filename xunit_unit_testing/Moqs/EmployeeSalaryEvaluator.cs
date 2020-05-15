using System.Linq;
using System.Threading.Tasks;

namespace Moqs
{
    public struct Constants
    {
        public const decimal SalaryIncreaseAmount = 5666;
    }

    public interface IEmployeeSalaryEvaluator
    {
        Task IncreaseSalaryAsync();
    }

    public class EmployeeSalaryEvaluator : IEmployeeSalaryEvaluator
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeSalaryEvaluator(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task IncreaseSalaryAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            if (!employees.Any())
                return;

            employees.First().Salary = employees.First().Salary + Constants.SalaryIncreaseAmount;
        }
    }
}
