using System.Collections.Generic;
using System.Linq;
using Venkat___Entity_Framework.Tut.Part_4.Model;

namespace Venkat___Entity_Framework.Tut.Part_4
{
    public class VenketRepository
    {
        private VenketDbContext _context = new VenketDbContext();

        //POI: When using Object Entity we must map methods using the Wizard. Properties are not supported
        //TODO: Why properties are not supported while using Object Entity?

        public List<DepartmentPartFour> GetDepartments()
        {
            //POI: The name provided in the string is not the DB table name nor is the original type name
            //of the entity rather it's the Navigation property in the entity that is 
            //referenced by 'Departments'

            return _context.Departments.Include("Employees").ToList();
        }
    }
}