using System.Linq;
using System.Collections.Generic;
using Venkat___Entity_Framework.Tut.Part_3.Model;

namespace Venkat___Entity_Framework.Tut.Part_3
{
    //TODO: Why internal class is not discoverable by 'ObjectDataSource' wizard?
    //POI: Making repository 'public' forced other entities related with Repository to be 'public'

    public class EmployeeRepository
    {
        private EmployeeDBContext _context = new EmployeeDBContext();

        //POI: internal method is not discoverable by 'ObjectDataSource' entity

        public List<Department> GetDepartments() => _context.Departments.ToList();
    }
}