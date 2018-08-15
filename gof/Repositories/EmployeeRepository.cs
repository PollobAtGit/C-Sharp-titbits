using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EmployeeRepository
    {
        private static List<Employee> Employeess { get; }

        static EmployeeRepository()
        {
            Employeess = new List<Employee>
            {
                new Employee
                {
                    Id=  1,
                    Name = "x",
                    NationalId = "xty",
                    Salary = 100m
                },
                new Employee
                {
                    Id=  2,
                    Name = "y",
                    NationalId = "abc",
                    Salary = 200m
                }
            };
        }

        public List<Employee> GetAll() => Employeess;

        public Employee GetById(int id) => Employeess.Single(x => x.Id == id);
    }
}
