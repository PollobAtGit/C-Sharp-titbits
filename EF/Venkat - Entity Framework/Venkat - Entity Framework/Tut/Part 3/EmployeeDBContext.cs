using System.Data.Entity;
using Venkat___Entity_Framework.Tut.Part_3.Model;

namespace Venkat___Entity_Framework.Tut.Part_3
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext() : base()
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}