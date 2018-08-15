using Models;

namespace Service
{
    public class EmployeeMomento
    {
        public int Id { get; set; }
        public string NatinalId { get; set; }
        public decimal Salary { get; set; }

        public static EmployeeMomento Create(Employee employee) => new EmployeeMomento
        {
            Id = employee.Id,
            NatinalId = employee.NationalId,
            Salary = employee.Salary
        };
    }
}