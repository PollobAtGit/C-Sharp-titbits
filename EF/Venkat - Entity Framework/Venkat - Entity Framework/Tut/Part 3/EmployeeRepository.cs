using System.Linq;
using System.Collections.Generic;
using Venkat___Entity_Framework.Tut.Part_3.Model;

namespace Venkat___Entity_Framework.Tut.Part_3
{
    //TODO: Why internal class is not discoverable by 'ObjectDataSource' wizard?
    //POI: Making repository 'public' forced other entities related with Repository to be 'public'
    //POI: Initially, EF will create the the entities & related associations etc. but the Tables will not
    //contain any data to have that we need to seed the database

    public class EmployeeRepository
    {
        private EmployeeDBContext _context = new EmployeeDBContext();

        //POI: internal method is not discoverable by 'ObjectDataSource' entity
        //POI: By default, EF doesn't retrive the navigation property entity objects. But Include forces
        //EF to include the navigation properties that are mentioned in the Include method.

        //TODO: Include takes a string which is not strongly typed. How to use a strongly typed version here?
        //TODO: May be EF retrives navigation property objects when it is asked for it. But for example, 
        //when we are asking a navigation property value via a main entity then what happens? Is internally
        //Include is used?

        public List<Department> GetDepartments() => _context.Departments.Include("Employees").ToList();
    }
}