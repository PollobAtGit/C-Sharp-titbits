using System.Data.Entity;
using Venkat___Entity_Framework.Tut.Part_6.Model;

namespace Venkat___Entity_Framework.Tut.Part_6
{
    //POI: This class must be public because EF from somewhere initializes this class

    public class PartSixDbContext : DbContext
    {
        public PartSixDbContext()
        {

        }

        public DbSet<PartSixEmployee> Employees { get; set; }
        public DbSet<PartSixDepartment> Departments { get; set; }
    }
}