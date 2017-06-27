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
            return _context.Departments.ToList();
        }
    }
}