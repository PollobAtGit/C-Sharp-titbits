using Ch_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ch_3.Controllers
{
    public class EmployeeController : ApiController
    {
        static readonly IReadOnlyList<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                FirstName = "John",
                LastName = "Sam",
                DepartmentID = 10
            },
            new Employee
            {
                Id = 2,
                FirstName = "Shon",
                LastName = "Tim",
                DepartmentID = 20
            },
            new Employee
            {
                Id = 3,
                FirstName = "Cook",
                LastName = "Patty",
                DepartmentID = 30
            }
        };

        [HttpGet]
        public IEnumerable<Employee> GetAll() => _employees;

        [HttpGet]
        public Employee Get(int id) => _employees.ToList().Find(x => x.Id == id);
    }
}
