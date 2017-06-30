using System.Collections.Generic;
using System.Linq;
using Venkat___Entity_Framework.Tut.Part_6.Model;

namespace Venkat___Entity_Framework.Tut.Part_6
{
    public class PartSixRepository
    {
        private PartSixDbContext _context = new PartSixDbContext();

        public PartSixRepository()
        {

        }

        public List<PartSixDepartment> GetDepartments()
        {
            return _context.Departments.Include("Employees").ToList();
        }
    }
}