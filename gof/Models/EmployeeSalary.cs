using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EmployeeSalary
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public static EmployeeSalary Create(Employee employee) => new EmployeeSalary
        {
            Id = employee.Id,
            Salary = employee.Salary,
            Name = employee.Name
        };
    }
}
