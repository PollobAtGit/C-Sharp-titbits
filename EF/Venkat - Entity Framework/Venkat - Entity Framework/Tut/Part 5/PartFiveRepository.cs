using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Venkat___Entity_Framework.Tut.Part_5.Model;

namespace Venkat___Entity_Framework.Tut.Part_5
{
    public class PartFiveRepository
    {
        private PartFiveDbContext _context = new PartFiveDbContext();

        public List<DepartmentPartFive> GetDepartments()
        {
            return _context.Departments.Include("Employees").ToList();
        }
    }
}